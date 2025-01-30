using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Models;

public class Prisseasoner 
{
    public Dictionary <string, float> PriceMapping = new Dictionary<string, float>
    {
        {"super",6000},
        {"hoj", 5000},
        {"mellem", 4000},
        {"lav", 3000},

    };

}
