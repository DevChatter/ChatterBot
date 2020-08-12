using System.Collections.Generic;

namespace ChatterBot.Auth
{
    public interface ITwitchAuthentication
    {
        string GetUrl(AuthenticationType authenticationType);

        Dictionary<AuthenticationType, TwitchCredentials> Credentials { get; set; }
        Dictionary<string, AuthenticationType> States { get; set; }
    }
}