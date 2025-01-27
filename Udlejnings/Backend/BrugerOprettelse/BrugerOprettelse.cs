using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Backend.BrugerOprettelse;

public class BrugerOprettelse
{
    public void CreateUser()
    {
        Console.Write("Input BrugerNavn: ");
        string BrugerNavn = Console.ReadLine();

        Console.Write("Input Adgangskode: ");
        string Adgangskode = Console.ReadLine();

/*
        // Hash adgangskoden og få salt
        var (hashedPassword, salt) = PasswordHasher.HashPassword(Adgangskode);

        // Opret user objekt med den hashede adgangskode og salt
        User user = new User(BrugerNavn, hashedPassword, salt);
        Console.WriteLine("BrugerOprettet");

        // Tilføj bruger til CSV fil (måske drop  CSV)
        /*
        AddToCSVFile addToCSVFile = new AddToCSVFile();
        addToCSVFile.AddUserToCSV("Users.csv", user);
        */
        
    }
}
