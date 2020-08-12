using MediatR;

namespace ChatterBot.Core.Auth
{
    public class AccessTokenReceived : IRequest<bool>
    {
        public string AccessToken { get; set; } = string.Empty;
        public string Scope { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string TokenType { get; set; } = string.Empty;

        public AccessTokenReceived()
        {
        }

        public AccessTokenReceived(string accessToken,
            string scope, string state, string tokenType)
        {
            AccessToken = accessToken;
            Scope = scope;
            State = state;
            TokenType = tokenType;
        }
    }
}
