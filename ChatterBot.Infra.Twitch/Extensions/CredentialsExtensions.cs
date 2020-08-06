using ChatterBot.Core.Auth;
using TwitchLib.Client.Models;

namespace ChatterBot.Infra.Twitch.Extensions
{
    public static class CredentialsExtensions
    {
        public static ConnectionCredentials ToTwitchLib(this TwitchCredentials credentials)
            => new ConnectionCredentials(credentials.Username, credentials.AuthToken);
    }
}