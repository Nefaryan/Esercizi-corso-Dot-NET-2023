using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class Regione
    {
        string _name;
        private List<Provincia> _provinciaList;
        GeographicArea _geographicArea;

        public Regione(string name)
        {
            _name = name;
            _provinciaList = new List<Provincia>();
        }

        public string Name { get => _name; set => _name = value; }
        public List<Provincia> ProvinciaList { get => _provinciaList; set => _provinciaList = value; }
        public GeographicArea GeographicArea { get => _geographicArea; set => _geographicArea = value; }


        public void AddProvincia(Provincia provincia) 
        {
            provincia.Regione = this;
            _provinciaList.Add(provincia);
        
        }

        public void RemoveProvincia(Provincia provincia)
        {
            provincia.Regione = null;
            _provinciaList?.Remove(provincia);

        }
    }
}
