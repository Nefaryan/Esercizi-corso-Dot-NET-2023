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
        
        public GeographicArea()
        {
            _states = new List<State>();
        }

        public void Add(State state)
        {
            state.Area = this;
            _states.Add(state);
        }

        public void Remove(State state)
        {
            _states.Remove(state);
        }
    }
}
