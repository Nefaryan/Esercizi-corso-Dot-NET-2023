using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio2.entities
{
    public class ONUCountry : Country
    {
        int _numberOfCitizen;
        int _timeInONU;

        public ONUCountry (string name, int citizen, int year): base(name)
        {
            _numberOfCitizen = citizen;
            _timeInONU = year;
        }

        public int NumberOfCitizen
        {
            get { return _numberOfCitizen; }
            set { _numberOfCitizen = value; }
        }

        public int TimeInONU
        {
            get { return _timeInONU; }
            set { _timeInONU = value;}
        }



    }
}
