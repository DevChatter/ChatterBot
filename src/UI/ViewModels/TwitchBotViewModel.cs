using ChatterBot.Auth;
using MahApps.Metro.IconPacks;
using TwitchBotView = ChatterBot.UI.Views.TwitchBotView;

namespace ChatterBot.UI.ViewModels
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