using System.Security.Cryptography;
using System.Text;

namespace FileObmen.Helpers
{
    public static class FileHelper
    {
        public static string GetFileType(string fileName)
        {
            var result = fileName.Substring(fileName.LastIndexOf('.') + 1);
            return result;
        }

        public static string GetHash(string input)
        {
            byte[] hash;
            using (var sha = new SHA1CryptoServiceProvider())
                hash = sha.ComputeHash(Encoding.Unicode.GetBytes(input));
            var sb = new StringBuilder();
            foreach (byte b in hash)
                sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }
    }
}