using ChatterBot.Auth;
using ChatterBot.Domain.Extensions;
using ChatterBot.Infra.Twitch;
using ChatterBot.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddInfrastructureForTwitch(this IServiceCollection services)
        {
            services.AddWithInterfaces<TwitchBot>(typeof(IMessageSender), typeof(ITwitchConnection));
        }
    }
}
