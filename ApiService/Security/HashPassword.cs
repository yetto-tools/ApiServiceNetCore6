
using System.Text;
using System.Security.Cryptography;

namespace ApiService.Security
{
    public class HashPassword
    {
        public string Password { get; set; } = string.Empty;
        private readonly StringBuilder sb_hashToString = new();

        public string SHA2_256ASCII()
        {
            using (SHA256 hasher = SHA256.Create())
            {
                byte[] hashbyte = hasher.ComputeHash(Encoding.ASCII.GetBytes(Password));
                foreach (byte _byte in hashbyte)
                {
                    sb_hashToString.Append(_byte.ToString("X2"));
                }

                return sb_hashToString.ToString();
            }
        }
        public string SHA2_256Unicode()
        {
            using (SHA256 hasher = SHA256.Create())
            {
                byte[] hashbyte = hasher.ComputeHash(Encoding.Unicode.GetBytes(Password));
                foreach (byte _byte in hashbyte)
                {
                    sb_hashToString.Append(_byte.ToString("X2"));
                }

                return sb_hashToString.ToString();
            }
        }

        public bool Verificate_SHA2_256ASCII(string hash)
        {
            string hashOfInput = SHA2_256ASCII();
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
