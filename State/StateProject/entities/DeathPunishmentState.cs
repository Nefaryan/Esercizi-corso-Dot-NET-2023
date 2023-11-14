using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    internal class DeathPunishmentState : State,IDeathPunishementState
    {
        int _yearWhitCapitalSentence;

        public DeathPunishmentState(string name, string money,
            string banner, decimal expenses, string confine
            , int yearWhitCapitalSentence): base(name,money, banner,
                expenses, confine)
        {
            _yearWhitCapitalSentence = yearWhitCapitalSentence;
        }

        public int YearWhitCapitalSentence { get => _yearWhitCapitalSentence; set => _yearWhitCapitalSentence = value; }

        public void death()
        {
            Console.WriteLine("Death");
        }
    }
}
