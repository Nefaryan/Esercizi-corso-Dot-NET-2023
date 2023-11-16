using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class EuroZoneState : EUState, IBCE
    {
        int _timeWhitEuro;
        public EuroZoneState(string name, string money,
            string banner, decimal expenses, string confine,
            int timeInEU, int population, int timeWhitEuro):base
            (name,money,banner,expenses,confine,timeInEU,population)
        {
            _timeWhitEuro = timeWhitEuro;
        }

        public int TimeWhitEuro { get => _timeWhitEuro; set => _timeWhitEuro = value; }

        public void adoptingEuro()
        {
            Console.WriteLine($"The state adopted the euro from {TimeWhitEuro} years ");
        }

    }
}
