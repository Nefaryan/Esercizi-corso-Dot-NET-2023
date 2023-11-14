using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.interfaces
{
    internal interface IEuropeanUnion: IPoliticalOrganization
    {
        public void EMA();
        public void CostitutionIntegration();
        public void HumanRightTribunal();
    }
}
