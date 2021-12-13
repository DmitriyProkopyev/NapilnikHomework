using System;
using System.Security.Cryptography;
using System.Text;

namespace Model
{
    public static class Security
    {
        public static string Sha256(string text)
        {
            var bytes = Encoding.Unicode.GetBytes(text);
            var hash = SHA256.Create().ComputeHash(bytes);
            var result = BitConverter.ToString(hash);
            return result.Replace("-", string.Empty);
        }
    }
}
