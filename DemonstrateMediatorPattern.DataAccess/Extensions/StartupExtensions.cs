using DemonstrateMediatorPattern.DataAccess.Interfaces;
using DemonstrateMediatorPattern.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemonstrateMediatorPattern.DataAccess.Extensions
{
    public static class StartupExtensions
    {
        public static void AddDataAccessServiceCollection(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddTransient<IUnitOfWork, UnitOfWork>()

                // repositories
                .AddScoped<IWeatherRepository, WeatherRepository>();
        }
    }
}
