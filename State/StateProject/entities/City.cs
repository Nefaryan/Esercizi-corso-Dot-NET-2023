using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class City
    {
        string _cityName;
        Comune comune;

        public City(string CityName)
        {
            _cityName = CityName;
        }

        public string CityName { get => _cityName; set => _cityName = value; }
        public Comune Comune { get => comune; set => comune = value; }

    }
}
