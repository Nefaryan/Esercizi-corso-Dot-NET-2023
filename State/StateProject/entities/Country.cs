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
        public List<City> Cities { get => _cities; set => _cities = value; }

        public void AddCountry(City city)
        {
            city.Country = this;
            Cities.Add(city);
        }
    }
}
