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
                throw new NotImplementedException();
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        //Metodo per creare l'ordine 
        public async Task<Order> CreateOrder(MealType mealType,List<Product> products,
           FoodProvider foodProv)
        {
            try
            {
                var order = _foodFactory.CreateOrder(mealType);
                if (products != null)
                {
                    order.Products.AddRange(products);
                }
                await foodProv.ProcessOrder(order);
                var bucket = new Bucket { Order = order };

                await NotifyUserForOrderCreation(order);
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error:{ex.Message}");
            }


        }

        public List<Product> FoodProviderMenu(FoodProvider foodProv)
        {
            try
            {
                var menu = new List<Product>();
                if(foodProv != null && foodProv.Menù.Count>0)
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
            await Task.Delay(500);
            Console.WriteLine("L'ordine e stato creato e lo stiamo elaborando");
        }
        private async Task NotifyUserForShipping(Order order)
        {
            await Task.Delay(500);
            Console.WriteLine("Il tuo ordine è stato spedito");

        }
        private async Task NofifyUserForOrderIsArrivals(Order order)
        {
            await Task.Delay(500);
            Console.WriteLine("Il tuo ordine è stato conseganto, Buon Appetito");
        }
    }
}
