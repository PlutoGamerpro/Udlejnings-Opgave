using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Backend.EditingLH;
using Udlejnings.Backend.Oprettelser.OprettelseHusLeligheder;
using Udlejnings.Backend.SqlCrud.GetOperation;

namespace Udlejnings.Backend.MenuDisplayer
{



    public class Brugermenu
    {



        // Class content goes here if needed.
        public void DisplayUserMenu()
        {
            // if user don't exist then have to create
            Console.WriteLine("Udlejnings MENU");
            Console.WriteLine("1. Opret bruger");
            Console.WriteLine("2. Log ind");
            Console.WriteLine("3. Se Ledlige lejlheder / sommerhuse ");
            Console.WriteLine("4 Afslut programmet");


        }
        public void OperationManager()
        {
            BrugerOprettelse.BrugerOprettelse brugerOprettelse = new BrugerOprettelse.BrugerOprettelse();
            BrugerLogin.BrugerLogin brugerlogin = new BrugerLogin.BrugerLogin();
            GetFromDatabase getFromDatabase = new GetFromDatabase();

            while (true)
            { // program on loop-- never need to be false...
               
                DisplayUserMenu();
                Console.Write("Vælg Mulighed 1,2,3,4 : ");
                // if userenter one of the options below then exits the loop 
                string BrugerInput = Console.ReadLine();
                switch (BrugerInput)
                {
                    case "1": brugerOprettelse.CreateUser(); Console.WriteLine("OpretBruger"); break;
                    case "2": brugerlogin.CheckLoginInfo(); Console.WriteLine("Login ind"); break;
                    case "3": getFromDatabase.FetchLejlhederFromDatabase(); getFromDatabase.FetchSommerhuseFromDatabase(); Console.WriteLine("Se Ledlige lejlheder / sommerhuse"); break;
                    case "4": Console.WriteLine("Afslutet Program"); Environment.Exit(0); break;

                    default: Console.WriteLine("Vælg en af overstående muligheder"); break;

                }
            }

        }

        public void AdminLoggedIn()
        {
            Console.WriteLine("Udlejnings MENU");

            Console.WriteLine("1. Opret Sommerhus");
            Console.WriteLine("2. Rediger Sommerhus");

            
            Console.WriteLine("3. Opret Lejlhed");
            Console.WriteLine("4. Rediger Lejlhed");

            Console.WriteLine("5. Se Ledlige lejlheder / sommerhuse ");
            Console.WriteLine("6. Tilbage til hovedmenu");
            Console.WriteLine("7. Afslut program");
        }

        public void AdminOperationManager()
        {


            GetFromDatabase getFromDatabase = new GetFromDatabase();

            Edit_Sommerhus_Lejlhed edit_Sommerhus_Lejlhed = new Edit_Sommerhus_Lejlhed();

            Oprettelse_Af_Hus_Leligheder oprettelse_Af_Hus_Leligheder = new Oprettelse_Af_Hus_Leligheder();

            while (true)
            { // program on loop-- never need to be false...
                
                AdminLoggedIn();
                Console.Write("Vælg Mulighed 1,2,3,4,5,6 : ");
                // if userenter one of the options below then exits the loop 

                string BrugerInput = Console.ReadLine();
                switch (BrugerInput)
                {
                    case "1": oprettelse_Af_Hus_Leligheder.Oprettelse_Af_Sommerhus(); Console.WriteLine("Opret Sommerhus"); break;
                    case "2": edit_Sommerhus_Lejlhed.EditSommerhus(); Console.WriteLine("Rediger Sommerhus"); break;
                    case "3": oprettelse_Af_Hus_Leligheder.Oprettelse_Af_Lelighed(); Console.WriteLine("Opret Lejlhed"); break;
                    case "4": edit_Sommerhus_Lejlhed.EditLejlighed(); Console.WriteLine("Rediger Lejlhed"); break;
                    case "5": getFromDatabase.FetchLejlhederFromDatabase(); getFromDatabase.FetchSommerhuseFromDatabase(); Console.WriteLine("Se Ledige lejlheder / sommerhuse"); break;
                    case "6": Console.WriteLine("Tilbage til hovedmenu"); break;
                    case "7": Console.WriteLine("Afslutet Program "); Environment.Exit(0); break;

                    default: Console.WriteLine("Vælg en af overstående muligheder"); break;

                }
            }

        }
        public void BrugerLoggedIn()
        {
            Console.WriteLine("Udlejnings MENU");

            Console.WriteLine("1. Lån Sommerhus");
            // stop lån 
            Console.WriteLine("2. Lån Lejlhed");
            Console.WriteLine("3. Gå tilbage til hovedmenu");
            Console.WriteLine("4. Afslut program");
        }

        public void BrugerOperationManager()
        {

            while (true)
            { // program on loop-- never need to be false...
                Console.Write("Vælg Mulighed 1,2,3 : ");
                BrugerLoggedIn();
                // if userenter one of the options below then exits the loop 

                string BrugerInput = Console.ReadLine();
                switch (BrugerInput)
                {
                    case "1": Console.WriteLine("Lån Sommerhus"); break;
                    case "2": Console.WriteLine("Lån Lejlhed"); break;
                    case "3": Console.WriteLine("Gå tilbage til hovedmenu"); break;
                    case "4": Console.WriteLine("Afslut program"); break;
                    default: Console.WriteLine("Vælg en af overstående muligheder"); break;

                }
            }

        }

    }
}