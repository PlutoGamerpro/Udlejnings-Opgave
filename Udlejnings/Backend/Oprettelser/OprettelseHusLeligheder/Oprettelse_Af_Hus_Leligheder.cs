using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Backend.Oprettelser.OprettelseHusLeligheder;

public class Oprettelse_Af_Hus_Leligheder
{
    public void Oprettelse_Af_Sommerhus()
    {

        Console.WriteLine("Senge Antal: ");
        string InputSengeAntal = Console.ReadLine();

        Console.WriteLine("Kvalitet: ");
        string InputKvalitet = Console.ReadLine();

        while (true)
        {
            if (double.TryParse(InputKvalitet, out double OkInputKvalitet))
            {
                if (OkInputKvalitet > 0 && OkInputKvalitet <= 10) { Console.WriteLine("Inputet er ok"); }
            }
            else { Console.WriteLine("Inputet er invalid (0 - 10 KVALITET)"); }
        }
        // penge season skal komme ind her og blive support om instance klassen


        // opret et objekt af sommerhus som skal t iæføjes til databasen.....

    }
    public void Oprettelse_Af_Lelighed()
    {

        string InputSengeAntal = Console.ReadLine();
        Console.WriteLine("Input Senge Antal: ");

        Console.WriteLine("Input Kvalitet: ");
        string InputKvalitet = Console.ReadLine();

        while (true)
        {
            if (double.TryParse(InputKvalitet, out double OkInputKvalitet))
            {
                if (OkInputKvalitet > 0 && OkInputKvalitet <= 10) { Console.WriteLine("Inputet er ok"); }
            }
            else { Console.WriteLine("Inputet er invalid (0 - 10 KVALITET)"); }
        }

        // penge season skal komme ind  her og blive support og instance klassen
        // opret et opret af lelighed og få det tilføjes til database 


    }
}
