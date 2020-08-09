using ChatterBot.Core.Auth;
using ChatterBot.Core.Config;
using ChatterBot.Core.Interfaces;
using ChatterBot.Core.SimpleCommands;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDomain(this IServiceCollection services, ApplicationSettings appSettings)
        {
            services.AddSingleton<IDataProtection>(new DataProtection(appSettings));
            services.AddSingleton<IPlugin, SimpleCommandsPlugin>();
            services.AddSingleton<ICommandsSet, CommandsSet>();
            services.AddSingleton<ITwitchAuthentication, TwitchAuthentication>();
        }
    }
}