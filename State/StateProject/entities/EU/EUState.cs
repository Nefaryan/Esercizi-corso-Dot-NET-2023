using StateProject.entities.EU;
using StateProject.interfaces.EUInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class EUState: State, IEUAdministrativeEntity
    {
        int _timeInEU;
        int _population;
        EURegione[] _regioni;   
       
     
        

        public EUState(string name, string money,
            string banner, decimal expenses, string confine,
            int timeInEU, int population): base(name,money,banner,
                expenses, confine)
        {
            _timeInEU = timeInEU;
            _population = population;
            _regioni = new EURegione[0];
            

        }

        public int TimeInEU { get => _timeInEU; set => _timeInEU = value; }
        public int Population { get => _population; set => _population = value; }
        public EURegione[] Regioni { get => _regioni; set => _regioni = value; }

        public void AddRegion(EURegione region)
        {
            Array.Resize(ref _regioni, _regioni.Length + 1);
            region.State = this;
            _regioni[_regioni.Length - 1] = region;
        }

        public void RemoveRegione(EURegione region)
        {
            _regioni = _regioni.Where(r => r != region).ToArray();
            region.State = null;
        }

        public void EducationalSystem()
        {
            Console.WriteLine("");
        }
        public void HNS()
        {
            Console.WriteLine("");
        }
        public void LawSystem()
        {
            Console.WriteLine("");
        }
        public void WellfareService()
        {
            Console.WriteLine("");
        }
        public void BoarderRedefinition(State destionation)
        {
            throw new NotImplementedException();
        }
    }
}
