using ChatterBot.Auth;
using ChatterBot.Infra.Twitch;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddInfrastructureForTwitch(this IServiceCollection services)
        {
            services.AddTransient<ITwitchConnection, TwitchBot>();
        }
    }
}
