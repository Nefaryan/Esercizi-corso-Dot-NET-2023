using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateProject.entities.EU.Abstract;

namespace StateProject.entities.EU
{
    public class EURegione: EUPublicAdministration
    {
        string _name;
        private List<EUProvincia> _provinciaList;
        GeographicArea _geographicArea;
        EUState state;

        public EURegione(string name)
        {
            _name = name;
            _provinciaList = new List<EUProvincia>();
        }

        public string Name { get => _name; set => _name = value; }
        public List<EUProvincia> ProvinciaList { get => _provinciaList; set => _provinciaList = value; }
        public GeographicArea GeographicArea { get => _geographicArea; set => _geographicArea = value; }
        public EUState State { get => state; set => state = value; }

        public void AddProvincia(EUProvincia provincia)
        {
            provincia.Regione = this;
            _provinciaList.Add(provincia);
        }

        public void RemoveProvincia(EUProvincia provincia)
        {
            provincia.Regione = null;
            _provinciaList?.Remove(provincia);
        }


        public override void EducationalSystem(EUID eUID)
        { Console.WriteLine("Municipality's task"); }
        

        public override void HNS(EUID eUID)
        { Console.WriteLine("Municipality's task"); }
        

       
        public override void WellfareService(EUID eUID)
        { Console.WriteLine("Municipality's task"); }
        
    }
}
