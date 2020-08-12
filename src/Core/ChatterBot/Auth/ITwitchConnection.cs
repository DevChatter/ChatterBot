namespace ChatterBot.Core.Auth
{
    public interface ITwitchConnection
    {
        void Connect(TwitchCredentials credentials);
        void Disconnect();
    }
}