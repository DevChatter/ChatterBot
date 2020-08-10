using System;

namespace ChatterBot.Core.Auth
{
    public class TwitchCredentials
    {
        public AuthenticationType AuthType { get; set; } = AuthenticationType.Unknown;
        public byte[] AuthToken { get; set; } = Array.Empty<byte>();
        public string Username { get; set; } = string.Empty;
        public string Channel { get; set; } = string.Empty;
    }
}