
using System;
using Udlejnings.Backend.MenuDisplayer;


namespace Udlejnings.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Brugermenu brugermenu = new Brugermenu();
            brugermenu.DisplayUserMenu();
        }
    }
}
