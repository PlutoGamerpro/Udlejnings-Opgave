using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Models;

public class Prisseasoner 
{
    public Dictionary <string, float> PriceMapping = new Dictionary<string, float>
    {
        {"Super",6000},
        {"Høj", 5000},
        {"Mellem", 4000},
        {"Lav", 3000},

    };

}
