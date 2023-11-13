using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio2.entities
{
    public class DeathsentenceCountry : Country
    {
        bool _deathSentence;

        public DeathsentenceCountry(string name, bool death) : base(name)
        {
            _deathSentence = death;
        }

        public bool DeathSentence
        {
            get { return _deathSentence; }
            set { _deathSentence = value; }
        }
    }
}
