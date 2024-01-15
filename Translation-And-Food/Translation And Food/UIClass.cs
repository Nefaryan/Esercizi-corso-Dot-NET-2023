using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translation_And_Food
{
    internal class UIClass
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Cerca un traduttore");
                Console.WriteLine("2. Ordina un pasto");
                Console.WriteLine("3. Esci");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        Console.WriteLine("Place holder for Traduttore");
                        break;
                    case "2":
                        Console.WriteLine("Placeholder for Cibo");
                        break;
                    case "3":
                        Exit();
                        break;
                }
            }
            
        }



        private void Exit()
        {
            Console.WriteLine("Thank you for using the application. Goodbye!");
            Environment.Exit(0);
        }
    }
}
