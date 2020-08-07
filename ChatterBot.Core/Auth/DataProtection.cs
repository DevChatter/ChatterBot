using ChatterBot.Core.Config;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace ChatterBot.Core.Auth
{
    public class DataProtection
    {
        private readonly byte[] _entropy;

        public DataProtection(IOptions<ApplicationSettings> appSettings)
        {
            _entropy = appSettings.Value.SaltBytes;
        }

        public byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, _entropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
                // TODO: Log exception
                return null;
            }
        }

        public byte[] Unprotect(byte[] data)
        {
            try
            {
                return ProtectedData.Unprotect(data, _entropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
                // TODO: Log exception
                return null;
            }
        }
    }
}