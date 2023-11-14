using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class Provincia : IAdministrativeEntity
    {
        string _name;
        List<Comune> _comunes;
        GeographicArea _geographicArea;
        Regione regione;

        public Provincia(string name)
        {
            Name = name;
            _comunes = new List<Comune>();
        }

        public string Name { get => _name; set => _name = value; }
        public GeographicArea GeographicArea { get => _geographicArea; set => _geographicArea = value; }
        public Regione Regione { get => regione; set => regione = value; }

        public void AddCoumne(Comune comune)
        { 
            comune.Provincia = this;
            _comunes.Add(comune);
        
        }

        public void RemouveComune(Comune comune) 
        {
            comune.Provincia = null;
            _comunes.Remove(comune);
        }
    }
}
