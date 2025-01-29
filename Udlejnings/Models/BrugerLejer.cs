using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Udlejnings.Models;

public class BrugerLejer
{
    public int Id { get; set; }
    public int NextId = 1;
    public string Fornavn { get; set; }
    public string Efternavn { get; set; }
    public string Adgangskode { get; set; }
    public string Salt { get; set; }
    public string Role { get; internal set; }

    public BrugerLejer(){}
    public BrugerLejer(string fornavn, string efternavn, string adgangskode, string salt, string role)
    {
        Id = NextId++;
        Fornavn = fornavn;
        Efternavn = efternavn;
        Adgangskode = adgangskode;
        Salt = salt;
        Role = role;
    }
}
