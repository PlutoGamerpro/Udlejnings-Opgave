using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Backend.Bookings;
using Udlejnings.Backend.EditingLH;
using Udlejnings.Backend.Oprettelser.OprettelseHusLeligheder;
using Udlejnings.Backend.SqlCrud.GetOperation;
using Udlejnings.Backend.SqlCrud.InsertOperations;
using Udlejnings.Models;

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
                    case "3":  getFromDatabase.ShowPendingBookings(getFromDatabase); Console.WriteLine("Se Ledlige lejlheder / sommerhuse"); break;
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

            Console.WriteLine("6. Comfirm lån af Sommerhus / Lejlhed");

            Console.WriteLine("7. Tilbage til hovedmenu");
            Console.WriteLine("8. Afslut program");
        }

        public void AdminOperationManager(GetFromDatabase bookingSystem)
        {


            GetFromDatabase getFromDatabase = new GetFromDatabase();

            Edit_Sommerhus_Lejlhed edit_Sommerhus_Lejlhed = new Edit_Sommerhus_Lejlhed();

            Oprettelse_Af_Hus_Leligheder oprettelse_Af_Hus_Leligheder = new Oprettelse_Af_Hus_Leligheder();

            InsertToDatabase BookingSystem = new InsertToDatabase();
            GetFromDatabase getFromDatabase1 = new GetFromDatabase();
            Brugermenu brugermenu = new Brugermenu();

            while (true)
            { // program on loop-- never need to be false...
                
                AdminLoggedIn();
                Console.Write("Vælg Mulighed 1,2,3,4,5,6,7,8 : ");
                // if userenter one of the options below then exits the loop 

                string BrugerInput = Console.ReadLine();
                switch (BrugerInput)
                {
                    case "1": oprettelse_Af_Hus_Leligheder.Oprettelse_Af_Sommerhus(); Console.WriteLine("Opret Sommerhus"); break;
                    case "2": edit_Sommerhus_Lejlhed.EditOrDeleteSommerhus(); Console.WriteLine("Rediger Sommerhus / Delete"); break;
                    case "3": oprettelse_Af_Hus_Leligheder.Oprettelse_Af_Lelighed(); Console.WriteLine("Opret Lejlhed"); break;
                    case "4": edit_Sommerhus_Lejlhed.EditOrDeleteLejlhed(); Console.WriteLine("Rediger Lejlhed / Delete"); break;
                    case "5": getFromDatabase.FetchLejlhederFromDatabase(); getFromDatabase.FetchSommerhuseFromDatabase(); break;
                   // case "5": getFromDatabase.FetchLejlhederFromDatabase(); getFromDatabase.FetchSommerhuseFromDatabase(); Console.WriteLine("Se Ledige lejlheder / sommerhuse"); break;
                   // case "5": getFromDatabase.ShowPendingBookings(bookingSystem); Console.WriteLine(""); break;
                    case "6": getFromDatabase.ConfirmBooking(BookingSystem); Console.WriteLine("Comfirm lejlhed / sommerhus"); break;
                    case "7": brugermenu.OperationManager(); Console.WriteLine("Tilbage til hovedmenu"); break;
                    case "8": Console.WriteLine("Afslutet Program "); Environment.Exit(0); break;

                    default: Console.WriteLine("Vælg en af overstående muligheder"); break;

                }
            }

        }
        public void BrugerLoggedIn()
        {
            Console.WriteLine("Udlejnings MENU");

            Console.WriteLine("1. Lån Sommerhus / Lån Lejlhed");
            // stop lån 
            Console.WriteLine("3. Gå tilbage til hovedmenu");
            Console.WriteLine("4. Afslut program");
        }

        public void BrugerOperationManager()
        {
            InsertToDatabase insertToDatabase = new InsertToDatabase();

            Booking_Sommerhus_Lejlhed booking_Sommerhus_Lejlhed = new Booking_Sommerhus_Lejlhed();
            Brugermenu brugermenu = new Brugermenu();
            BrugerLejer currentUser = ObjektSaving.CurrentUser;

            while (true)
            { // program on loop-- never need to be false...
                
                BrugerLoggedIn();
                // if userenter one of the options below then exits the loop 
                Console.Write("Vælg Mulighed 1,2,3 : ");
                string BrugerInput = Console.ReadLine();
                switch (BrugerInput)
                {
                    case "1": booking_Sommerhus_Lejlhed.CreateBookingMenu(currentUser); Console.WriteLine("Lån Sommerhus / Lån Lejlhed"); break;
                    case "2": brugermenu.OperationManager();  Console.WriteLine("Gå tilbage til hovedmenu"); break;
                    case "3": Environment.Exit(0); Console.WriteLine("Afslut program"); break;
                    default: Console.WriteLine("Vælg en af overstående muligheder"); break;

                }
            }

        }

    }
}