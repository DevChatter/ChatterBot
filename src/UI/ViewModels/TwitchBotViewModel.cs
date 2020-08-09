using ChatterBot.Core.Auth;
using ChatterBot.Views;
using MahApps.Metro.IconPacks;

namespace ChatterBot.ViewModels
{
    public class TwitchBotViewModel : TwitchAccountViewModel
    {
        public TwitchBotViewModel(ITwitchAuthentication auth, ITwitchConnection twitchConnection)
            : base(auth, twitchConnection, AuthenticationType.TwitchBot,
                new PackIconMaterial { Kind = PackIconMaterialKind.Robot },
                "Bot Account", "Twitch Bot Account Settings", new TwitchBotView())
        {
        }

        public string Channel
        {
            get => Credentials.Channel;
            set => SetProperty(() => Credentials.Channel, x => Credentials.Channel = x, value);
        }
    }
}