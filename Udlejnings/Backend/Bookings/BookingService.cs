using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Udlejnings.Backend.SqlCrud.GetOperation;
using Udlejnings.Backend.SqlCrud.InsertOperations;

namespace Udlejnings.Backend.Bookings;

public class BookingService
{
    private string connectionString = "Data Source=GH\\MSSQLSERVER01;Initial Catalog=UdlejningsDatabase;Integrated Security=True;Trust Server Certificate=True";


    public void CreateBooking(int brugerId, int? sommerhusId, int? lejlighedId, DateTime startDate, DateTime endDate, decimal price)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("INSERT INTO Bookings (BrugerId, SommerhusId, LejlighedId, StartDate, EndDate, Price, Status) VALUES (@BrugerId, @SommerhusId, @LejlighedId, @StartDate, @EndDate, @Price, @Status)", connection);
            command.Parameters.AddWithValue("@BrugerId", brugerId);
            command.Parameters.AddWithValue("@SommerhusId", sommerhusId ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LejlighedId", lejlighedId ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@StartDate", startDate);
            command.Parameters.AddWithValue("@EndDate", endDate);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@Status", "Pending");

            command.ExecuteNonQuery();
        }

    }
    
    /*
    public void ConfirmBookingByConsultant(int bookingId)
    {
        var currentUser = GetLoggedInUser();

        if (currentUser == null || currentUser.Role != "Konsulent")
        {
            throw new UnauthorizedAccessException("Kun en konsulent kan bekræfte denne booking.");
        }

        // Bekræft booking
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("UPDATE Bookings SET Status = 'Confirmed' WHERE Id = @BookingId", connection);
            command.Parameters.AddWithValue("@BookingId", bookingId);

            command.ExecuteNonQuery();
        }
    }
    */
}