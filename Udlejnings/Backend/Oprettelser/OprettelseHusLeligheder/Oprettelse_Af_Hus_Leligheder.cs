using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Udlejnings.Backend.SqlCrud.GetOperation;
using Udlejnings.Backend.SqlCrud.InsertOperations;
using Udlejnings.Models;

namespace Udlejnings.Backend.Oprettelser.OprettelseHusLeligheder;

public class Oprettelse_Af_Hus_Leligheder
{
    


    bool KeepRuning = true;
    float OkInputKvalitet = 0;
    float OKInputSengeAntal = 0;
    bool PrisKlasseInputValid = false;
    float price = 0;
    string VælgPrisKlasse = "";


    public void Oprettelse_Af_Sommerhus()
    {
        KeepRuning = true;
        OkInputKvalitet = 0;
        OKInputSengeAntal = 0;
        PrisKlasseInputValid = false;
        price = 0;
        VælgPrisKlasse = "";

        InsertToDatabase insertToDatabase = new InsertToDatabase();
        Prisseasoner prisseasoner = new Prisseasoner();
        GetFromDatabase getFromDatabase = new GetFromDatabase();

        // Fetch the available areas from the database
        List<Områder> områder = getFromDatabase.FetchAvailableAreas();


        string InputSengeAntal;

        string InputKvalitet;

        bool KeepRunning = true;
        // Validate inputs for Senge and Kvalitet
        while (KeepRunning)
        {
            // Input for SengeAntal
            Console.Write("Indtast antal senge (0 - 10): ");
            InputSengeAntal = Console.ReadLine();

            if (float.TryParse(InputSengeAntal, out OKInputSengeAntal))
            {
                if (OKInputSengeAntal > 0 && OKInputSengeAntal <= 10)
                {
                    Console.WriteLine("Inputet for senge er ok.");
                }
                else
                {
                    Console.WriteLine("Inputet er invalid (0 - 10 SENGE). Prøv igen.");
                    continue; // Skip the rest and ask again for SengeAntal
                }
            }
            else
            {
                Console.WriteLine("Inputet er invalid (0 - 10 SENGE). Prøv igen.");
                continue; // Skip the rest and ask again for SengeAntal
            }

            // Input for Kvalitet
            Console.Write("Indtast kvalitet (0 - 10): ");
            InputKvalitet = Console.ReadLine();

            if (float.TryParse(InputKvalitet, out OkInputKvalitet))
            {
                if (OkInputKvalitet > 0 && OkInputKvalitet <= 10)
                {
                    Console.WriteLine("Inputet for kvalitet er ok.");
                    KeepRunning = false; // Stop the loop if both inputs are valid
                }
                else
                {
                    Console.WriteLine("Inputet er invalid (0 - 10 KVALITET). Prøv igen.");
                }
            }
            else
            {
                Console.WriteLine("Inputet er invalid (0 - 10 KVALITET). Prøv igen.");
            }
        }

        // Price selection logic
        while (!PrisKlasseInputValid)
        {
            Console.Write("Vælg pris klassen : Super, Hoj, Mellem, Lav: ");
            VælgPrisKlasse = Console.ReadLine().ToLower();

            if (prisseasoner.PriceMapping.ContainsKey(VælgPrisKlasse))
            {
                price = prisseasoner.PriceMapping[VælgPrisKlasse];
                PrisKlasseInputValid = true;
            }
            else
            {
                Console.WriteLine("Invalid input Super, Hoj, Mellem, Lav");
            }
        }

        Console.WriteLine($"Du har valgt pris klasse: {VælgPrisKlasse}, og prisen er: {price} kr.");

        // Display available areas to the user
        Console.WriteLine("Vælg et område fra følgende liste:");
        for (int i = 0; i < områder.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {områder[i].OmrådeNavn}");
        }

        Console.Write("Indtast nummeret for det område, som Sommerhuset skal oprettes i: ");
        int selectedAreaIndex = -1;

        while (selectedAreaIndex < 0 || selectedAreaIndex >= områder.Count)
        {
            Console.WriteLine("Vælg et område fra følgende liste:");
            for (int i = 0; i < områder.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {områder[i].OmrådeNavn}");
            }

            Console.Write("Indtast nummeret for det område, som Sommerhuset skal oprettes i: ");

            // Try to parse the user input
            try
            {
                selectedAreaIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                // Check if the input is within a valid range
                if (selectedAreaIndex >= 0 && selectedAreaIndex < områder.Count)
                {
                    Områder selectedArea = områder[selectedAreaIndex];
                    Console.WriteLine($"Du har valgt området: {selectedArea.OmrådeNavn}");

                    // Create a new Sommerhus with the selected area
                    Sommerhuse sommerhuse = new Sommerhuse(OKInputSengeAntal, OkInputKvalitet, price, selectedArea.Id, selectedArea.OmrådeNavn);

                    // Insert the Sommerhus to the database
                    insertToDatabase.InsertSommerhusToDatabase(sommerhuse);

                    Console.Write("PRES any KEY to Continue: ");
                    Console.ReadKey();
                }
                else
                {
                    // If the selection is not valid, print an error message
                    Console.WriteLine("Invalid område selection. Please select a valid number.");
                }
            }
            catch (FormatException)
            {
                // If the input is not a valid number, prompt the user to try again
                Console.WriteLine("Inputet er ugyldigt. Prøv venligst at indtaste et nummer.");
            }

        }
    }
    public void Oprettelse_Af_Lejlighed()
    {
        KeepRuning = true;
        OkInputKvalitet = 0;
        OKInputSengeAntal = 0;
        PrisKlasseInputValid = false;
        price = 0;
        VælgPrisKlasse = "";

        InsertToDatabase insertToDatabase = new InsertToDatabase();
        GetFromDatabase getFromDatabase = new GetFromDatabase();

        Prisseasoner prisseasoner = new Prisseasoner();
        List<Områder> områder = getFromDatabase.FetchAvailableAreas();

        // Validate Senge Antal input
        while (KeepRuning)
        {
            Console.Write("Senge Antal: ");
            string InputSengeAntal = Console.ReadLine();

            if (float.TryParse(InputSengeAntal, out OKInputSengeAntal))
            {
                if (OKInputSengeAntal > 0 && OKInputSengeAntal <= 10)
                {
                    Console.WriteLine("Inputet for senge er ok.");
                    break; // Exit the loop when input is valid
                }
                else
                {
                    Console.WriteLine("Inputet er invalid (0 - 10 SENGE). Prøv igen.");
                }
            }
            else
            {
                Console.WriteLine("Inputet er invalid. Prøv igen.");
            }
        }

        // Validate Kvalitet input
        while (KeepRuning)
        {
            Console.Write("Kvalitet: ");
            string InputKvalitet = Console.ReadLine();

            if (float.TryParse(InputKvalitet, out OkInputKvalitet))
            {
                if (OkInputKvalitet > 0 && OkInputKvalitet <= 10)
                {
                    Console.WriteLine("Inputet for kvalitet er ok.");
                    break; // Exit the loop when input is valid
                }
                else
                {
                    Console.WriteLine("Inputet er invalid (0 - 10 KVALITET). Prøv igen.");
                }
            }
            else
            {
                Console.WriteLine("Inputet er invalid. Prøv igen.");
            }
        }

        // Validate Price Class input
        while (!PrisKlasseInputValid)
        {
            Console.Write("Vælg pris klassen : Super, Hoj, Mellem, Lav: ");
            VælgPrisKlasse = Console.ReadLine().ToLower();

            if (prisseasoner.PriceMapping.ContainsKey(VælgPrisKlasse))
            {
                price = prisseasoner.PriceMapping[VælgPrisKlasse];
                PrisKlasseInputValid = true;
                Console.WriteLine($"Pris valgt: {price}");
            }
            else
            {
                Console.WriteLine("Invalid input. Vælg mellem: Super, Hoj, Mellem, Lav.");
            }
        }

        // Validate area selection input
        int selectedAreaIndex = -1;
        while (selectedAreaIndex < 0 || selectedAreaIndex >= områder.Count)
        {
            Console.WriteLine("Vælg et område fra følgende liste:");
            for (int i = 0; i < områder.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {områder[i].OmrådeNavn}");
            }

            Console.Write("Indtast nummeret for det område, som Lejligheden skal oprettes i: ");
            string input = Console.ReadLine();

            try
            {
                selectedAreaIndex = Convert.ToInt32(input) - 1;

                // Check if the selection is valid
                if (selectedAreaIndex >= 0 && selectedAreaIndex < områder.Count)
                {
                    Områder selectedArea = områder[selectedAreaIndex];
                    Console.WriteLine($"Du har valgt området: {selectedArea.OmrådeNavn}");

                    // Create the Lejlhed with the selected area
                    Lejlheder lejlheder = new Lejlheder(OKInputSengeAntal, OkInputKvalitet, price, selectedArea.Id, selectedArea.OmrådeNavn);

                    // Insert the Lejlhed to the database
                    insertToDatabase.InsertLejlhedToDatabase(lejlheder);

                    Console.Write("PRES any KEY to Continue: ");
                    Console.ReadKey();
                    break; // Exit loop after successful insertion
                }
                else
                {
                    Console.WriteLine("Invalid område selection. Please select a valid area.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Inputet er ugyldigt. Prøv venligst at indtaste et nummer.");
            }
        }

    }

}
