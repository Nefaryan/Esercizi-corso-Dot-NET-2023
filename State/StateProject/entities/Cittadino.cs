using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class Cittadino
    {

        string _name;
        string _surname;
        Comune comune;

        public Cittadino(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public Comune Comune { get => comune; set => comune = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
    }
}
