using ChatterBot.Core.Auth;
using ChatterBot.Core.Extensions;
using TwitchLib.Client.Models;

namespace ChatterBot.Infra.Twitch.Extensions
{
    public static class CredentialsExtensions
    {
        // TODO: #28 Replace CredentialsExtensions with AutoMapper profiles.
        public static ConnectionCredentials ToTwitchLib(this TwitchCredentials credentials, IDataProtection dataProtection)
        {
            if (credentials.AuthToken == null)
                throw new System.ArgumentException("Unable to convert null AuthToken", nameof(credentials));
            
            return new ConnectionCredentials(credentials.Username, dataProtection.Unprotect(credentials.AuthToken).BytesToString());
        }
    }
}