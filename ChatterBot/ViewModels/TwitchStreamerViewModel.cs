using ChatterBot.Core.Auth;
using MahApps.Metro.IconPacks;

namespace ChatterBot.ViewModels
{
    public class TwitchStreamerViewModel : TwitchAccountViewModel
    {
        public TwitchStreamerViewModel(TwitchAuthentication auth, ITwitchBot twitchBot)
            : base(auth, twitchBot, AuthenticationType.TwitchStreamer)
        {
            Icon = new PackIconOcticons { Kind = PackIconOcticonsKind.DeviceCameraVideo };
            Label = "Streamer Account";
            ToolTip = "Twitch Stream Account Settings";
        }

        public override string Username
        {
            get => Credentials.Username;
            set
            {
                Credentials.Channel = value;
                SetProperty(() => Credentials.Username, x => Credentials.Username = x, value);
            }
        }
    }
}