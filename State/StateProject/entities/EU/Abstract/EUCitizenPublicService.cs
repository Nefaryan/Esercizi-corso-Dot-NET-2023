using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities.EU.Abstract
{
    public abstract class EUCitizenPublicService : IAdministrativeEntity
    {
        public void EducationalSystem() {
            Console.WriteLine("System for education");
        }
        public void HNS()
        {
            Console.WriteLine("Sisystem for HSN");
        }
        public void LawSystem()
        {
            Console.WriteLine("Sisystem for LawSystem");
        }
        public abstract void WellfareServices();
        public abstract void HSN(EUID eUID);
        public abstract void EducationalSystem(EUID eUID);

    }
}
