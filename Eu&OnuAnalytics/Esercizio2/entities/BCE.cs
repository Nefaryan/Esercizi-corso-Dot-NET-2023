using Esercizio2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio2.entities
{
    public class BCE : ISpreadCalculator
    {
        public double TotalSpreadCalculator(EuroZoneCountry c1, EuroZoneCountry c2)
        {
            double c1SPread = c1.CalculateSpread();
            double c2SPread = c2.CalculateSpread();
            double TSpread = (c1SPread / c2SPread);
            return TSpread;
        }
    }
}
