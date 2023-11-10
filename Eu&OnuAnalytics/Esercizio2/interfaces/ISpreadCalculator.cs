using Esercizio2.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio2.interfaces
{
    public  interface ISpreadCalculator
    {
        double TotalSpreadCalculator(EuroZoneCountry c1, EuroZoneCountry c2);
    }
}
