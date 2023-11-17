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

        public void EnterINEU(State state, int population)
        {

            if (state is EUState)
            {
                Console.WriteLine("The provided state is already an EUState.");
            }
            else
            {

                EUState euState = new EUState(state.Name, state.Money, state.Banner, state.Expenses, state.Confine, 0);
                euState.TimeInEU++;
                AddEUState(euState);
                Console.WriteLine($"State {state.Name} enter in EU");
            }
        }


    }
}
