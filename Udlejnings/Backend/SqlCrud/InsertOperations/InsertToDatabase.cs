using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Models;
using Microsoft.Data.SqlClient;  // Use this namespace instead


namespace Udlejnings.Backend.SqlCrud.InsertOperations;

public class InsertToDatabase
{
    public void InsertLejlhedToDatabase(Lejlheder lejlheder)
    {
        // Replace with your actual database connection string
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Lejlheder (SengeAntal, Kvalitet, Pris) VALUES (@SengeAntal, @Kvalitet, @Pris)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters to the query
                command.Parameters.AddWithValue("@SengeAntal", lejlheder.Senge);
                command.Parameters.AddWithValue("@Kvalitet", lejlheder.Kvalitet);
                command.Parameters.AddWithValue("@Pris", lejlheder.Price);

                // Execute the query
                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Lejlighed blev oprettet i databasen.");
    }

    public void InsertSommerhusToDatabase(Sommerhuse sommerhuse)
    {
        // Replace with your actual database connection string
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Sommerhuse (SengeAntal, Kvalitet, Pris) VALUES (@SengeAntal, @Kvalitet, @Pris)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters to the query
                command.Parameters.AddWithValue("@SengeAntal", sommerhuse.Senge);
                command.Parameters.AddWithValue("@Kvalitet", sommerhuse.Kvalitet);
                command.Parameters.AddWithValue("@Pris", sommerhuse.Price);

                // Execute the query
                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Sommerhus blev oprettet i databasen.");
    }
    public void InsertBrugerLejerToDatabase(BrugerLejer brugerLejer)
    {
        // Replace with your actual database connection string
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO BrugerLejer (Fornavn, Efternavn , Adgangskode) VALUES (@SengeAntal, @Kvalitet, @Adgangskode)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters to the query
                command.Parameters.AddWithValue("@Fornavn", brugerLejer.Fornavn);
                command.Parameters.AddWithValue("@Efternavn ", brugerLejer.Efternavn);
                command.Parameters.AddWithValue("@Adgangskode", brugerLejer.Adgangskode);

                // Execute the query
                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Brugerlej blev oprettet i databasen.");
    }

    public void InsertOmråderToDatabase(Områder områder)
    {
        // Replace with your actual database connection string
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Områder (OmrådeNavn) VALUES (@OmrådeNavn)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters to the query
                command.Parameters.AddWithValue("@OmrådeNavn", områder.OmrådeNavn);

                // Execute the query
                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Område blev oprettet i databasen.");
    }

    public void InsertOpsynsmændToDatabase(Opsynsmænd opsynsmænd)
    {
        // Replace with your actual database connection string
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Opsynsmænd (Fornavn,Efternavn) VALUES (@Fornavn, @Efternavn)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters to the query
                command.Parameters.AddWithValue("@Fornavn", opsynsmænd.Fornavn);
                command.Parameters.AddWithValue("@Efternavn ", opsynsmænd.Efternavn);
                // Execute the query
                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Opsynsmænd blev oprettet i databasen.");
    }

    public void InsertUdlejerToDatabase(Udlejer udlejer)
    {
        // Replace with your actual database connection string
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Udlejer (Fornavn,Efternavn) VALUES (@Fornavn, @Efternavn)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters to the query
                command.Parameters.AddWithValue("@Fornavn", udlejer.Fornavn);
                command.Parameters.AddWithValue("@Efternavn ", udlejer.Efternavn);
                // Execute the query
                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Opsynsmænd blev oprettet i databasen.");
    }
    public void CreateBooking(int userId, int? sommerhusId, int? lejlighedId, DateTime startDate, DateTime endDate, decimal price)
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Construct SQL query based on whether the user is booking a Sommerhus or a Lejlighed
            string query = string.Empty;
  

            if (sommerhusId.HasValue)
            {
                query = "INSERT INTO Bookings (BrugerId, SommerhusId, StartDate, EndDate, Price) VALUES (@BrugerId, @SommerhusId, @StartDate, @EndDate, @Price)";
            }
            else if (lejlighedId.HasValue)
            {
                query = "INSERT INTO Bookings (BrugerId, LejlighedId, StartDate, EndDate, Price) VALUES (@BrugerId, @LejlighedId, @StartDate, @EndDate, @Price)";
            }

            // Check if a valid query was built
            if (string.IsNullOrEmpty(query))
            {
                Console.WriteLine("Invalid booking data.");
                return;
            }

            // Execute the query to insert the booking
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@BrugerId", userId);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@Price", price);

                // Add parameters for Sommerhus or Lejlighed depending on what was chosen
                if (sommerhusId.HasValue)
                {
                    command.Parameters.AddWithValue("@SommerhusId", sommerhusId.Value);
                }
                else if (lejlighedId.HasValue)
                {
                    command.Parameters.AddWithValue("@LejlighedId", lejlighedId.Value);
                }

                // Execute the command
                command.ExecuteNonQuery();
                Console.WriteLine("Booking successfully created.");
            }
        }

    }
    public void ConfirmBooking(int bookingId)
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE Bookings SET Status = 'Confirmed' WHERE Id = @BookingId AND Status = 'Pending'";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@BookingId", bookingId);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Booking confirmed successfully.");
                    Console.WriteLine("Pres ANY Key to Continue: ");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Booking could not be confirmed (it may have already been confirmed or not exist).");
                }
            }
        }
    }
    
}