using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Models;

public class Lejlheder
{

    public int Id { get; set; }
    public static int NextId = 1;
    public float Senge { get; set; }
    public float Kvalitet { get; set; }

    public float Price;

    // pris skal nok have sin egen klasse fordi den kan være 3 forskellige .... 

    public Lejlheder(float senge, float kvalitet, float price)
    {
        Id = NextId++;
        Senge = senge;
        Kvalitet = kvalitet;
        Price = price;

    }


}
