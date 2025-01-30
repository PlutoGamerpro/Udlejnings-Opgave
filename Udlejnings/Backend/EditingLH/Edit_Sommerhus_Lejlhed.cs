using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Backend.MenuDisplayer;
using Udlejnings.Backend.SqlCrud.EditingOperation;
using Udlejnings.Backend.SqlCrud.GetOperation;
using Udlejnings.Models;

namespace Udlejnings.Backend.EditingLH;

public class Edit_Sommerhus_Lejlhed
{

    public void EditOrDeleteSommerhus()
    {
        Console.WriteLine("Rediger OR Slet - Sommerhus");
        Console.WriteLine("1. Rediger Sommerhus");
        Console.WriteLine("2. Slet Sommerhus");

        DeleteSommerhusLejlhed deleteSommerhusLejlhed = new DeleteSommerhusLejlhed();
        Console.Write("Input 1 / 2: ");
        string VælgValgmulighed = Console.ReadLine();

        while (true)
        {
            switch (VælgValgmulighed)
            {
                case "1": EditSommerhus(); break;
                case "2": deleteSommerhusLejlhed.DeleteSommerhusMenu(); break;
                default: Console.WriteLine("Invalid input: 1, 2"); break;
            }

        }
    }

    public void EditOrDeleteLejlhed()
    {
        Console.WriteLine("Rediger OR Slet - Lejlhed");
        Console.WriteLine("1. Rediger Lejlhed");
        Console.WriteLine("2. Slet Lejlhed");

        DeleteSommerhusLejlhed deleteSommerhusLejlhed = new DeleteSommerhusLejlhed();
        Console.Write("Input 1 / 2: ");
        string VælgValgmulighed = Console.ReadLine();

        while (true)
        {
            switch (VælgValgmulighed)
            {
                case "1": EditLejlighed(); break;
                case "2": deleteSommerhusLejlhed.DeleteLejlhedMenu(); break;
                default: Console.WriteLine("Invalid input: 1, 2"); break;
            }

        }
    }



