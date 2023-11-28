using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeClasses.Entities
{
    public class Person
    {
        private string _name;
        private string _surname;
        private string _dateOfBirth;

        public Person()
        {
               
        }
        public Person(string name, string surname, string dateOfBirth)
        {
            _name = name;
            _surname = surname;
            _dateOfBirth = dateOfBirth;
        }

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
    }
}
