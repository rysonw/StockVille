using System;
using System.Security.Cryptography;

namespace StockVille_backend.Services.Security
{
    class PasswordHashing
    {
        static void Main(string[] args)
        {
            string password = "";
            string hashedPassword = HashPassword(password);
            Console.WriteLine(hashedPassword);
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt = new byte[16]);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }
    }
}