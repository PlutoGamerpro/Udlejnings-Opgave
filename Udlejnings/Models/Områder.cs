using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Models;

public class Områder
{
    public int Id { get; set; }
    public static int NextId = 1;
    public string OmrådeNavn { get; set; }

    public Områder(){}

    public Områder(string Områdenavn)
    {
        OmrådeNavn = Områdenavn;
        Id = NextId++;
    }
}
