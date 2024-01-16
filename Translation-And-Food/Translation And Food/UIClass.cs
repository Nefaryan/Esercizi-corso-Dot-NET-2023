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
        private List<Product> listOfProducts = new List<Product>();
        private FoodProvider prov = new FoodProvider();

        public UIClass(AppService appService)
        {
            _appService = appService;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Cerca un traduttore");
                Console.WriteLine("2. Ordina un pasto");
                Console.WriteLine("X. Esci");

                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "1":
                        Console.WriteLine("Place holder for Traduttore");
                        Console.ReadLine(); // Pausa per visualizzare il messaggio
                        break;
                    case "2":
                        RunFoodDeliveryMenu();
                        break;
                    case "X":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        Console.ReadLine(); // Pausa per visualizzare il messaggio
                        break;
                }
            }
        }

        private void RunFoodDeliveryMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Food Menù ===");
                Console.WriteLine("1. Visualizza tutti i ristoranti con servizio di food delivery");
                Console.WriteLine("2. Visualizza ristoranti per tipo di pasto");
                Console.WriteLine("3. Visualizza menu del ristorante");
                Console.WriteLine("4. Seleziona i prodotti per l'ordine");
                Console.WriteLine("5. Crea un ordine");
                Console.WriteLine("6. Esci");

                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "1":
                        DisplayFoodProvidersInTime();
                        break;
                    case "2":
                        DisplayFoodProvidersByMealType();
                        break;
                    case "3":
                        DisplayRestaurantMenu();
                        break;
                    case "4":
                        SelectProductsForOrder();
                        break;
                    case "5":
                        CreateOrder();
                        break;
                    case "6":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        Console.ReadLine(); // Pausa per visualizzare il messaggio
                        break;
                }
            }
        }

        private void DisplayFoodProvidersInTime()
        {
            Console.WriteLine(_appService.GetAllProviderInTime(DateTime.Now));
            Console.ReadLine(); // Pausa per visualizzare il messaggio
        }

        private void DisplayFoodProvidersByMealType()
        {
            Console.WriteLine("Inserisci il tipo di pasto (Colazione, Pranzo, Cena): ");
            if (Enum.TryParse(Console.ReadLine(), true, out MealType mealType))
            {
                string result = _appService.GetAllProviderForMealType(mealType).Result;
                Console.WriteLine("-------------------");
                Console.WriteLine(result);
                Console.WriteLine("-------------------");
            }
            else
            {
                Console.WriteLine("Tipo di pasto non valido.");
            }
            Console.ReadLine(); // Pausa per visualizzare il messaggio
        }

        private void DisplayRestaurantMenu()
        {
            Console.WriteLine("Inserisci il nome del ristorante: ");
            string restaurantName = Console.ReadLine();
            prov = _appService.GetProvider(restaurantName);
            var menus = _appService.Menu(prov).Result;
            Console.WriteLine("-------------------");
            Console.WriteLine(menus);
            Console.WriteLine("-------------------");
            Console.ReadLine(); // Pausa per visualizzare il messaggio
        }

        private void SelectProductsForOrder()
        {
            Console.WriteLine("Inserisci il nome del ristorante: ");
            string restaurantName = Console.ReadLine();
            prov = _appService.GetProvider(restaurantName);
            listOfProducts = _appService.SelectProductForOrder(prov).Result;
            Console.ReadLine(); // Pausa per visualizzare il messaggio
        }

        private void CreateOrder()
        {
            Console.WriteLine("Inserisci il tipo di pasto (Colazione, Pranzo, Cena): ");
            if (Enum.TryParse(Console.ReadLine(), true, out MealType mealType))
            {
                Console.WriteLine(_appService.CreateOrder(mealType, listOfProducts, prov).Result);
            }
            else
            {
                Console.WriteLine("Tipo di pasto non valido.");
            }
            Console.ReadLine(); // Pausa per visualizzare il messaggio
        }

        private void Exit()
        {
            Console.WriteLine("Thank you for using the application. Goodbye!");
            Environment.Exit(0);
        }
    }



}
