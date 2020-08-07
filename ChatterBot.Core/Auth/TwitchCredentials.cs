namespace ChatterBot.Core.Auth
{
    public class TwitchCredentials
    {
        public byte[] AuthToken { get; set; }
        public string Username { get; set; }
        public string Channel { get; set; }
    }
}