using Esercizio2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio2.entities
{
    public class EUCountry : Country
    {
        int _numberOfCitizen;
        int _timeInEU;

        public EUCountry(string name, int numberOfCitizen, int timeInEU):base(name)
        {
            numberOfCitizen = _numberOfCitizen;
            timeInEU = _timeInEU;
        }

        public int NumberOfCitizen
        {
            get { return _numberOfCitizen; }
            set { _numberOfCitizen = value;}
        }

        public int TimeInEu { 
            get { return _timeInEU; } 
            set { _timeInEU = value;} 
        }

    }
}
