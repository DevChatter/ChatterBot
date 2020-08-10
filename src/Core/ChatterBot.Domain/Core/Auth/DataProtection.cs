using ChatterBot.Core.Config;
using System;
using System.Security.Cryptography;

namespace ChatterBot.Core.Auth
{
    internal class DataProtection : IDataProtection
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
                return Array.Empty<byte>();
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
                return Array.Empty<byte>();
            }
        }
    }
}