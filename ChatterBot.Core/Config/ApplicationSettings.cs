using System.Text;

namespace ChatterBot.Core.Config
{
    public class ApplicationSettings
    {
        public string Entropy { get; set; }
        public byte[] SaltBytes => Encoding.UTF8.GetBytes(Entropy);
    }
}