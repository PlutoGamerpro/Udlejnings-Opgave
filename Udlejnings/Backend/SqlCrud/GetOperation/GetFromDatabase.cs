using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Models;
using Microsoft.Data.SqlClient;
using Udlejnings.Backend.SqlCrud.InsertOperations;  // Use this namespace instead

namespace Udlejnings.Backend.SqlCrud.GetOperation;

public class GetFromDatabase
{
    public List<Sommerhuse> SommerhusList = new List<Sommerhuse>();  // Make sure the list is initialized
    List<Områder> områderList = new List<Områder>();

    List<Lejlheder> lejlhederList = new List<Lejlheder>();
    string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";
    // Method to retrieve all Lejlheder from the database and display them
    public void FetchLejlhederFromDatabase()
    {


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT SengeAntal, Kvalitet, Pris FROM Lejlheder";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Lejlheder lejlhed = new Lejlheder
                    {
                        Senge = reader.GetFloat(0),
                        Kvalitet = reader.GetFloat(1),
                        Price = reader.GetFloat(2)
                    };
                    lejlhederList.Add(lejlhed);
                }
            }
        }

        Console.WriteLine("Lejlheder i databasen:");
        foreach (var lejlhed in lejlhederList)
        {
            Console.WriteLine($"Senge: {lejlhed.Senge}, Kvalitet: {lejlhed.Kvalitet}, Pris: {lejlhed.Price:C}");
        }
    }

    public void FetchSommerhuseFromDatabase()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT SengeAntal, Kvalitet, Pris FROM Sommerhuse";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Sommerhuse sommerhus = new Sommerhuse
                    {
                        Senge = reader.GetFloat(0),         // SengeAntal is a float
                        Kvalitet = reader.GetFloat(1),      // Kvalitet is a float
                        Price = reader.GetFloat(2)          // Pris is a float
                    };
                    SommerhusList.Add(sommerhus);
                }
            }
        }

        // Optional: Display all Sommerhuse records
        Console.WriteLine("Sommerhuse i databasen:");
        foreach (var sommerhus in SommerhusList)
        {
            Console.WriteLine($"Senge: {sommerhus.Senge}, Kvalitet: {sommerhus.Kvalitet}, Pris: {sommerhus.Price}");
        }
    }
    public void FetchOmråderFromDatabase()
    {

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // SQL query to fetch all records from the Områder table
            string query = "SELECT Id, OmrådeNavn FROM Områder";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Områder område = new Områder
                    {
                        Id = reader.GetInt32(0),  // Assuming Id is an integer
                        OmrådeNavn = reader.GetString(1)  // Assuming OmrådeNavn is a string
                    };
                    områderList.Add(område);
                }
            }
        }

        // Optional: Display all Områder records
        Console.WriteLine("Områder in the database:");
        foreach (var område in områderList)
        {
            Console.WriteLine($"Id: {område.Id}, OmrådeNavn: {område.OmrådeNavn}");
        }
    }

    public BrugerLejer FetchUserFromDatabase(string Fornavn)
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Query to fetch the user based on 'Fornavn'
            string query = "SELECT * FROM BrugerLejer WHERE Fornavn = @Fornavn";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Fornavn", Fornavn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())  // If the user is found with the matching 'Fornavn'
                    {
                        // Return a full BrugerLejer object with additional details
                        return new BrugerLejer
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Fornavn = reader["Fornavn"].ToString(),
                            Efternavn = reader["Efternavn"].ToString(),
                            Adgangskode = reader["Adgangskode"].ToString(),
                            Salt = reader["Salt"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                }
            }
        }
        return null;  // If no user with the given 'Fornavn' is found


    }
    public List<Booking> GetPendingBookings()
    {
        List<Booking> pendingBookings = new List<Booking>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Bookings WHERE Status = 'Pending'";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var booking = new Booking
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            SommerhusId = reader["SommerhusId"] as int?,
                            LejlighedId = reader["LejlighedId"] as int?,
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Status = reader["Status"].ToString()
                        };
                        pendingBookings.Add(booking);
                    }
                }
            }
        }

        return pendingBookings;
    }




    public void ShowPendingBookings(GetFromDatabase bookingSystem)
    {
        var pendingBookings = bookingSystem.GetPendingBookings();

        if (pendingBookings.Count == 0)
        {
            Console.WriteLine("No pending bookings.");
            return;
        }

        Console.WriteLine("Pending Bookings:");
        foreach (var booking in pendingBookings)
        {
            Console.WriteLine($"ID: {booking.Id}, UserID: {booking.UserId}, Start Date: {booking.StartDate.ToShortDateString()}, End Date: {booking.EndDate.ToShortDateString()}, Price: {booking.Price}, Status: {booking.Status}");
        }
    }

    // Confirm a Booking
    public void ConfirmBooking(InsertToDatabase bookingSystem)
    {
        Console.WriteLine("Enter the Booking ID to confirm:");
        int bookingId = Convert.ToInt32(Console.ReadLine());

        // Confirm the booking
        bookingSystem.ConfirmBooking(bookingId);
    }
}
