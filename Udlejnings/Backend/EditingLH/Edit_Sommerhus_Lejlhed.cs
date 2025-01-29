using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Backend.SqlCrud.EditingOperation;
using Udlejnings.Models;

namespace Udlejnings.Backend.EditingLH;

public class Edit_Sommerhus_Lejlhed
{

    public void EditOrDeleteSommerhus(){
        Console.WriteLine("Rediger OR Slet - Sommerhus");
        Console.WriteLine("1. Rediger Sommerhus");
        Console.WriteLine("2. Slet Sommerhus");

        DeleteSommerhusLejlhed deleteSommerhusLejlhed = new DeleteSommerhusLejlhed();
        string VælgValgmulighed = Console.ReadLine();

    while(true){
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

        Console.WriteLine("Rediger Sommerhus");

        Console.WriteLine("Indtast Sommerhus ID (for at finde den sommerhus, der skal redigeres): ");
        int sommerhusId = int.Parse(Console.ReadLine());

        // Fetch current values from the database 

        Sommerhuse existingSommerhus = editFromDatabase.FetchSommerhusFromDatabase(sommerhusId);

        if (existingSommerhus == null)
        {
            Console.WriteLine("Sommerhus med dette ID blev ikke fundet.");
            return;
        }

        // Prompt for new values, default to the current ones
        Console.WriteLine($"Nuvarande Senge Antal: {existingSommerhus.Senge}. Indtast nyt Senge Antal: ");
        string inputSengeAntal = Console.ReadLine();
        if (string.IsNullOrEmpty(inputSengeAntal)) inputSengeAntal = existingSommerhus.Senge.ToString();

        Console.WriteLine($"Nuvarande Kvalitet: {existingSommerhus.Kvalitet}. Indtast ny Kvalitet: ");
        string inputKvalitet = Console.ReadLine();
        if (string.IsNullOrEmpty(inputKvalitet)) inputKvalitet = existingSommerhus.Kvalitet.ToString();

        Console.WriteLine($"Nuvarande Pris: {existingSommerhus.Price}. Indtast ny Pris: ");
        string inputPris = Console.ReadLine();
        if (string.IsNullOrEmpty(inputPris)) inputPris = existingSommerhus.Price.ToString();

        // Validate inputs
        float sengeAntal;
        if (!float.TryParse(inputSengeAntal, out sengeAntal) || sengeAntal <= 0)
        {
            Console.WriteLine("Ugyldigt Senge Antal");
            return;
        }

        float kvalitet;
        if (!float.TryParse(inputKvalitet, out kvalitet) || kvalitet <= 0)
        {
            Console.WriteLine("Ugyldig Kvalitet");
            return;
        }

        float pris;
        if (!float.TryParse(inputPris, out pris) || pris <= 0)
        {
            Console.WriteLine("Ugyldig Pris");
            return;
        }

        // Create the updated object
        Sommerhuse updatedSommerhus = new Sommerhuse(sengeAntal, kvalitet, pris);

        // Update in the database
        editFromDatabase.UpdateSommerhusInDatabase(sommerhusId, updatedSommerhus);
    }
    public void EditLejlighed()
    {
        EditFromDatabase editFromDatabase = new EditFromDatabase();

        Console.WriteLine("Rediger Lejlighed");

        Console.WriteLine("Indtast Lejlighed ID (for at finde den lejlighed, der skal redigeres): ");
        int lejlighedId = int.Parse(Console.ReadLine());

        // Fetch current values from the database
        Lejlheder existingLejlighed = editFromDatabase.FetchLejlighedFromDatabase(lejlighedId);

        if (existingLejlighed == null)
        {
            Console.WriteLine("Lejlighed med dette ID blev ikke fundet.");
            return;
        }

        // Prompt for new values
        Console.WriteLine($"Nuvarande Senge Antal: {existingLejlighed.Senge}. Indtast nyt Senge Antal: ");
        string inputSengeAntal = Console.ReadLine();
        if (string.IsNullOrEmpty(inputSengeAntal)) inputSengeAntal = existingLejlighed.Senge.ToString();

        Console.WriteLine($"Nuvarande Kvalitet: {existingLejlighed.Kvalitet}. Indtast ny Kvalitet: ");
        string inputKvalitet = Console.ReadLine();
        if (string.IsNullOrEmpty(inputKvalitet)) inputKvalitet = existingLejlighed.Kvalitet.ToString();

        Console.WriteLine($"Nuvarande Pris: {existingLejlighed.Price}. Indtast ny Pris: ");
        string inputPris = Console.ReadLine();
        if (string.IsNullOrEmpty(inputPris)) inputPris = existingLejlighed.Price.ToString();

        // Validate inputs
        float sengeAntal;
        if (!float.TryParse(inputSengeAntal, out sengeAntal) || sengeAntal <= 0)
        {
            Console.WriteLine("Ugyldigt Senge Antal");
            return;
        }

        float kvalitet;
        if (!float.TryParse(inputKvalitet, out kvalitet) || kvalitet <= 0)
        {
            Console.WriteLine("Ugyldig Kvalitet");
            return;
        }

        float pris;
        if (!float.TryParse(inputPris, out pris) || pris <= 0)
        {
            Console.WriteLine("Ugyldig Pris");
            return;
        }

        // Create the updated object
        Lejlheder updatedLejlighed = new Lejlheder(sengeAntal, kvalitet, pris);

        // Update in the database
        editFromDatabase.UpdateLejlighedInDatabase(lejlighedId, updatedLejlighed);
    }
}
