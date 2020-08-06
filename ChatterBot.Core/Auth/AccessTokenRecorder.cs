using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatterBot.Core.Auth
{
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
                // TODO: Be sure there *is* an entry in the dictionary.
                _twitchAuthentication.Credentials[authType].AuthToken = request.AccessToken;

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}