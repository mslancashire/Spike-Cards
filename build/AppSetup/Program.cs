using AppSetup.Commands;
using AppSetup.Extensions;
using AppSetup.Models;
using Cards.Data;
using Cards.Data.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Running Application Setup...");

var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

var configuration = builder.Build();

var services = new ServiceCollection()
    .SetupDB(configuration)
    .AddSingleton(TimeProvider.System)
    .AddSingleton<ICardsContext, GreekCardsContext>()
    .AddAllScoped<ICommand>();

var serviceProvider = services
    .BuildServiceProvider()
    .CreateScope()
    .ServiceProvider;

var commands = serviceProvider.GetServices<ICommand>()
    .OrderBy(c => c.Order)
    .ToList();

foreach (var command in commands)
{
    if (!command.IsActive())
    {
        Console.WriteLine($"Skipping {command.Name} as it is not active.");
        continue;
    }

    Console.WriteLine($"Running {command.Name}...");
    var result = await command.Run();

    switch (result)
    {
        case Maybe<bool> failed when result.Failed():
            Console.WriteLine($"Failed running {command.Name}.");
            return;
        case Erred<bool> erred:
            Console.WriteLine($"Error running {command.Name}: {erred.Exception.Message}");
            return;
    }

    Console.WriteLine($"{command.Name} completed successfully.");
}

Console.WriteLine("Finished Application Setup...");