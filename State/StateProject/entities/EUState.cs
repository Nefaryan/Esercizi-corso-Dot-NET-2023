using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class EUState: State, IEuropeanUnion
    {
        int _timeInEU;
        int _population;

        public EUState(string name, string money,
            string banner, decimal expenses, string confine,
            int timeInEU, int population): base(name,money,banner,
                expenses, confine)
        {
            _timeInEU = timeInEU;
            _population = population;
        }

        public int TimeInEU { get => _timeInEU; set => _timeInEU = value; }
        public int Population { get => _population; set => _population = value; }

        public void CostitutionIntegration()
        {
            Console.WriteLine("OK");
        }

        public void EMA()
        {
            Console.WriteLine("EMA OK");
        }

        public void Enter()
        {
            Console.WriteLine($"The state {Name} enter in EU");
        }

        public void HumanRightTribunal()
        {
            Console.WriteLine("Your state respect human right");
        }

    }
}
