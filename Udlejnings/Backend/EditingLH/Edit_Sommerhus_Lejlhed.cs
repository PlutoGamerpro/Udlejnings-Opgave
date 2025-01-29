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
                continue;
            }

            // Fetch current values from the database 
            Sommerhuse existingSommerhus = editFromDatabase.FetchSommerhusFromDatabase(sommerhusId);

            if (existingSommerhus == null)
            {
                Console.WriteLine("Sommerhus med dette ID blev ikke fundet.");
                continue; // Continue the loop if no sommerhus found
            }

            // Prompt for new values, default to the current ones
            Console.Write($"Nuvarande Senge Antal: {existingSommerhus.Senge}. Indtast nyt Senge Antal: ");
            string inputSengeAntal = Console.ReadLine();
            if (string.IsNullOrEmpty(inputSengeAntal)) inputSengeAntal = existingSommerhus.Senge.ToString();

            Console.Write($"Nuvarande Kvalitet: {existingSommerhus.Kvalitet}. Indtast ny Kvalitet: ");
            string inputKvalitet = Console.ReadLine();
            if (string.IsNullOrEmpty(inputKvalitet)) inputKvalitet = existingSommerhus.Kvalitet.ToString();

            Console.Write($"Nuvarande Pris: {existingSommerhus.Price}. Indtast ny Pris: ");
            string inputPris = Console.ReadLine();
            if (string.IsNullOrEmpty(inputPris)) inputPris = existingSommerhus.Price.ToString();

            // Validate inputs
            float sengeAntal;
            if (!float.TryParse(inputSengeAntal, out sengeAntal) || sengeAntal <= 0)
            {
                Console.WriteLine("Ugyldigt Senge Antal");
                continue; // Continue the loop if input is invalid
            }

            float kvalitet;
            if (!float.TryParse(inputKvalitet, out kvalitet) || kvalitet <= 0)
            {
                Console.WriteLine("Ugyldig Kvalitet");
                continue; // Continue the loop if input is invalid
            }

            float pris;
            if (!float.TryParse(inputPris, out pris) || pris <= 0)
            {
                Console.WriteLine("Ugyldig Pris");
                continue; // Continue the loop if input is invalid
            }

            // Create the updated object
            Sommerhuse updatedSommerhus = new Sommerhuse(sengeAntal, kvalitet, pris);

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

            // Prompt for new values, default to the current ones
            Console.Write($"Nuvarande Senge Antal: {existingLejlighed.Senge}. Indtast nyt Senge Antal: ");
            string inputSengeAntal = Console.ReadLine();
            if (string.IsNullOrEmpty(inputSengeAntal)) inputSengeAntal = existingLejlighed.Senge.ToString();

            Console.Write($"Nuvarande Kvalitet: {existingLejlighed.Kvalitet}. Indtast ny Kvalitet: ");
            string inputKvalitet = Console.ReadLine();
            if (string.IsNullOrEmpty(inputKvalitet)) inputKvalitet = existingLejlighed.Kvalitet.ToString();

            Console.Write($"Nuvarande Pris: {existingLejlighed.Price}. Indtast ny Pris: ");
            string inputPris = Console.ReadLine();
            if (string.IsNullOrEmpty(inputPris)) inputPris = existingLejlighed.Price.ToString();

            // Validate inputs
            float sengeAntal;
            if (!float.TryParse(inputSengeAntal, out sengeAntal) || sengeAntal <= 0)
            {
                Console.WriteLine("Ugyldigt Senge Antal");
                continue; // Continue the loop if input is invalid
            }

            float kvalitet;
            if (!float.TryParse(inputKvalitet, out kvalitet) || kvalitet <= 0)
            {
                Console.WriteLine("Ugyldig Kvalitet");
                continue; // Continue the loop if input is invalid
            }

            float pris;
            if (!float.TryParse(inputPris, out pris) || pris <= 0)
            {
                Console.WriteLine("Ugyldig Pris");
                continue; // Continue the loop if input is invalid
            }

            // Create the updated object
            Lejlheder updatedLejlighed = new Lejlheder(sengeAntal, kvalitet, pris);

            // Update in the database
            editFromDatabase.UpdateLejlighedInDatabase(lejlighedId, updatedLejlighed);
            Console.WriteLine("Lejlighed er blevet opdateret.");

            Console.Write("Pres KEY to Continue: ");
            Console.ReadKey();
        }
    }
}