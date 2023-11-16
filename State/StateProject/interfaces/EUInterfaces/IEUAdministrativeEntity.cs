using StateProject.entities;
using StateProject.entities.EU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.interfaces.EUInterfaces
{
    public interface IEUAdministrativeEntity : IAdministrativeEntity
    {
        public void BoarderRedefinition(State destionation);
        public void WellfareService();
    }
}
