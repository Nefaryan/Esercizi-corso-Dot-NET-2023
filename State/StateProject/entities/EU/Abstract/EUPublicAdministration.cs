using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities.EU.Abstract
{
    public abstract class EUPublicAdministration : IEUAdministrativeEntity
    {
        public void BoarderRedefinition(EUParliament eUParliament) { }
        public void EducationalSystem() { }
        public void HNS() { }
        public void LawSystem() { }
        public void WellfareService() { }
        public abstract void EducationalSystem(EUID eUID);
        public abstract void HNS(EUID eUID);
        public abstract void WellfareService(EUID eUID);
        public void EMA() { }
        public void CostitutionIntegration() { }
        public void HumanRightTribunal() { }
        public void Enter() { }
        
    }
}
