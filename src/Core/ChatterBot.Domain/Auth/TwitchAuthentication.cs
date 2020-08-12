using ChatterBot.Core.Auth;
using ChatterBot.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatterBot.Domain.Auth
{
    internal class TwitchAuthentication : ITwitchAuthentication
    {
        public TwitchAuthentication(IDataStore dataStore)
        {
            var credentials = dataStore.GetEntities<TwitchCredentials>();

            Credentials = credentials.Any()
                ? credentials.ToDictionary(x => x.AuthType)
                : new Dictionary<AuthenticationType, TwitchCredentials>();
        }

        public const string ClientId = "4e5f6e3z1rfby5qaxcooobv2hpq2wg";

        public Dictionary<string, AuthenticationType> States { get; set; }
            = new Dictionary<string, AuthenticationType>();

        public Dictionary<AuthenticationType, TwitchCredentials> Credentials { get; set; }

        public const string RedirectUrl = "http://localhost:1111/";

        public static HashSet<string> Scopes = new HashSet<string>
        {
            "bits:read",
            "channel:edit:commercial",
            "channel:read:hype_train",
            "channel:read:subscriptions",
            "channel:moderate",
            "chat:edit",
            "chat:read",
            "whispers:read",
            "whispers:edit",
        };
        public static string ScopeString = string.Join("+", value: Scopes.ToArray());


        public string GetUrl(AuthenticationType authenticationType)
        {
            string state = Guid.NewGuid().ToString();
            States.Add(state, authenticationType);

            return $"https://id.twitch.tv/oauth2/authorize?client_id={ClientId}&redirect_uri={RedirectUrl}&response_type=token&scope={ScopeString}&state={state}";
        }
    }
}