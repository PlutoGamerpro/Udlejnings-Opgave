using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Models;

namespace Udlejnings.Backend.BrugerOprettelse;

public class BrugerOprettelse
{ // zoom i morgen klokken 8 , og morgen klokken 8 tirdag og onsdag (hjemmearbejde dag)
    public void CreateUser()
    {
        Console.Write("Input Fornavn: ");
        string Fornavn = Console.ReadLine();

        Console.WriteLine("");

        Console.Write("Input Efternavn: ");
        string Efternavn = Console.ReadLine();

        Console.WriteLine("");

        Console.Write("Input Adgangskode: ");
        string Adgangskode = Console.ReadLine();

/*
        // Hash adgangskoden og få salt
        var (hashedPassword, salt) = PasswordHasher.HashPassword(Adgangskode);

        // Opret user objekt med den hashede adgangskode og salt
         BrugerLejer = new BrugerLejer(BrugerNavn, hashedPassword, salt);
        Console.WriteLine("BrugerOprettet");

        // Tilføj bruger til CSV fil (måske drop  CSV)
        /*
        AddToCSVFile addToCSVFile = new AddToCSVFile();
        addToCSVFile.AddUserToCSV("Users.csv", user);
        */
        
    }
}
