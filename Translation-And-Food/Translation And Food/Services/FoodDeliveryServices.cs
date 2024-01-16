using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;
using Translation_And_Food.Factory;
using Translation_And_Food.Interfaces;

namespace Translation_And_Food.Services
{
    internal class FoodDeliveryServices
    {
        private readonly List<FoodProvider> _foodProviders;
        private readonly List<Bucket> _buckets;
        private readonly FoodFactory _foodFactory;
        private readonly MealProviderFactory _mealProviderFactory;
        public FoodDeliveryServices(List<FoodProvider> foodProviders, List<Bucket> buckets)
        {
            _foodProviders = foodProviders;
            _buckets = buckets;
            _foodFactory = new FoodFactory();
            _mealProviderFactory = new MealProviderFactory(foodProviders);
        }

        //Metodo per torvare tutti i food provider disponibili in una determinata fascia oraria
        public async Task<List<FoodProvider>> FindFoodProvidersForTime(DateTime time)
        {
            try
            {
                List<FoodProvider> provieders = new List<FoodProvider>();
                foreach (var provider in _foodProviders)
                {
                    if (IsProviderOpen(provider, time) && provider.CanAcceptOder())
                    {
                        provieders.Add(provider);
                    }
                }
                if (provieders.Count > 0)
                {
                    await Task.Delay(1000);
                    return provieders;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error:{ex.Message}");
            }


        }

        //Metodo per trovare tutti i foodProvider disponibili in base al tipo di pasto che voglio consumare Colazione,Pranzo o Cena
        public async Task<List<FoodProvider>> FindFoodProviderForType(MealType mealType)
        {
            try
            {
                var providers = new List<FoodProvider>();
                var mealProviderFactory = new MealProviderFactory(_foodProviders);

                // Utilizza la factory per trovare i provider in base al tipo di pasto
                providers = mealProviderFactory.FindProvidersByMealType(mealType);

                // Filtra ulteriormente i provider che possono accettare ordini
                providers = providers.Where(provider => provider.CanAcceptOder()).ToList();
                await Task.Delay(1000);
                return providers;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        //Metodo per creare l'ordine 
        public async Task<Order> CreateOrder(MealType mealType, List<Product> products, FoodProvider foodProv)
        {
            try
            {
                Order order = null;

                foreach (var product in products)
                {
                    order = _foodFactory.CreateOrder(mealType);
                    order.Products.Add(product);

                    if (await foodProv.ProcessOrder(order))
                    {
                        var bucket = new Bucket { Order = order };
                        await NotifyUserForOrderCreation(order);
                        Console.WriteLine("Ordine creato");
                        await NotifyUserForShipping(order);
                        Console.Write("Grazie per Averci scelto!");
                    }
                    else
                    {
                        Console.WriteLine($"Il FoodProvider {foodProv.Name} non può accettare ulteriori ordini.");
                        order = null; // Imposta order su null se l'ordine non può essere processato
                        break; // Esce dal ciclo se non può accettare ordini
                    }
                }

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }


        public List<Product> FoodProviderMenu(FoodProvider foodProv)
        {
            try
            {
                var menu = new List<Product>();
                if (foodProv != null && foodProv.Menù.Count > 0)
                {

                    menu.AddRange(foodProv.Menù);
                    return menu;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error:{ex.Message}");
            }

        }

        public List<Product> SelectProductFromProvider(FoodProvider foodProvider)
        {
            try
            {
                var menu = FoodProviderMenu(foodProvider);
                if (menu != null && menu.Any())
                {
                    Console.WriteLine($"Menu del FoodProvider {foodProvider.Name}:");
                    Console.WriteLine("-----------------------------");
                    for (int i = 0; i < menu.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {menu[i].Name} - {menu[i].Price}€");
                    }
                    Console.WriteLine("-----------------------------");
                    Console.Write("Inserisci il numero del prodotto che desideri aggiungere (0 per terminare): ");
                    List<Product> selectedProducts = new List<Product>();
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out int userInput) && userInput >= 0 && userInput <= menu.Count)
                        {
                            if (userInput == 0)
                                break;
                            var selectedProduct = menu[userInput - 1];
                            selectedProducts.Add(selectedProduct);
                            Console.WriteLine($"Hai aggiunto {selectedProduct.Name} al tuo ordine.");
                        }
                        else
                        {
                            Console.WriteLine("Inserimento non valido. Riprova.");
                        }
                    }
                    return selectedProducts;
                }
                else
                {
                    Console.WriteLine("Il FoodProvider non ha un menu disponibile.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la selezione dei prodotti: {ex.Message}");
                return null;
            }
        }

        private bool IsProviderOpen(FoodProvider provider, DateTime time)
        {
            return provider.Opening <= time && time <= provider.Closed;
        }
        private async Task NotifyUserForOrderCreation(Order order)
        {
            await Task.Delay(order.TotalPreparationTime * 1000);
            Console.WriteLine("L'ordine e stato creato e lo stiamo elaborando");
        }
        private async Task NotifyUserForShipping(Order order)
        {
            await Task.Delay(500);
            order.Status = OrderStatusEnum.OnTheGo;
            Console.WriteLine("Il tuo ordine è stato spedito");

        }
        private async Task NofifyUserForOrderIsArrivals(Order order)
        {
            await Task.Delay(500);
            Console.WriteLine("Il tuo ordine è stato conseganto, Buon Appetito");
        }
        public FoodProvider GetFoodProvider(string name)
        {
            var foodProvider = _foodProviders.FirstOrDefault(x => x.Name == name);  
            return foodProvider;
        }

    }
}
