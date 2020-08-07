using ChatterBot.Core.Config;
using System;
using System.Security.Cryptography;

namespace ChatterBot.Core.Auth
{
    public class DataProtection
    {
        private readonly byte[] _entropy;

        public DataProtection(ApplicationSettings appSettings)
        {
            _entropy = appSettings.SaltBytes;
        }

        public byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, _entropy, DataProtectionScope.CurrentUser);
            }
            catch (Exception)
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
            catch (Exception)
            {
                // TODO: Log exception
                return null;
            }
        }
    }
}