using StateProject.entities.EU;
using StateProject.interfaces.EUInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class EUState: State, IEUAdministrativeEntity
    {
        int _timeInEU;
        int _population;
        List<EURegione> _regions;
        

        public EUState(string name, string money,
            string banner, decimal expenses, string confine,
            int timeInEU, int population): base(name,money,banner,
                expenses, confine)
        {
            _timeInEU = timeInEU;
            _population = population;
            _regions = new List<EURegione>();

        }

        public int TimeInEU { get => _timeInEU; set => _timeInEU = value; }
        public int Population { get => _population; set => _population = value; }

        public void AddRegions(EURegione region)
        {
            region.State = this;
            _regions.Add(region);

        }
        public void RemoveRegions(EURegione region)
        {
            region.State = null;
            _regions.Remove(region);
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
