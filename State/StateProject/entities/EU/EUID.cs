using StateProject.entities.EU.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities.EU
{
    public class EUID 
    {
        string _name;
        string _surname;
        string _genere;
        string _dateOfBirth;
        int _age;

        public EUID(string name, string surname, string genere, string dateOfBirth, int age)
        {
            _name = name;
            _surname = surname;
            _genere = genere;
            _dateOfBirth = dateOfBirth;
            Age = age;
        }

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Genere { get => _genere; set => _genere = value; }
        public string DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public int Age { get => _age; set => _age = value; }

      

        
    }
}
