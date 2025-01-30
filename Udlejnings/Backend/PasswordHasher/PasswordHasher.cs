using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Udlejnings.Backend.PasswordHasher;
/*
public static class PasswordHasher
{
    public static (string hashedPassword, string salt) HashPassword(string password)
    {
        // Generer et tilfældigt salt
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] saltBytes = new byte[16];  // 16 bytes salt
            rng.GetBytes(saltBytes);
            string salt = Convert.ToBase64String(saltBytes);

            // Hash adgangskoden sammen med saltet
            using (SHA256 sha256 = SHA256.Create())
            {
                // Kombiner password og salt
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                // Konverter hash til base64-string
                string hashedPassword = Convert.ToBase64String(hashedBytes);
                return (hashedPassword, salt);
            }
        }
    }

    public static bool VerifyPassword(string enteredPassword, string storedHashedPassword, string storedSalt)
    {
        // Hash den indtastede adgangskode med det lagrede salt og sammenlign
        var (hashedPassword, _) = HashPassword(enteredPassword + storedSalt);
        return hashedPassword == storedHashedPassword;
    }
}*/
