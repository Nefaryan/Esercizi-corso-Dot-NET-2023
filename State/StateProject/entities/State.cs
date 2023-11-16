using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public  class State: IONU
    {
        string name;
        string money;
        string banner;
        decimal expenses;
        string confine;
        GeographicArea area;

        public State(string name, string money, 
            string banner, decimal expenses, string confine)
        {
            this.name = name;
            this.money = money;
            this.banner = banner;
            this.expenses = expenses;
            this.confine = confine;
        }

        public string Name { get => name; set => name = value; }
        public string Money { get => money; set => money = value; }
        public string Banner { get => banner; set => banner = value; }
        public decimal Expenses { get => expenses; set => expenses = value; }
        public string Confine { get => confine; set => confine = value; }
        public GeographicArea Area { get => area; set => area = value; }

        public void PopulationControll()
        {
            Console.WriteLine("Controll");
        }

        public void TerritoryDefense()
        {
            Console.WriteLine("Defense");
        }
    }

}
