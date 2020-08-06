using ChatterBot.Infra.Twitch;
using MahApps.Metro.IconPacks;

namespace ChatterBot.ViewModels
{
    public class TwitchBotViewModel : TwitchAccountViewModel
    {
        private string _channel;

        public TwitchBotViewModel(TwitchAuthentication auth) : base(auth)
        {
            Icon = new PackIconMaterial { Kind = PackIconMaterialKind.Robot };
            Label = "Bot Account";
            ToolTip = "Twitch Bot Account Settings";
        }

        public string Channel
        {
            get => _channel;
            set => SetProperty(ref _channel, value);
        }
    }
}