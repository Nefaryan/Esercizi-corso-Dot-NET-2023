using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class Country
    {
        string _name;
        List<City> _cities;  
        
        public Country(string name) {
            Name = name;
        }

        public string Name { get => _name; set => _name = value; }

        public void addCountry(City city)
        {
            city.Country = this;
            _cities.Add(city);
        }
    }
}
