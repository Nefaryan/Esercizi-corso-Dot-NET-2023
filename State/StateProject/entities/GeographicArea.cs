using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateProject.entities.EU;

namespace StateProject.entities
{
    public abstract class GeographicArea
    {

        int _latidute;
        int _area;

        public int Latidute { get => _latidute; set => _latidute = value; }
        public int Area { get => _area; set => _area = value; }
    }
}
