using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udlejnings.Models;

public class Opsynsmænd
{
    public int Id { get; set; }
    public static int NextId = 1;
    public string Fornavn { get; set; }   
    public string Efternavn { get; set; }   

    public Opsynsmænd(string fornavn, string efternavn){
        Id = NextId++;
        Fornavn = fornavn;
        Efternavn = efternavn;
    }
}
