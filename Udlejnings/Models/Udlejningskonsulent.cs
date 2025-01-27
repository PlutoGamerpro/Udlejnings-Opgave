using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Models;

public class Udlejningskonsulent
{
    public int Id { get; set; }
    public static int NextId = 1;
    public string FirstName { get; set; }
    public string LastName { get; set; }


    public Udlejningskonsulent(string Firstname, string Lastname)
    {
        Id = NextId++;
        FirstName = Firstname;
        LastName = Lastname;  
    }
}
