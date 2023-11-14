using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class NatoState: State,INATO
    {
        int _timeInNato;
        int _population;

        public NatoState(string name, string money,
            string banner, decimal expenses, string confine,
            int timeInNato, int population): base(name, money, banner,
                expenses,confine)
        {
            _timeInNato = timeInNato;
            _population = population;
        }

        public int TimeInNato { get => _timeInNato; set => _timeInNato = value; }
        public int Population { get => _population; set => _population = value; }

        public void MilitarySpending()
        {
            Console.WriteLine("Military Spending 2%");
        }

    }
}
