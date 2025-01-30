using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Models;
using Microsoft.Data.SqlClient;
using Udlejnings.Backend.SqlCrud.InsertOperations;
using System.Data;  // Use this namespace instead

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

            // Fetch ID, SengeAntal, Kvalitet, and Pris from Lejlheder table
            string query = "SELECT ID, SengeAntal, Kvalitet, Pris FROM Lejlheder";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Lejlheder lejlhed = new Lejlheder
                    {
                        Id = reader.GetInt32(0),                    // Fetch the ID (first column)
                        Senge = (float)reader.GetDouble(1),         // Convert from double to float explicitly
                        Kvalitet = (float)reader.GetDouble(2),      // Convert from double to float explicitly
                        Price = (float)reader.GetDouble(3)          // Pris is a float
                    };
                    lejlhederList.Add(lejlhed);
                }
            }
        }

        Console.WriteLine("Lejlheder i databasen:");
        foreach (var lejlhed in lejlhederList)
        {
            Console.WriteLine($"Id {lejlhed.Id}, Senge: {lejlhed.Senge}, Kvalitet: {lejlhed.Kvalitet}, Pris: {lejlhed.Price:C}");
        }
    }
    public void FetchSommerhuseFromDatabase()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Fetch ID, SengeAntal, Kvalitet, and Pris from Sommerhuse table
            string query = "SELECT ID, SengeAntal, Kvalitet, Pris FROM Sommerhuse";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Sommerhuse sommerhus = new Sommerhuse
                    {
                        Id = reader.GetInt32(0),                    // Fetch the ID (first column)
                        Senge = (float)reader.GetDouble(1),         // Convert from double to float explicitly
                        Kvalitet = (float)reader.GetDouble(2),      // Convert from double to float explicitly
                        Price = (float)reader.GetDouble(3)          // Pris is a float
                    };
                    SommerhusList.Add(sommerhus);
                }
            }
        }

        // Optional: Display all Sommerhuse records
        Console.WriteLine("Sommerhuse i databasen:");
        foreach (var sommerhus in SommerhusList)
        {
            Console.WriteLine($"Id {sommerhus.Id}, Senge: {sommerhus.Senge}, Kvalitet: {sommerhus.Kvalitet}, Pris: {sommerhus.Price:C}");
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
    public void FetchPendingBookings()
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Modified query to fetch all bookings with a NULL status (still pending)
            string query = "SELECT Id, BrugerId, SommerhusId, LejlighedId, StartDate, EndDate, Price, Status " +
                           "FROM Bookings " +
                           "WHERE Status IS NULL";  // Only bookings that are pending (null status)

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int bookingId = reader.GetInt32(0);
                        DateTime startDate = reader.GetDateTime(4);
                        DateTime endDate = reader.GetDateTime(5);
                        decimal price = reader.GetDecimal(6);
                        string status = reader.IsDBNull(7) ? "Pending" : reader.GetString(7);  // Handle null status

                        Console.WriteLine($"Booking ID: {bookingId}, Start Date: {startDate.ToShortDateString()}, End Date: {endDate.ToShortDateString()}, Price: {price:C}, Status: {status}");
                    }
                }
            }
        }
    }

 
    // Confirm a Booking
    public void ConfirmBooking(InsertToDatabase bookingSystem)
    {
        GetFromDatabase getFromDatabase = new GetFromDatabase();

        FetchPendingBookings();

        Console.Write("Enter the Booking ID to confirm: ");
        int bookingId = Convert.ToInt32(Console.ReadLine());

        

        // Confirm the booking
        bookingSystem.ConfirmBooking(bookingId);

        Console.WriteLine("Pres KEY to Continue");
        Console.ReadKey();
    }
}
