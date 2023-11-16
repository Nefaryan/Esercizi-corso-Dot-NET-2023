using StateProject.entities.EU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.interfaces
{
    public interface IEUAdministrativeEntity:IAdministrativeEntity
    {
        public void BoarderRedefinition(EUParliament eUParliament);
        public void WellfareService();
    }
}
