using KanzWayScreening.Application.Screening.Interfaces;
using KanzWayScreening.Application.Screening.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace KanzWayScreening.Application.Common.DI
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            ConfigureQueries(services);
        }

        private static void ConfigureQueries(IServiceCollection services)
        {
            services.AddScoped<IScreeningQueryManager, ScreeningQueryManager>();
        }
    }
}
