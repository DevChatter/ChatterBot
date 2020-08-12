using ChatterBot.Config;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, ApplicationSettings appSettings)
        {
            services.AddInfrastructureForLiteDb(appSettings);
            services.AddInfrastructureForTwitch();
        }
    }
}