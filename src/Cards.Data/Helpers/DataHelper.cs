using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cards.Data.Helpers;

public static class DataHelper
{
    public static IServiceCollection SetupDB(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContextPool<ApplicationDbContext>(options => options
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention()
        );

        return services;
    }
}
