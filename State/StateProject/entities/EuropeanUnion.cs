using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class EuropeanUnion
    {
        List<EUState> _eUStates;
        List<EuroZoneState> _eUZones;

        public EuropeanUnion()
        {
            _eUStates = new List<EUState>();
            _eUZones = new List<EuroZoneState>();
        }

        public void AddEUState(EUState e)
        {
            _eUStates.Add(e);
        }

        public void RemoveEUState(EUState e)
        {
            _eUStates.Remove(e);
        }

        public void AddEUZoneState(EuroZoneState e)
        {
            _eUZones.Add(e);
        }

        public void RemoveEUZoneState(EuroZoneState e)
        {
            _eUZones.Remove(e);
        }


    }
}
