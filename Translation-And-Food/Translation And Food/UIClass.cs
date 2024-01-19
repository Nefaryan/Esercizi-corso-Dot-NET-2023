using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Translation_And_Food.Entity;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;
using Translation_And_Food.Event;
using Translation_And_Food.Services;

namespace Translation_And_Food
{
    internal class UIClass
    {
        private readonly AppService _appService;
        List<Product> listOfProducts = new List<Product>();
        private FoodProvider prov = new FoodProvider();

        public UIClass(AppService appService)
        {
            _appService = appService;
            _appService.TranslationService.TranslatorFound += OnTranlatorFound;
        }

        public void Run(User user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------Office Manager---------");
                Console.WriteLine("1. Cerca un traduttore");
                Console.WriteLine("2. Ordina un pasto");
                Console.WriteLine("X. Esci");
                Console.WriteLine("---------------------------------");

                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "1":
                        RunTranslationMenu(user);
                        break;
                    case "2":
                        RunFoodDeliveryMenu(user);
                        break;
                    case "X":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void RunFoodDeliveryMenu(User user)
        {
          

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Food Menù ===");
                Console.WriteLine("1. Visualizza tutti i ristoranti con servizio di food delivery\n " +
                    "  disponibili per la tua fascia oraria");
                Console.WriteLine("2. Visualizza ristoranti per tipo di pasto");
                Console.WriteLine("3. Visualizza menu del ristorante");
                Console.WriteLine("4. Seleziona i prodotti per l'ordine");
                Console.WriteLine("5. Crea un ordine");
                Console.WriteLine("6. Torna al menu principale");
                Console.WriteLine("7. Esci");
                Console.WriteLine("------------------------");

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
                       listOfProducts = SelectProductsForOrder();
                        break;
                    case "5":
                        CreateOrder(user, listOfProducts);
                        break;
                    case "6":
                        return; // Torna al menù principale
                    case "7":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private async void RunTranslationMenu(User user)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("== Translator Menu ==");
                Console.WriteLine("1. Cerca Il traduttore");
                Console.WriteLine("2. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Inserisici la lingua per la quale cerchi un traduttore");
                        Findtranslator();
                        break;
                    case "2":
                        Exit();
                        break;
                }
            }

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
            Console.ReadLine();
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
            Console.ReadLine();
        }

        private List<Product> SelectProductsForOrder()
        {
            Console.WriteLine("Inserisci il nome del ristorante: ");
            string restaurantName = Console.ReadLine();
            prov = _appService.GetProvider(restaurantName);
            List<Product> productsToAdd = _appService.SelectProductForOrder(prov).Result;
            return productsToAdd;
        }


        private async Task CreateOrder(User user, List<Product> selectedProducts)
        {
            var products = selectedProducts.Select(p => p.Name).ToList();
            Console.WriteLine($"I prodotti selezionati per il tuo ordine sono: {string.Join(", ", products)}");
            Console.WriteLine(await _appService.CreateOrder(user, selectedProducts, prov));
            Console.ReadLine();
        }


        private async void DisplayFoodProvidersInTime()
        {
            Console.WriteLine("Inserisci l'orario nel formato HH:mm:ss: ");
            if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan selectedTime))
            {
                var res = await _appService.GetAllProviderInTime(selectedTime);
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("Formato orario non valido. Riprova.");
            }
            Console.ReadLine();
        }

        private void Exit()
        {
            Console.WriteLine("Thank you for using the application. Goodbye!");
            Environment.Exit(0);
        }

        private async Task Findtranslator()
        {
            string trans = Console.ReadLine();
            var translator = await _appService.FindTranslator(trans);
            if (translator != null)
            {
                Console.WriteLine($"Traduttore trovato: {translator}");
            }
            else
            {
                Console.WriteLine("Nessun Traduttore disponibile per la lingua selezionata.");
            }
        }

        private void OnTranlatorFound(object sender,TranslatorFoundEventArgs e)
        {
            Console.WriteLine($"Il troduttore trovato è : {e.Translator.Name} avvisa il giudice");
        }
    }

}
