using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class NATO
    {
        List<NatoState> _states;

        public NATO()
        {
            _states = new List<NatoState>();
        }

        public void addNatoState (NatoState state)
        {
            _states.Add(state);
        }

        public void remouve(NatoState state)
        {
            _states.Remove(state);
        }
    }
}
