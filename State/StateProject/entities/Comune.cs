using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class Comune : IAdministrativeEntity
    {
        string _name;
        List<Cittadino> _list;
        Provincia _provincia;
        GeographicArea _geographicArea;
        public Comune(string name) 
        {
            Name = name;
            _list = new List<Cittadino>();
        }

        public string Name { get => _name; set => _name = value; }
        public Provincia Provincia { get => _provincia; set => _provincia = value; }
        public GeographicArea GeographicArea { get => _geographicArea; set => _geographicArea = value; }

        public void AddCittadino(Cittadino cittadino) 
        {
            cittadino.Comune = this;
            _list.Add(cittadino);
        }
        public void RemoveCittadino(Cittadino cittadino) 
        {
            cittadino.Comune = null;
            _list.Remove(cittadino);
        }

    }
}
