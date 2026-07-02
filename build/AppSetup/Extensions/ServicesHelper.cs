using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AppSetup.Extensions;

internal static class ServicesHelper
{
    internal static IServiceCollection AddAllScoped<TOfType>(this IServiceCollection services)
        where TOfType : class
    {
        var types = Assembly.GetCallingAssembly().GetTypes()
            .Where(t => t.IsNested == false && t.IsClass && !t.IsAbstract && !t.IsInterface && typeof(TOfType).IsAssignableFrom(t))
            .ToList();

        types
            .ForEach(type =>
            {
                var interfaces = type.GetInterfaces();
                foreach (var iface in interfaces)
                {
                    services.AddScoped(iface, type);
                }
            });

        return services;
    }
}