    public void EditSommerhus()
    {

        EditFromDatabase editFromDatabase = new EditFromDatabase();
        GetFromDatabase getFromDatabase = new GetFromDatabase();
        Brugermenu brugermenu = new Brugermenu();

        while (true) // Start a loop to continuously check for user input
        {
            getFromDatabase.FetchSommerhuseFromDatabase();

            Console.Write("Indtast Sommerhus ID (for at finde den sommerhus, der skal redigeres) eller tryk 'Q' for at afslutte: ");
            string userInput = Console.ReadLine();

            // Allow the user to quit by pressing 'Q'
            if (userInput.ToUpper() == "Q")
            {
                Console.WriteLine("Afslutter redigeringen.");
                brugermenu.AdminOperationManager(getFromDatabase);
                break; // Exit the loop
            }

            int sommerhusId;
            if (!int.TryParse(userInput, out sommerhusId))
            {
                Console.WriteLine("Ugyldigt ID. Prøv igen.");
                continue; // Continue the loop if the input is not a valid number
            }

            // Fetch current values from the database 
            Sommerhuse existingSommerhus = editFromDatabase.FetchSommerhusFromDatabase(sommerhusId);

            if (existingSommerhus == null)
            {
                Console.WriteLine("Sommerhus med dette ID blev ikke fundet.");
                continue; // Continue the loop if no sommerhus found
            }

            // Validate input for Senge Antal
            float sengeAntal;
            while (true)
            {
                Console.Write($"Nuvarande Senge Antal: {existingSommerhus.Senge}. Indtast nyt Senge Antal (max 10): ");
                string inputSengeAntal = Console.ReadLine();
                if (string.IsNullOrEmpty(inputSengeAntal)) inputSengeAntal = existingSommerhus.Senge.ToString();

                if (float.TryParse(inputSengeAntal, out sengeAntal) && sengeAntal > 0 && sengeAntal <= 10)
                {
                    break; // Exit the loop when input is valid
                }
                else
                {
                    Console.WriteLine("Ugyldigt Senge Antal. Prøv igen (Senge skal være mellem 1 og 10).");
                }
            }

            // Validate input for Kvalitet
            float kvalitet;
            while (true)
            {
                Console.Write($"Nuvarande Kvalitet: {existingSommerhus.Kvalitet}. Indtast ny Kvalitet (max 10): ");
                string inputKvalitet = Console.ReadLine();
                if (string.IsNullOrEmpty(inputKvalitet)) inputKvalitet = existingSommerhus.Kvalitet.ToString();

                if (float.TryParse(inputKvalitet, out kvalitet) && kvalitet > 0 && kvalitet <= 10)
                {
                    break; // Exit the loop when input is valid
                }
                else
                {
                    Console.WriteLine("Ugyldig Kvalitet. Prøv igen (Kvalitet skal være mellem 1 og 10).");
                }
            }

            // Validate input for Pris
            float pris;
            while (true)
            {
                Console.Write($"Nuvarande Pris: {existingSommerhus.Price}. Indtast ny Pris: ");
                string inputPris = Console.ReadLine();
                if (string.IsNullOrEmpty(inputPris)) inputPris = existingSommerhus.Price.ToString();

                if (float.TryParse(inputPris, out pris) && pris > 0)
                {
                    break; // Exit the loop when input is valid
                }
                else
                {
                    Console.WriteLine("Ugyldig Pris. Prøv igen.");
                }
            }

            // Display available areas and validate input for Område ID
            int områdeId = -1;
            while (true)
            {
                List<Områder> availableAreas = getFromDatabase.FetchAvailableAreas(); // Fetch available areas
                Console.WriteLine("Vælg nyt Område:");

                for (int i = 0; i < availableAreas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {availableAreas[i].OmrådeNavn}");
                }

                Console.Write("Indtast Område ID: ");
                string inputOmrådeId = Console.ReadLine();

                if (int.TryParse(inputOmrådeId, out områdeId) && områdeId >= 1 && områdeId <= availableAreas.Count)
                {
                    string områdeNavn = availableAreas[områdeId - 1].OmrådeNavn;
                    Console.WriteLine($"Område valgt: {områdeNavn}");
                    break; // Exit the loop when input is valid
                }
                else
                {
                    Console.WriteLine("Ugyldigt Område ID. Prøv igen.");
                }
            }

            // Create the updated object with OmrådeNavn
            Sommerhuse updatedSommerhus = new Sommerhuse(sengeAntal, kvalitet, pris, områdeId, getFromDatabase.FetchOmrådeNameById(områdeId));

            // Update in the database
            editFromDatabase.UpdateSommerhusInDatabase(sommerhusId, updatedSommerhus);
            Console.WriteLine("Sommerhus er blevet opdateret.");
            Console.Write("Pres KEY to Continue: ");
            Console.ReadKey();
        }
    }
    public void EditLejlighed()
    {
        EditFromDatabase editFromDatabase = new EditFromDatabase();
        GetFromDatabase getFromDatabase = new GetFromDatabase();
        Brugermenu brugermenu = new Brugermenu();
        Console.WriteLine("Rediger Lejlighed");

        while (true) // Start a loop to continuously check for user input
        {
            getFromDatabase.FetchLejlhederFromDatabase();

            Console.Write("Indtast Lejlighed ID (for at finde den lejlighed, der skal redigeres) eller tryk 'Q' for at afslutte: ");
            string userInput = Console.ReadLine();

            // Allow the user to quit by pressing 'Q'
            if (userInput.ToUpper() == "Q")
            {
                Console.WriteLine("Afslutter redigeringen.");
                brugermenu.AdminOperationManager(getFromDatabase);
                break; // Exit the loop
            }

            int lejlighedId;
            if (!int.TryParse(userInput, out lejlighedId))
            {
                Console.WriteLine("Ugyldigt ID. Prøv igen.");
                continue; // Continue the loop if the ID is invalid
            }

            // Fetch current values from the database
            Lejlheder existingLejlighed = editFromDatabase.FetchLejlighedFromDatabase(lejlighedId);

            if (existingLejlighed == null)
            {
                Console.WriteLine("Lejlighed med dette ID blev ikke fundet.");
                continue; // Continue the loop if no lejlighed found
            }

            // Validate input for Senge Antal
            float sengeAntal;
            while (true)
            {
                Console.Write($"Nuvarande Senge Antal: {existingLejlighed.Senge}. Indtast nyt Senge Antal (max 10): ");
                string inputSengeAntal = Console.ReadLine();
                if (string.IsNullOrEmpty(inputSengeAntal)) inputSengeAntal = existingLejlighed.Senge.ToString();

                if (float.TryParse(inputSengeAntal, out sengeAntal) && sengeAntal > 0 && sengeAntal <= 10)
                {
                    break; // Exit the loop when input is valid
                }
                else
                {
                    Console.WriteLine("Ugyldigt Senge Antal. Prøv igen (Senge skal være mellem 1 og 10).");
                }
            }

            // Validate input for Kvalitet
            float kvalitet;
            while (true)
            {
                Console.Write($"Nuvarande Kvalitet: {existingLejlighed.Kvalitet}. Indtast ny Kvalitet (max 10): ");
                string inputKvalitet = Console.ReadLine();
                if (string.IsNullOrEmpty(inputKvalitet)) inputKvalitet = existingLejlighed.Kvalitet.ToString();

                if (float.TryParse(inputKvalitet, out kvalitet) && kvalitet > 0 && kvalitet <= 10)
                {
                    break; // Exit the loop when input is valid
                }
                else
                {
                    Console.WriteLine("Ugyldig Kvalitet. Prøv igen (Kvalitet skal være mellem 1 og 10).");
                }
            }

            // Validate input for Pris
            float pris;
            while (true)
            {
                Console.Write($"Nuvarande Pris: {existingLejlighed.Price}. Indtast ny Pris: ");
                string inputPris = Console.ReadLine();
                if (string.IsNullOrEmpty(inputPris)) inputPris = existingLejlighed.Price.ToString();

                if (float.TryParse(inputPris, out pris) && pris > 0)
                {
                    break; // Exit the loop when input is valid
                }
                else
                {
                    Console.WriteLine("Ugyldig Pris. Prøv igen.");
                }
            }

            // Display available areas and validate input for Område ID
            int områdeId = -1;
            while (true)
            {
                List<Områder> availableAreas = getFromDatabase.FetchAvailableAreas(); // Fetch available areas
                Console.WriteLine("Vælg nyt Område:");

                for (int i = 0; i < availableAreas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {availableAreas[i].OmrådeNavn}");
                }

                Console.Write("Indtast Område ID: ");
                string inputOmrådeId = Console.ReadLine();

                if (int.TryParse(inputOmrådeId, out områdeId) && områdeId >= 1 && områdeId <= availableAreas.Count)
                {
                    string områdeNavn = availableAreas[områdeId - 1].OmrådeNavn;
                    Console.WriteLine($"Område valgt: {områdeNavn}");
                    break; // Exit the loop when input is valid
                }
                else
                {
                    Console.WriteLine("Ugyldigt Område ID. Prøv igen.");
                }
            }

            // Create the updated object with OmrådeNavn
            Lejlheder updatedLejlighed = new Lejlheder(sengeAntal, kvalitet, pris, områdeId, getFromDatabase.FetchOmrådeNameById(områdeId));

            // Update in the database
            editFromDatabase.UpdateLejlighedInDatabase(lejlighedId, updatedLejlighed);
            Console.WriteLine("Lejlighed er blevet opdateret.");
            Console.Write("Pres KEY to Continue: ");
            Console.ReadKey();
        }
    }
}
