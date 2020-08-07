using ChatterBot.Core.Extensions;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatterBot.Core.Auth
{
    public class AccessTokenRecorder : IRequestHandler<AccessTokenReceived, bool>
    {
        private readonly TwitchAuthentication _twitchAuthentication;
        private readonly DataProtection _dataProtection;

        public AccessTokenRecorder(TwitchAuthentication twitchAuthentication,
            DataProtection dataProtection)
        {
            _twitchAuthentication = twitchAuthentication;
            _dataProtection = dataProtection;
        }

        public Task<bool> Handle(AccessTokenReceived request, CancellationToken cancellationToken)
        {
            if (_twitchAuthentication.States.TryGetValue(request.State, out AuthenticationType authType)
                && request.TokenType == "bearer") // TODO: Constant or Enum this!
            {
                var encrypted = _dataProtection.Protect(request.AccessToken.StringToBytes());
                // TODO: Be sure there *is* an entry in the dictionary.
                _twitchAuthentication.Credentials[authType].AuthToken = encrypted;

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}