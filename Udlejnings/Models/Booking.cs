using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Models;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? SommerhusId { get; set; }
    public int? LejlighedId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }  // "Pending" or "Confirmed"
}
