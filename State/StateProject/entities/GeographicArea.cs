using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class GeographicArea
    {
        List<State> _states;
        List<Regione> _regions;
        List<Provincia> _provincia;
        List<Comune> _comune;
        
        public GeographicArea()
        {
            _states = new List<State>();
            _regions = new List<Regione>();
            _provincia = new List<Provincia>();
            _comune = new List<Comune>();
        }

        public void Add(State state)
        {
            state.Area = this;
            _states.Add(state);
        }

        public void Remove(State state)
        {
            state.Area = null;
            _states.Remove(state);
        }
    }
}
