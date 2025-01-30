using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Udlejnings.Models;  // Use this namespace instead

namespace Udlejnings.Backend.SqlCrud.EditingOperation;

public class EditFromDatabase
{
    public Sommerhuse FetchSommerhusFromDatabase(int id)
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Modified query to join the Sommerhuse table with the Områder table and fetch OmrådeId and OmrådeNavn
            string query = @"
            SELECT s.SengeAntal, s.Kvalitet, s.Pris, s.OmrådeId, o.OmrådeNavn
            FROM Sommerhuse s
            JOIN Områder o ON s.OmrådeId = o.Id
            WHERE s.Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Fetch data from the reader and return a new Sommerhuse object with both OmrådeId and OmrådeNavn
                        return new Sommerhuse(
                            Convert.ToSingle(reader["SengeAntal"]),  // Corrected to float
                            Convert.ToSingle(reader["Kvalitet"]),    // Corrected to float
                            Convert.ToSingle(reader["Pris"]),        // Corrected to float
                            Convert.ToInt32(reader["OmrådeId"]),     // OmrådeId (foreign key)
                            reader["OmrådeNavn"].ToString()          // OmrådeNavn from the joined table
                        );
                    }
                }
            }
        }
        return null;
    }

    public void UpdateSommerhusInDatabase(int id, Sommerhuse sommerhuse)
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Updated query to also update OmrådeId
            string query = "UPDATE Sommerhuse SET SengeAntal = @SengeAntal, Kvalitet = @Kvalitet, Pris = @Pris, OmrådeId = @OmrådeId WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters for the query
                command.Parameters.AddWithValue("@SengeAntal", sommerhuse.Senge);
                command.Parameters.AddWithValue("@Kvalitet", sommerhuse.Kvalitet);
                command.Parameters.AddWithValue("@Pris", sommerhuse.Price);
                command.Parameters.AddWithValue("@OmrådeId", sommerhuse.OmrådeId);  // Add OmrådeId to update
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Sommerhus blev opdateret i databasen.");
    }


    public Lejlheder FetchLejlighedFromDatabase(int id)
    {
        // Replace with actual database logic to fetch the Lejlighed by ID
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Modify the query to also fetch the OmrådeId and OmrådeNavn by joining with the Områder table
            string query = @"
            SELECT l.SengeAntal, l.Kvalitet, l.Pris, l.OmrådeId, o.OmrådeNavn 
            FROM Lejlheder l
            JOIN Områder o ON l.OmrådeId = o.Id
            WHERE l.Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Fetch data from the reader and return a new Lejlheder object with both OmrådeId and OmrådeNavn
                        return new Lejlheder(
                            Convert.ToSingle(reader["SengeAntal"]),  // Corrected to float
                            Convert.ToSingle(reader["Kvalitet"]),    // Corrected to float
                            Convert.ToSingle(reader["Pris"]),        // Corrected to float
                            Convert.ToInt32(reader["OmrådeId"]),     // OmrådeId (foreign key)
                            reader["OmrådeNavn"].ToString()          // OmrådeNavn from the joined table
                        );
                    }
                }
            }
        }
        return null;
    }

    /*
        public Lejlheder FetchLejlighedFromDatabase(int id)
        {
            // Replace with actual database logic to fetch the Lejlighed by ID
            string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Lejlheder WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Lejlheder(
                          Convert.ToSingle(reader["SengeAntal"]),  // Corrected to float
                          Convert.ToSingle(reader["Kvalitet"]),    // Corrected to float
                          Convert.ToSingle(reader["Pris"])         // Corrected to float
                      );
                        }
                    }
                }
            }
            return null;
        }
        */

    public void UpdateLejlighedInDatabase(int id, Lejlheder lejlighed)
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Updated query to also update OmrådeId
            string query = "UPDATE Lejlheder SET SengeAntal = @SengeAntal, Kvalitet = @Kvalitet, Pris = @Pris, OmrådeId = @OmrådeId WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Adding parameters to the SQL query
                command.Parameters.AddWithValue("@SengeAntal", lejlighed.Senge);
                command.Parameters.AddWithValue("@Kvalitet", lejlighed.Kvalitet);
                command.Parameters.AddWithValue("@Pris", lejlighed.Price);
                command.Parameters.AddWithValue("@OmrådeId", lejlighed.OmrådeId);  // Add OmrådeId parameter
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Lejlighed blev opdateret i databasen.");
    }
}