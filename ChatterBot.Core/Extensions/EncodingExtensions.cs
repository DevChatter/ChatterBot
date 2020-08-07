using System.Text;

namespace ChatterBot.Core.Extensions
{
    public static class EncodingExtensions
    {
        public static string BytesToString(this byte[] bytes)
            => Encoding.UTF8.GetString(bytes);
        public static byte[] StringToBytes(this string text)
            => Encoding.UTF8.GetBytes(text);
    }
}