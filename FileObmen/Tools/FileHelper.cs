using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FileObmen.Tools
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

        public static string CreateIconPath(HttpServerUtilityBase server, string type)
        {
            type += ".png";
            string path = server.MapPath("~/Content/icons/");
            var files = new DirectoryInfo(path).GetFiles();
            foreach (var file in files)
                if (type.Equals(file.Name))
                    return type;
            return "unknown.png";
        }

        public static string CalcFilesSize(List<Models.Entities.File> files, long total, ref long val)
        {
            double sum = 0;
            files.ForEach(f => sum += f.Size);
            val = (int)sum;
            sum = sum * 100D / total;
            return (int)sum + "%";
        }
    }
}