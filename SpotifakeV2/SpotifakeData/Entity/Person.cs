using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Entity
{
    public abstract class Person
    {
        string _name;
        string _surname;
        string _dateOfBirth;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
    }
}
