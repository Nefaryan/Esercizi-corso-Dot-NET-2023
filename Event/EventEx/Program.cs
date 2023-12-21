using System;
using System.Collections.Generic;

namespace EventEx
{
    public class Program
    {
       static void Main(string[] args)
        {
            Country italy = new Country { Name = "Italy" };
            Country spain = new Country { Name = "Spain" };

            Europe europe = new Europe();
            europe.AddCountry(italy);
            europe.AddCountry(spain);

       
            italy.Positive = 1000;
            spain.Positive = 800;
       }         
    }
}
