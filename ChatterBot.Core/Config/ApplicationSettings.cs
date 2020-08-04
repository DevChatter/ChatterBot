using System.Security.Cryptography;
using System.Text;

namespace ChatterBot.Core.Config
{
    public class ApplicationSettings
    {
        public string Entropy { get; set; }
        public byte[] SaltBytes => Encoding.UTF8.GetBytes(Entropy);
        private const int SaltLengthLimit = 32;
        private static readonly RNGCryptoServiceProvider CryptoService = new RNGCryptoServiceProvider();

        public static ApplicationSettings GetDefault => new ApplicationSettings();

        public ApplicationSettings()
        {
            Entropy = Encoding.UTF8.GetString(GetSalt(SaltLengthLimit));
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