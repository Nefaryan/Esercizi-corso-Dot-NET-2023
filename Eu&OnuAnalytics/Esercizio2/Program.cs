using Esercizio2.entities;
using System;

namespace Esercizio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BCE bCE = new BCE();


            Country country = new EUCountry("Italy", 600, 30);
            Country country2 = new ONUCountry("Germany", 300, 10);
            Country country3 = new DeathsentenceCountry("Texsas", true);

            EuroZoneCountry euZ1 = new EuroZoneCountry("France", 34.1, 11.1);
            EuroZoneCountry euZ2 = new EuroZoneCountry("Spain", 23.4, 20.2);

            Console.WriteLine("The spred differnce is: " + bCE.TotalSpreadCalculator(euZ1, euZ2));
            country.CheckHumanRights(country);
            country2.CheckHumanRights(country2);
            country3.CheckHumanRights(country3);
            
        }
    }
}
