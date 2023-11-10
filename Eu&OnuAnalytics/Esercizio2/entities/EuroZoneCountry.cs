using Esercizio2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio2.entities
{
    public class EuroZoneCountry : Country
    {
        double _gdp;
        double _debt;

        public EuroZoneCountry( string name, double gdp, double debt):
            base(name)
        {
            _gdp = gdp;
            _debt = debt;
        }

        public double GDP
        {
            get { return _gdp; }
            set { _gdp = value; }
        }
        public double Debt
        {
            get { return _debt; }  
            set { _debt = value; }
        }

        public override double CalculateSpread()
        {
            double spreadMulti = 0.314;
            double spread = (GDP/Debt) * spreadMulti;

            return spread;
        }
    }
}
