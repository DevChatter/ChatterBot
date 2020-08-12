using ChatterBot.Config;
using ChatterBot.Data;
using ChatterBot.Infra.LiteDb;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddInfrastructureForLiteDb(this IServiceCollection services, ApplicationSettings appSettings)
        {
            services.AddSingleton<IDataStore>(provider =>
            {
                var dataStore = new DataStore(appSettings);
                dataStore.EnsureSchema();
                return dataStore;
            });
        }
    }
}