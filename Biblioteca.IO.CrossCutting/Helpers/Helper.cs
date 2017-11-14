using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.IO.CrossCutting.Helpers
{
    public static class Helper
    {
        public static string ToHash(this string str)
        {
            var hash = new StringBuilder();

            var md5Provider = new MD5CryptoServiceProvider();

            var bytes = md5Provider.ComputeHash(new UTF8Encoding().GetBytes(str));

            foreach (var b in bytes)
            {
                hash.Append(b.ToString("x2"));
            }

            return hash.ToString().ToUpper();
        }
    }
}