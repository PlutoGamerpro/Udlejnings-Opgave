using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Backend.MenuDisplayer;

public class Brugermenu
{
 
    // Class content goes here if needed.
    public void DisplayUserMenu()
    {
        // if user don't exist then have to create
        Console.WriteLine("Menu Pokemon Userapp");
        Console.WriteLine("1. Opret bruger");
        Console.WriteLine("2. Log ind");
        Console.WriteLine("3. Se Ledlige lejlheder / sommerhuse ");
        Console.WriteLine("4 Afslut programmet");
     

    }
    public void OperationManager()
    {

        while (true)
        { // program on loop-- never need to be false... 
            DisplayUserMenu();
            // if userenter one of the options below then exits the loop 
            string BrugerInput = Console.ReadLine();
            switch (BrugerInput)
            {
                case "1":  Console.WriteLine("OpretBruger"); break;
                case "2":  Console.WriteLine("Login ind"); break;
                case "3": Console.WriteLine("Se Ledlige lejlheder / sommerhuse"); break;
                case "4": Console.WriteLine("Afslutet Program"); Environment.Exit(0); break;

                default: Console.WriteLine("Vælg en af overstående muligheder"); break;

            }
        }

    }

    public void DisplayPokémonMuligheder()
    {
        Console.WriteLine("1: Oprettelse af ");
        Console.WriteLine("2: Redigering af ");
        Console.WriteLine("3:  ");
        Console.WriteLine("4: ");
        Console.WriteLine("5: ");
        Console.WriteLine("6: Tilbage til Startmenu");
        Console.WriteLine("7: Afslut programmet");

        Console.Write("Vælg Mulighed 1,2,3,4,5,6,7 : ");
    }
}
