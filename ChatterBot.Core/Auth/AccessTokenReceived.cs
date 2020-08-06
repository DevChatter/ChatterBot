using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatterBot.Core.Auth
{
    public class AccessTokenReceived : IRequest<bool>
    {
        public string AccessToken { get; set; }
        public string Scope { get; set; }
        public string State { get; set; }
        public string TokenType { get; set; }

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

    public class AccessTokenRecorder : IRequestHandler<AccessTokenReceived, bool>
    {
        private readonly TwitchAuthentication _twitchAuthentication;

        public AccessTokenRecorder(TwitchAuthentication twitchAuthentication)
        {
            _twitchAuthentication = twitchAuthentication;
        }

        public Task<bool> Handle(AccessTokenReceived request, CancellationToken cancellationToken)
        {
            if (_twitchAuthentication.States.TryGetValue(request.State, out AuthenticationType authType)
                && request.TokenType == "bearer") // TODO: Constant or Enum this!
            {

            }

            throw new System.NotImplementedException();
        }
    }
}
