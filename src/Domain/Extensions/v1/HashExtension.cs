using System.Security.Cryptography;
using System.Text;

namespace Domain.Extensions.v1
{
    public static class HashExtension
    {
        public static string GetHash(string password)
        {
            var md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
                strBuilder.Append(result[i].ToString("x2"));

            return strBuilder.ToString();
        }
    }
}
