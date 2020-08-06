using ChatterBot.Core.Auth;
using ChatterBot.Infra.Twitch;
using MahApps.Metro.IconPacks;

namespace ChatterBot.ViewModels
{
    public class TwitchStreamerViewModel : TwitchAccountViewModel
    {
        public TwitchStreamerViewModel(TwitchAuthentication auth) : base(auth)
        {
            Icon = new PackIconOcticons { Kind = PackIconOcticonsKind.DeviceCameraVideo };
            Label = "Streamer Account";
            ToolTip = "Twitch Stream Account Settings";
        }

        protected override AuthenticationType AuthType => AuthenticationType.TwitchStreamer;
    }
}