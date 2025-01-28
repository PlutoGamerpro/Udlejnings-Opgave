using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Models;
using Microsoft.Data.SqlClient;  // Use this namespace instead
using System.Security.Cryptography;
using System.Text;

namespace Udlejnings.Backend.BrugerOprettelse
{

    public class BrugerOprettelse
    { // zoom i morgen klokken 8 , og morgen klokken 8 tirdag og onsdag (hjemmearbejde dag)
        public void CreateUser()
        {
            // Collect user details
            Console.Write("Input Fornavn: ");
            string Fornavn = Console.ReadLine();

            Console.WriteLine("");

            Console.Write("Input Efternavn: ");
            string Efternavn = Console.ReadLine();

            Console.WriteLine("");

            Console.Write("Input Adgangskode: ");
            string Adgangskode = Console.ReadLine();

            // Ask if the user is an admin
            Console.WriteLine("Er du admin? (ja/nej): ");
            string roleInput = Console.ReadLine().ToLower();
            string Role = roleInput == "ja" ? "admin" : "user";

            // Hash the password and generate salt
            var (hashedPassword, salt) = HashPassword(Adgangskode);

            // Save user to the database
            SaveUserToDatabase(Fornavn, Efternavn, hashedPassword, salt, Role);
        }


        // Method to save the user to the database
        private void SaveUserToDatabase(string Fornavn, string Efternavn, string Adgangskode, string Salt, string Role)
        {
            string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [BrugerLejer] (Fornavn, Efternavn, Adgangskode, Salt, Role) VALUES (@Fornavn, @Efternavn, @Adgangskode, @Salt, @Role)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Fornavn", Fornavn);
                    command.Parameters.AddWithValue("@Efternavn", Efternavn);
                    command.Parameters.AddWithValue("@Adgangskode", Adgangskode);
                    command.Parameters.AddWithValue("@Salt", Salt);
                    command.Parameters.AddWithValue("@Role", Role);

                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("User created and saved to the database successfully.");

        }
        private (string hashedPassword, string salt) HashPassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[32]; // 32 bytes for salt
                rng.GetBytes(salt); // Generate the salt
                var saltString = Convert.ToBase64String(salt);

                using (var sha256 = SHA256.Create())
                {
                    var saltedPassword = password + saltString; // Concatenate password with salt
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                    var hashString = Convert.ToBase64String(hashBytes);

                    return (hashString, saltString);
                }
            }
        }
    }
}