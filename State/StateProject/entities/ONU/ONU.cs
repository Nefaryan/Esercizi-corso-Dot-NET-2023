using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class ONU
    {
        List<ONUState> states;

        public void AddOnuState(ONUState state)
        {
            states.Add(state);
        }

        public void RemoveOnuState(ONUState state)
        { 
            states.Remove(state);
        }
    }
}
