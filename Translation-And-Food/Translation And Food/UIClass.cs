﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Services;

namespace Translation_And_Food
{
    internal class UIClass
    {
        private readonly AppService _appService;

        public UIClass(AppService appService)
        {
            _appService = appService;
        }

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
                        FoodDeliveryMenu();
                        break;
                    case "3":
                        Exit();
                        break;
                }
            }
            
        }


        private void FoodDeliveryMenu()
        {
            while(true)
            {
                Console.WriteLine("=== Food Menù ===");
                Console.WriteLine("1. Visualizza tutti i ristoranti con srvizio di food delivery");
                Console.WriteLine("2. Esci");

                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        Console.WriteLine(_appService.GetAllProviderInTime(DateTime.Now));
                        break;
                    default:
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