using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateProject.entities.EU;

namespace StateProject.entities
{
    public class City:EUComune
    {
        string _cityName;
        Country _country;

        public City(string name,int capacità) : base(name, capacità)
        {
            _cityName = name;
        }

        public string CityName { get => _cityName; set => _cityName = value; }
        public Country Country { get => _country; set => _country = value; }
    }
}
