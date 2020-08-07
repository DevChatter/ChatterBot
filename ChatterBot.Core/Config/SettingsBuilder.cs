using System.Security.Cryptography;
using System.Text;

namespace ChatterBot.Core.Config
{
    public static class SettingsBuilder
    {
        private const int SaltLengthLimit = 32;
        private static readonly RNGCryptoServiceProvider CryptoService = new RNGCryptoServiceProvider();

        public static ApplicationSettings CreateDefaultSettings()
        {
            return new ApplicationSettings
            {
                Entropy = Encoding.UTF8.GetString(GetSalt(SaltLengthLimit)),
            };
        }

        private static byte[] GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = CryptoService)
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }
    }
}