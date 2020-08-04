using System.Security.Cryptography;

namespace ChatterBot.Core.Auth
{
    public class DataProtection
    {
        private readonly byte[] _entropy;

        public DataProtection()
        {
            // TODO: Get entropy "salt" from config file.
            _entropy = new byte[] { 23, 42, 12, 23, 44, 51, 122, 93, 74 };
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