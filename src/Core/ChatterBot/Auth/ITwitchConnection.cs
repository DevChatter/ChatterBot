namespace ChatterBot.Auth
{
    public interface ITwitchConnection
    {
        void Connect(TwitchCredentials credentials);
        void Disconnect();
    }
}