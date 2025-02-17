using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Backend.SqlCrud.GetOperation;
using Udlejnings.Backend.SqlCrud.InsertOperations;
using Udlejnings.Models;

namespace Udlejnings.Backend.Bookings;

public class Booking_Sommerhus_Lejlhed
{
    public void CreateBookingMenu(BrugerLejer loggedInUser)
    {
        if (loggedInUser == null)
        {
            Console.WriteLine("You must be logged in to make a booking.");
            return;
        }

        // Ask user for booking details (like Sommerhus or Lejlighed)
        Console.WriteLine("Select a property to book:");
        Console.WriteLine("1. Sommerhus");
        Console.WriteLine("2. Lejlighed");
        Console.Write("Input 1 / 2: ");
        int propertyChoice = Convert.ToInt32(Console.ReadLine());

        int? sommerhusId = null;
        int? lejlighedId = null;

        GetFromDatabase getFromDatabase = new GetFromDatabase();
        getFromDatabase.FetchSommerhuseFromDatabase();
        

        if (propertyChoice == 1)
        {
            Console.Write("Enter Sommerhus ID: ");
            sommerhusId = Convert.ToInt32(Console.ReadLine());
        }
        else if (propertyChoice == 2)
        {
            Console.Write("Enter Lejlighed ID:");
            lejlighedId = Convert.ToInt32(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Console.Write("Enter Start Date (yyyy-MM-dd): ");
        DateTime startDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter End Date (yyyy-MM-dd):");
        DateTime endDate = DateTime.Parse(Console.ReadLine());


        // error ...
        Console.Write("Enter Price :");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        InsertToDatabase insertToDatabase = new InsertToDatabase();
        // Now call your booking method with the logged-in user ID
        insertToDatabase.CreateBooking(loggedInUser.Id, sommerhusId, lejlighedId, startDate, endDate, price);
    }
}
