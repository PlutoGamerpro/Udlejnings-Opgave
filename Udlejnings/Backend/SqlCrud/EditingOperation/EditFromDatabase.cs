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

            string query = "SELECT * FROM Sommerhuse WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Sommerhuse(
                            Convert.ToSingle(reader["SengeAntal"]),  // Corrected to float
                            Convert.ToSingle(reader["Kvalitet"]),    // Corrected to float
                             Convert.ToSingle(reader["Pris"])        // Assuming Pris is Decimal (or Convert.ToSingle for float)
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

            string query = "UPDATE Sommerhuse SET SengeAntal = @SengeAntal, Kvalitet = @Kvalitet, Pris = @Pris WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Ensure you're passing float (or decimal for price) values to SQL
                command.Parameters.AddWithValue("@SengeAntal", sommerhuse.Senge);
                command.Parameters.AddWithValue("@Kvalitet", sommerhuse.Kvalitet);
                command.Parameters.AddWithValue("@Pris", sommerhuse.Price);  // Assuming Price is float/decimal
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

    public void UpdateLejlighedInDatabase(int id, Lejlheder lejlighed)
    {
        string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE Lejlheder SET SengeAntal = @SengeAntal, Kvalitet = @Kvalitet, Pris = @Pris WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SengeAntal", lejlighed.Senge);
                command.Parameters.AddWithValue("@Kvalitet", lejlighed.Kvalitet);
                command.Parameters.AddWithValue("@Pris", lejlighed.Price);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Lejlighed blev opdateret i databasen.");
    }
}