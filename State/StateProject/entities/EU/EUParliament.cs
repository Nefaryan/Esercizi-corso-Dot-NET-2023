using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities.EU
{
    public class EUParliament : IEUAdministrativeEntity
    {
        bool _permision;
        List<EUState> _state;

        public bool Permision { get => _permision; set => _permision = value; }

        public void AddEuState(EUState state) {
         _state.Add(state);
        }
        public void RemoveEuState(EUState state) { _state.Remove(state); }

        public void BoarderRedefinition(EUParliament eUParliament)
        {
            Console.WriteLine("New rule for");
        }

        public void EducationalSystem()
        {
            Console.WriteLine("New rule for");
        }

        public void HNS()
        {
            Console.WriteLine("New rule for");
        }

        public void LawSystem()
        {
            Console.WriteLine("New rule for");
        }

        public void WellfareService()
        {
            Console.WriteLine("New rule for");
        }
    }
}
