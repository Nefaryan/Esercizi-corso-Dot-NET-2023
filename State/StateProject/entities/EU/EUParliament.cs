using StateProject.interfaces.EUInterfaces;
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
        
        public bool Permision { get => _permision; set => _permision = value; }

        public void BoarderRedefinition(State destionation)
        {
            Console.WriteLine("Redefinition border");
        }

        public void EducationalSystem()
        {
            throw new NotImplementedException();
        }

        public void HNS()
        {
            throw new NotImplementedException();
        }

        public void LawSystem()
        {
            throw new NotImplementedException();
        }
        public void WellfareService()
        {
            throw new NotImplementedException();
        }
    }
}
