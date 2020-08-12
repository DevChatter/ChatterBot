using ChatterBot.Core.Auth;
using ChatterBot.Core.Config;
using ChatterBot.Core.State;
using ChatterBot.Domain.Core.State;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDomain(this IServiceCollection services, ApplicationSettings appSettings)
        {
            services.AddSingleton<IDataProtection>(new DataProtection(appSettings));
            services.AddSingleton<ITwitchAuthentication, TwitchAuthentication>();
            services.AddSingleton<IMainMenuItemsSet, MainMenuItemsSet>();
        }
    }
}