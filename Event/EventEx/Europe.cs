using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEx
{
    public class Europe
    {
        private int positive;
        private static List<Country> countryList = new List<Country>();

        public int Positive => positive;

        public void AddCountry(Country country)
        {
            countryList.Add(country);
            country.PositiveChange += CalculatePositive; 
            CalculatePositive(this, new CovidPositiveEventArgs(country.Positive)); 
        }

        // Metodo per gestire l'evento PositiveChange di ciascun paese
        private void CalculatePositive(object sender, CovidPositiveEventArgs e)
        {
            positive = countryList.Sum(x => x.Positive);
            Console.WriteLine($"Totale positivi a livello europeo: {positive}");
        }
    }
}
