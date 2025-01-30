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

            // Updated query to include OmrådeNavn using a JOIN between Lejlheder and Områder tables
            string query = "SELECT L.ID, L.SengeAntal, L.Kvalitet, L.Pris, O.OmrådeNavn FROM Lejlheder L " +
                           "JOIN Områder O ON L.OmrådeId = O.Id";  // Join with the Områder table to get OmrådeNavn

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
                        Price = (float)reader.GetDouble(3),         // Pris is a float
                        OmrådeNavn = reader.GetString(4)            // Fetch the OmrådeNavn (area name) from the joined table
                    };
                    lejlhederList.Add(lejlhed);
                }
            }
        }

        Console.WriteLine("Lejlheder i databasen:");
        foreach (var lejlhed in lejlhederList)
        {
            Console.WriteLine($"Id {lejlhed.Id}, Senge: {lejlhed.Senge}, Kvalitet: {lejlhed.Kvalitet}, Pris: {lejlhed.Price:C}, Område: {lejlhed.OmrådeNavn}");
        }
        Console.Write("PRES Any KEY to Continue: ");
        Console.ReadKey();
    }
    public void FetchSommerhuseFromDatabase()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Updated query to include OmrådeNavn using a JOIN between Sommerhuse and Områder tables
            string query = "SELECT S.ID, S.SengeAntal, S.Kvalitet, S.Pris, O.OmrådeNavn FROM Sommerhuse S " +
                           "JOIN Områder O ON S.OmrådeId = O.Id";  // Join with the Områder table to get OmrådeNavn

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
                        Price = (float)reader.GetDouble(3),         // Pris is a float
                        OmrådeNavn = reader.GetString(4)            // Fetch the OmrådeNavn (area name) from the joined table
                    };
                    SommerhusList.Add(sommerhus);
                }
            }
        }

        // Optional: Display all Sommerhuse records with OmrådeNavn
        Console.WriteLine("Sommerhuse i databasen:");
        foreach (var sommerhus in SommerhusList)
        {
            Console.WriteLine($"Id {sommerhus.Id}, Senge: {sommerhus.Senge}, Kvalitet: {sommerhus.Kvalitet}, Pris: {sommerhus.Price:C}, Område: {sommerhus.OmrådeNavn}");
        }
        
    }
    

    public List<Områder> FetchAvailableAreas()
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";
        List<Områder> områder = new List<Områder>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT ID, OmrådeNavn FROM Områder";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Områder område = new Områder
                    {
                        Id = reader.GetInt32(0),
                        OmrådeNavn = reader.GetString(1)
                    };
                    områder.Add(område);
                }
            }
        }

        return områder;
    }
    /*
    // Optional: Display all Områder records
    Console.WriteLine("Områder in the database:");
    foreach (var område in områderList)
    {
        Console.WriteLine($"Id: {område.Id}, OmrådeNavn: {område.OmrådeNavn}");
    }
    */



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

            // Modified query to include OmrådeId for both Sommerhus and Lejlighed
            string query = @"
            SELECT B.Id, B.BrugerId, B.SommerhusId, B.LejlighedId, B.StartDate, B.EndDate, B.Price, B.Status, 
                   S.OmrådeId AS SommerhusOmrådeId, L.OmrådeId AS LejlighedOmrådeId
            FROM Bookings B
            LEFT JOIN Sommerhuse S ON B.SommerhusId = S.Id
            LEFT JOIN Lejlheder L ON B.LejlighedId = L.Id
            WHERE B.Status IS NULL";  // Only bookings that are pending (null status)

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int bookingId = reader.GetInt32(0);
                        int brugerId = reader.GetInt32(1);
                        int? sommerhusId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2); // Handle null SommerhusId
                        int? lejlighedId = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3); // Handle null LejlighedId
                        DateTime startDate = reader.GetDateTime(4);
                        DateTime endDate = reader.GetDateTime(5);
                        decimal price = reader.GetDecimal(6);
                        string status = reader.IsDBNull(7) ? "Pending" : reader.GetString(7);  // Handle null status

                        // Determine the OmrådeId based on whether it's Sommerhus or Lejlighed
                        int? områdeId = sommerhusId.HasValue ? reader.GetInt32(8) : (lejlighedId.HasValue ? reader.GetInt32(9) : (int?)null);

                        Console.WriteLine($"Booking ID: {bookingId}, Bruger ID: {brugerId}, Start Date: {startDate.ToShortDateString()}, " +
                                          $"End Date: {endDate.ToShortDateString()}, Price: {price:C}, Status: {status}, " +
                                          $"OmrådeId: {områdeId}");
                    }
                }
            }
        }
    }

    public string FetchOmrådeNameById(int områdeId)
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";
        string områdeNavn = string.Empty;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT OmrådeNavn FROM Områder WHERE Id = @OmrådeId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OmrådeId", områdeId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        områdeNavn = reader.GetString(0);
                    }
                }
            }
        }

        return områdeNavn;

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

