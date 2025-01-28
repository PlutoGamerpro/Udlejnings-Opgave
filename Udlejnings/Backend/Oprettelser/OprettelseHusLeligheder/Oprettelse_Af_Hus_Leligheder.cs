using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Models;

namespace Udlejnings.Backend.Oprettelser.OprettelseHusLeligheder;

public class Oprettelse_Af_Hus_Leligheder
{
    
    public void Oprettelse_Af_Sommerhus()
    {
        
        Console.WriteLine("Senge Antal: ");
        string InputSengeAntal = Console.ReadLine();

        Console.WriteLine("Kvalitet: ");
        string InputKvalitet = Console.ReadLine();

        bool KeepRuning = true;
        float OkInputKvalitet = 0;
        float OKInputSengeAntal = 0;
        double price = 0;
        bool PrisKlasseInputValid = false;

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
            Console.WriteLine("Vælg pris klassen : Super, Høj, Mellem, Lav");
            string VælgPrisKlasse = Console.ReadLine();
            switch (VælgPrisKlasse)
            {
                case "Super": PrisKlasseInputValid = true; break;
                case "Høj": PrisKlasseInputValid = true; break;
                case "Mellem": PrisKlasseInputValid = true; break;
                case "Lav": PrisKlasseInputValid = true; break;
                default: Console.WriteLine("Inputet er invalid"); break;
            }
        }
    
    Sommerhuse sommerhuse = new Sommerhuse(OKInputSengeAntal, OkInputKvalitet);
    // penge season skal komme ind her og blive support om instance klassen
    // mangler at tilføje så penge option er en mulighed.....
     
    }
    public void Oprettelse_Af_Lelighed()
    {
        Prisseasoner prisseasoner = new Prisseasoner();

        Console.WriteLine("Senge Antal: ");
        string InputSengeAntal = Console.ReadLine();

        Console.WriteLine("Kvalitet: ");
        string InputKvalitet = Console.ReadLine();

        bool KeepRuning = true;
        float OkInputKvalitet = 0;
        float OKInputSengeAntal = 0;
        bool PrisKlasseInputValid = false;
        float price = 0;
        string VælgPrisKlasse ="";

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

        while (!PrisKlasseInputValid)
        {
            Console.WriteLine("Vælg pris klassen : Super, Høj, Mellem, Lav");
           VælgPrisKlasse = Console.ReadLine();

            if (prisseasoner.PriceMapping.ContainsKey(())){
                price = prisseasoner.PriceMapping[VælgPrisKlasse];
                PrisKlasseInputValid = true;
           } else { Console.WriteLine("Invalid input"); }
        }
        Console.WriteLine($"Du har valgt pris klasse: {VælgPrisKlasse}, og prisen er: {price} kr.");
        Lejlheder lejlheder = new Lejlheder(OKInputSengeAntal, OkInputKvalitet, price);

        
        // opret et opret af lelighed og få det tilføjes til database 


    }
}
