using StateProject.interfaces.EUInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities.EU.Abstract
{
    public abstract class EUPublicAdministration : GeographicArea, IEUAdministrativeEntity
    {
        public void BoarderRedefinition(State destionation)
        {
            throw new NotImplementedException();
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
