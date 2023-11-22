using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_FileSystem.Classes
{
    internal class Customer
    {
        public string Name {  get; set; }
        public int Age { get; set; }

        public Customer(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Customer Name: {Name}, Age: {Age}";
        
        }
    }
}
