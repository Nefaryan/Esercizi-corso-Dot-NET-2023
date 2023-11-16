using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateProject.entities.EU;

namespace StateProject.entities
{
    public class GeographicArea
    {
         string _name;
         string _position;

        List<State> _states;
      

        public string Name { get => _name; set => _name = value; }
        public string Position { get => _position; set => _position = value; }

        public GeographicArea(string name, string position)
        {
            _name = name;
            _position = position;
            _states = new List<State>();
           
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
      

    }
}
