using StateProject.entities;
using System;

namespace StateProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EuropeanUnion EU = new EuropeanUnion();

            State EuState = new EUState("Italy", "Euro", "Italy", 341, "Svizzera", 30, 399999);
            EuroZoneState EuZoneState = new EuroZoneState("Germany", "Euro", "Germany", 344444, "Confine", 232, 122222222, 34);

            EU.AddEUState((EUState)EuState);
            EU.AddEUZoneState(EuZoneState);
            
        }
    }
}
