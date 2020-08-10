using System.Text;

namespace ChatterBot.Core.Config
{
    public class ApplicationSettings
    {
        public string Entropy { get; set; } = string.Empty;
        public byte[] SaltBytes => Encoding.UTF8.GetBytes(Entropy);
        public string LightDbConnection { get; set; } = string.Empty;
    }
}