namespace ChatterBot.Core.Auth
{
    public interface ITwitchBot
    {
        void Connect(TwitchCredentials credentials);
        void Disconnect();
    }
}