using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class GeographicArea
    {
         string _name;
         string _position;

        List<State> _states;
        List<Regione> _regions;
        List<Provincia> _provincia;
        List<Comune> _comune;

        public string Name { get => _name; set => _name = value; }
        public string Position { get => _position; set => _position = value; }

        public GeographicArea(string name, string position)
        {
            _name = name;
            _position = position;
            _states = new List<State>();
            _regions = new List<Regione>();
            _provincia = new List<Provincia>();
            _comune = new List<Comune>();
        }

        public void AddState(State state)
        {
            state.Area = this;
            _states.Add(state);
        }
        public void RemoveState(State state)
        {
            state.Area = null;
            _states.Remove(state);
        }
        public void AddRegione(Regione regione) 
        {
            regione.GeographicArea = this;
            _regions.Add(regione);
        
        }
        public void RemoveRegione(Regione regione)
        {
            regione.GeographicArea = null;
            _regions.Remove(regione);
        }
        public void AddProvincia(Provincia provincia)
        {
            provincia.GeographicArea = this;
            _provincia.Add(provincia);
        }
        public void RemoveProvincia(Provincia provincia)
        {
            provincia.GeographicArea = null;
            _provincia.Remove(provincia);
        }
        public void AddComune(Comune comune)
        {
            comune.GeographicArea = this;
            _comune.Add(comune);
        }
        public void RemoveComune(Comune comune)
        {
            comune.GeographicArea = null;
            _comune.Remove(comune);
        
        }
    }
}
