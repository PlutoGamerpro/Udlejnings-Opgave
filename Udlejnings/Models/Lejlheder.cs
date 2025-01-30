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
    public float Price { get; set; }
    public int OmrådeId { get; set; }
    public string OmrådeNavn { get; set; }

    // pris skal nok have sin egen klasse fordi den kan være 3 forskellige .... 

    public Lejlheder(){}
    public Lejlheder(float senge, float kvalitet, float price, int områdeId, string områdenavn)
    {
        Id = NextId++;
        Senge = senge;
        Kvalitet = kvalitet;
        Price = price;
        OmrådeId = områdeId;
        OmrådeNavn = områdenavn;

    }


}
