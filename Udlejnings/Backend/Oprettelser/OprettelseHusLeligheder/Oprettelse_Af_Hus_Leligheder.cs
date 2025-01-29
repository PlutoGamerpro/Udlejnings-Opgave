using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // if error set start value on values again 

        Console.Write("Senge Antal: ");
        string InputSengeAntal = Console.ReadLine();

        Console.Write("Kvalitet: ");
        string InputKvalitet = Console.ReadLine();

        

        while (KeepRuning)
        {
            if(float.TryParse(InputSengeAntal, out OKInputSengeAntal)){
                if(OKInputSengeAntal > 0 && OKInputSengeAntal <= 10){ Console.WriteLine("Inputet er ok"); }
                else{ Console.WriteLine("Inputet er invalid ( 0 - 10 SENGE)"); }
            }

            if (float.TryParse(InputKvalitet, out OkInputKvalitet))
            {
                if (OkInputKvalitet > 0 && OkInputKvalitet <= 10) { Console.WriteLine("Inputet er ok"); KeepRuning = false; }
            }
            else { Console.WriteLine("Inputet er invalid (0 - 10 KVALITET)"); }
        }
        // sender lav logik så bestemt uger har super pris lige meget hvad
        while (!PrisKlasseInputValid)
        {
            Console.Write("Vælg pris klassen : Super, Høj, Mellem, Lav: ");
            VælgPrisKlasse = Console.ReadLine();

            if (prisseasoner.PriceMapping.ContainsKey(VælgPrisKlasse))
            {
                price = prisseasoner.PriceMapping[VælgPrisKlasse];
                PrisKlasseInputValid = true;
            }
            else { Console.WriteLine("Invalid input Super, Høj, Mellem, Lav"); }
        }
        Console.WriteLine($"Du har valgt pris klasse: {VælgPrisKlasse}, og prisen er: {price} kr.");

        Sommerhuse sommerhuse = new Sommerhuse(OKInputSengeAntal, OkInputKvalitet, price);
        
        insertToDatabase.InsertSommerhusToDatabase(sommerhuse);

        Console.Write("PRES any KEY to Continue: ");
        Console.ReadKey();
        // penge season skal komme ind her og blive support om instance klassen
        // mangler at tilføje så penge option er en mulighed.....

    }
    public void Oprettelse_Af_Lelighed()
    {
        KeepRuning = true;
        OkInputKvalitet = 0;
        OKInputSengeAntal = 0;
        PrisKlasseInputValid = false;
        price = 0;
        VælgPrisKlasse = "";

        InsertToDatabase insertToDatabase = new InsertToDatabase();
        // if error set start value on values again 

        Prisseasoner prisseasoner = new Prisseasoner();

        Console.Write("Senge Antal: ");
        string InputSengeAntal = Console.ReadLine();

        Console.Write("Kvalitet: ");
        string InputKvalitet = Console.ReadLine();



        while (KeepRuning)
        {
            if (float.TryParse(InputSengeAntal, out OKInputSengeAntal))
            {
                if (OKInputSengeAntal > 0 && OKInputSengeAntal <= 10) { Console.WriteLine("Inputet er ok"); }
                else { Console.WriteLine("Inputet er invalid ( 0 - 10 SENGE)"); }
            }

            if (float.TryParse(InputKvalitet, out OkInputKvalitet))
            {
                if (OkInputKvalitet > 0 && OkInputKvalitet <= 10) { Console.WriteLine("Inputet er ok"); KeepRuning = false; }
            }
            else { Console.WriteLine("Inputet er invalid (0 - 10 KVALITET)"); }
        }
        // sender lav logik så bestemt uger har super pris lige meget hvad
        while (!PrisKlasseInputValid)
        {
            Console.Write("Vælg pris klassen : Super, Høj, Mellem, Lav: ");
            VælgPrisKlasse = Console.ReadLine();

            if (prisseasoner.PriceMapping.ContainsKey(VælgPrisKlasse))
            {
                price = prisseasoner.PriceMapping[VælgPrisKlasse];
                PrisKlasseInputValid = true;
            }
            else { Console.WriteLine("Invalid input Super, Høj, Mellem, Lav"); }
        }
        Console.WriteLine($"Du har valgt pris klasse: {VælgPrisKlasse}, og prisen er: {price} kr.");

        Lejlheder lejlhed = new Lejlheder(OKInputSengeAntal, OkInputKvalitet, price);

        insertToDatabase.InsertLejlhedToDatabase(lejlhed);

        Console.Write("PRES any KEY to Continue: ");
        Console.ReadKey();

    }
}
