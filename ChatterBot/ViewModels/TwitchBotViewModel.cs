using ChatterBot.Core.Auth;
using MahApps.Metro.IconPacks;

namespace ChatterBot.ViewModels
{
    public class TwitchBotViewModel : TwitchAccountViewModel
    {
        public TwitchBotViewModel(TwitchAuthentication auth, ITwitchBot twitchBot)
            : base(auth, twitchBot, AuthenticationType.TwitchBot)
        {
            Icon = new PackIconMaterial { Kind = PackIconMaterialKind.Robot };
            Label = "Bot Account";
            ToolTip = "Twitch Bot Account Settings";
        }

        public string Channel
        {
            get => Credentials.Channel;
            set => SetProperty(() => Credentials.Channel, x => Credentials.Channel = x, value);
        }
    }
}