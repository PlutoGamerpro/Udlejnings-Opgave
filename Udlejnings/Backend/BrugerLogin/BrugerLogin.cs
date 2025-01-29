using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Backend.MenuDisplayer;
using Microsoft.Data.SqlClient;  // Use this namespace instead
using System.Security.Cryptography;
using System.Text;
using Udlejnings.Models;
using Udlejnings.Backend.SqlCrud.GetOperation;
using Microsoft.Identity.Client;

namespace Udlejnings.Backend.BrugerLogin;


public class BrugerLogin
{ /// add logic to test if login was ----- admin or normal user so you know what mean you
    

    public void CheckLoginInfo()
    {
        
        Brugermenu brugermenu1 = new Brugermenu();
        GetFromDatabase getFromDatabase = new GetFromDatabase();

        Console.WriteLine("Login process");

        Console.Write("Input Brugernavn: ");
        string DitBrugerNavn = Console.ReadLine();

        Console.Write("Input Adgangskode: ");
        string DitPassword = Console.ReadLine();
        
        // Validate the user's login (using the old method, now optional)
        if (ValidateUserLogin(DitBrugerNavn, DitPassword))
        {

            // Fetch the user from the database by Fornavn to get their role
            BrugerLejer user = getFromDatabase.FetchUserFromDatabase(DitBrugerNavn);
           ObjektSaving.CurrentUser = user;
            // BrugerLejer user = getFromDatabase.FetchUserFromDatabase(DitBrugerNavn);

            // Check the role and perform actions accordingly
            if (user != null)
            {
                if (user.Role == "admin" || user.Role == "Konsulent" )
                {
                    GetFromDatabase tst = new GetFromDatabase();
                    Console.WriteLine("Admin login successful. Admin methods are now available.");
                    Console.WriteLine($"User Found: {user.Fornavn} {user.Efternavn}, Role: {user.Role}");
                    brugermenu1.AdminOperationManager(tst); // Admin-specific methods

                    
                }
                else
                {
                    Console.WriteLine("User login successful. Regular user methods are now available.");
                    Console.WriteLine($"User Found: {user.Fornavn} {user.Efternavn}, Role: {user.Role}");
                    brugermenu1.BrugerOperationManager(); // Regular user-specific methods
                }
              
                // Bekræft booking
              
            }
        }
        else
        {
            Console.WriteLine("Invalid login credentials.");
        }
    }
    // Validate user credentials


    private bool ValidateUserLogin(string Fornavn, string password)
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";
        string storedHashedPassword = "";
        string storedSalt = "";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Retrieve the stored hashed password and salt for the user
            string query = "SELECT Adgangskode, Salt FROM [BrugerLejer] WHERE Fornavn = @Fornavn";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Fornavn", Fornavn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        storedHashedPassword = reader["Adgangskode"].ToString();
                        storedSalt = reader["Salt"].ToString();
                    }
                    else
                    {
                        // User not found
                        return false;
                    }
                }
            }
        }

        // Hash the entered password using the stored salt
        var (hashedInputPassword, _) = HashPasswordWithSalt(password, storedSalt);

        // Compare the input password hash with the stored hash
        return storedHashedPassword == hashedInputPassword;
    }

    // Hash the password with a salt
    private (string hashedPassword, string salt) HashPasswordWithSalt(string password, string salt)
    {
        using (var sha256 = SHA256.Create())
        {
            var saltedPassword = password + salt; // Concatenate password with salt
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            var hashString = Convert.ToBase64String(hashBytes);

            return (hashString, salt); // Return the hash and salt
        }
    }


}

