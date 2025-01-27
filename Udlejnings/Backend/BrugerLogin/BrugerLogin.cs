using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Backend.MenuDisplayer;

namespace Udlejnings.Backend.BrugerLogin;

public class BrugerLogin
{
    Brugermenu brugermenu1 = new Brugermenu();

    public void CheckLoginInfo()
    {
        Console.WriteLine("Log in processe");

        Console.Write("Input Brugernavn: ");
        string DitBrugerNavn = Console.ReadLine();

        Console.Write("Input Adgangskode: ");
        string DitPassword = Console.ReadLine();


        CheckIfUserExist(DitBrugerNavn, DitPassword);


    }

    public void CheckIfUserExist(string brugernavn, string password)
    {
        Brugermenu brugermenu = new Brugermenu();
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "users.csv");  // Assuming the CSV file stores user data

        if (!File.Exists(filePath))
        {
            Console.WriteLine("User file does not exist.");
            return;
        }

        bool userFound = false;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] userDetails = line.Split(',');

                // Directly check if the username and password match
                if (userDetails.Length >= 3 && userDetails[1] == brugernavn && userDetails[2] == password)
                {
                    userFound = true;
                    Console.WriteLine("Login successful!");
                    brugermenu.PokéMonOperations();
                    break;
                }
            }
        }

        if (!userFound)
        {
            Console.WriteLine("Invalid username or password.");
        }
    }
}
