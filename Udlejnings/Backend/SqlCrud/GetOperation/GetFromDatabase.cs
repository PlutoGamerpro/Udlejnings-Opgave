using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Models;
using Microsoft.Data.SqlClient;  // Use this namespace instead

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
}
