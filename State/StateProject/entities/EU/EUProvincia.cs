using StateProject.entities.EU.Abstract;
using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities.EU
{
    public class EUProvincia : EUPublicAdministration
    {
        string _name;
        List<EUComune> _comunes;
        GeographicArea _geographicArea;
        EURegione regione;

        public EUProvincia(string name)
        {
            Name = name;
            _comunes = new List<EUComune>();
        }

        public string Name { get => _name; set => _name = value; }
        public GeographicArea GeographicArea { get => _geographicArea; set => _geographicArea = value; }
        public EURegione Regione { get => regione; set => regione = value; }

        public void AddCoumne(EUComune comune)
        {
            comune.Provincia = this;
            _comunes.Add(comune);
        }

        public void RemouveComune(EUComune comune)
        {
            comune.Provincia = null;
            _comunes.Remove(comune);
        }

        public override void EducationalSystem(EUID eUID)
        {
            Console.WriteLine("Municipality's task");
        }
        public override void HNS(EUID eUID) 
        {
            Console.WriteLine("Municipality's task");
        }
        public override void WellfareService(EUID eUID) 
        {
            Console.WriteLine("Municipality's task");
        }

    }
}
