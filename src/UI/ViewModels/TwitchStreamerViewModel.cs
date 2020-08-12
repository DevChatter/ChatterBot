using ChatterBot.Auth;
using ChatterBot.UI.Views;
using MahApps.Metro.IconPacks;

namespace ChatterBot.UI.ViewModels
{
    public class TwitchStreamerViewModel : TwitchAccountViewModel
    {
        public TwitchStreamerViewModel(ITwitchAuthentication auth, ITwitchConnection twitchConnection)
            : base(auth, twitchConnection, AuthenticationType.TwitchStreamer,
                new PackIconOcticons { Kind = PackIconOcticonsKind.DeviceCameraVideo },
                "Streamer Account", "Twitch Stream Account Settings", new TwitchStreamerView())
        {
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