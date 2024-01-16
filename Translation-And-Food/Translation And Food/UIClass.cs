using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;
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
                Console.WriteLine("X. Esci");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        Console.WriteLine("Place holder for Traduttore");
                        break;
                    case "2":
                        FoodDeliveryMenu();
                        break;
                    case "X":
                        Exit();
                        break;
                }
            }
            
        }


        private async void FoodDeliveryMenu()
        {
            var listOfProducts = new List<Product>();
            var prov = new FoodProvider();

            while (true)
            {
                Console.WriteLine("=== Food Menù ===");
                Console.WriteLine("1. Visualizza tutti i ristoranti con servizio di food delivery");
                Console.WriteLine("2. Visualizza ristoranti per tipo di pasto");
                Console.WriteLine("3. Visualizza menu del ristorante");
                Console.WriteLine("4. Seleziona i prodotti per l'ordine");
                Console.WriteLine("5. Crea un ordine");
                Console.WriteLine("6. Esci");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(_appService.GetAllProviderInTime(DateTime.Now));
                        break;
                    case "2":
                        Console.WriteLine("Inserisci il tipo di pasto (Colazione, Pranzo, Cena): ");
                        MealType mealType;
                        if (Enum.TryParse(Console.ReadLine(), true, out mealType))
                        {
                            string result = await _appService.GetAllProviderForMealType(mealType);
                            Console.WriteLine("-------------------");
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("Tipo di pasto non valido.");
                        }
                        break;
                    case "3": //TODO FIX RETURN
                        Console.WriteLine("Inserisci il nome del ristorante: ");
                        string restaurantName = Console.ReadLine();
                        prov = _appService.GetProvider(restaurantName);
                        var menus = await _appService.Menu(prov);
                        Console.WriteLine("-------------------");
                        Console.WriteLine(menus);
                        break;     
                    case "4":
                        Console.WriteLine("Inserisci il nome del ristorante: ");
                        string restaurantName1 = Console.ReadLine();
                        prov = _appService.GetProvider(restaurantName1);
                        listOfProducts = await _appService.SelectProductForOrder(prov);
                        break;
                    case "5"://TODO FIX 
                        Console.WriteLine("Inserisci il tipo di pasto (Colazione, Pranzo, Cena): ");
                        MealType mealType1;
                        if (Enum.TryParse(Console.ReadLine(), true, out mealType1))
                        {
                            Console.WriteLine(_appService.CreateOrder(mealType1, listOfProducts, prov));
                        }
                        else
                        {

                        }
                        break;
                    case "6":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
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
