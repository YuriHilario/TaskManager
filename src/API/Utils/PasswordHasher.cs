using System.Security.Cryptography;
using System.Text;

namespace API.Utils
{
    public static class PasswordHasher
    {
        public static string ComputeSha256Hash(string rawData)
        {
            using (var sha256 = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                var builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
