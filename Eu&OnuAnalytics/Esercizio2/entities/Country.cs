using Esercizio2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio2.entities
{
    public abstract class Country : IHumanRightCourt
    {
        string _name {  get; set; }
       
        public Country(string name)
        {
            _name = name; 
            
        }
        
        public string Name {
            get { return _name; }
            set { _name = value; }
        }

       

        public virtual double CalculateSpread()
        {
            return 0.0;
        }

        public void CheckHumanRights(Country country)
        {   if(country is DeathsentenceCountry)
            {
                Console.WriteLine($"The country: {country.Name} applies the death penalty");
            }
            if(country is EUCountry || country is ONUCountry)
            {
                Console.WriteLine($"The country: {country.Name} respect human rights");
            }else
            {
                Console.WriteLine($"The country: {country.Name} dosen't respect human rights");
            }
        }
    }
}
