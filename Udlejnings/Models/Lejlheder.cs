using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Models;

public class Lejlheder
{

    public int Id { get; set; }
    public static int NextId = 1;
    public int Senge { get; set; }
    public double Kvalitet { get; set; }

    // pris skal nok have sin egen klasse fordi den kan være 3 forskellige .... 

    public Lejlheder(int id, int senge, double kvalitet)
    {
        Id = NextId++;
        Id = id;
        Senge = senge;
        Kvalitet = kvalitet;

    }


}
