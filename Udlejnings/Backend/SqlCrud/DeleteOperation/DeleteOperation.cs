using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Udlejnings.Backend.SqlCrud.DeleteOperation;

public class DeleteOperation
{
    string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";


    public void DeleteSommerhus(int sommerhusId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // SQL query to delete the Sommerhus based on the Id
            string query = "DELETE FROM Sommerhuse WHERE ID = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Use parameterized query to avoid SQL injection
                command.Parameters.AddWithValue("@Id", sommerhusId);

                // Execute the DELETE command
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Sommerhus with ID {sommerhusId} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Sommerhus with ID {sommerhusId} not found.");
                }
            }
        }
    }
    public void DeleteLejlhed(int lejlhedId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // SQL query to delete the Lejlhed based on the Id
            string query = "DELETE FROM Lejlheder WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Use parameterized query to avoid SQL injection
                command.Parameters.AddWithValue("@Id", lejlhedId);

                // Execute the DELETE command
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Lejlhed with ID {lejlhedId} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Lejlhed with ID {lejlhedId} not found.");
                }
            }
        }
    }
}
