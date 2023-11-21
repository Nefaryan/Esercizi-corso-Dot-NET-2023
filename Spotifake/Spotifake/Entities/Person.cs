using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    internal abstract class Person
    {
        string _name;
        string _surname;
        string _dateOfBirth;

        public Person(string name, string surname, string dateOfBirth)
        {
            _name = name;
            _surname = surname;
            _dateOfBirth = dateOfBirth;
        }
    }
}
