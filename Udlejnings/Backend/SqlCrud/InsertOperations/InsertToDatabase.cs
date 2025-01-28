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


}