using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;
using Translation_And_Food.Factory.Food;
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
            _foodProviders = foodProviders ?? throw new ArgumentNullException(nameof(foodProviders));
            _buckets = buckets ?? throw new ArgumentNullException(nameof(buckets));
            _foodFactory = new FoodFactory();
            _mealProviderFactory = new MealProviderFactory(_foodProviders);
        }

        public async Task<List<FoodProvider>> FindFoodProvidersForTime(TimeSpan time)
        {
            try
            {
                var providers = _foodProviders
                    .Where(provider => IsProviderOpen(provider, time) && provider.CanAcceptOder())
                    .ToList();

                if (providers.Count > 0)
                {
                    await Task.Delay(1000);
                    return providers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<List<FoodProvider>> FindFoodProviderForType(MealType mealType)
        {
            try
            {
                var providers = _mealProviderFactory.FindProvidersByMealType(mealType)
                    .Where(provider => provider.CanAcceptOder())
                    .ToList();

                await Task.Delay(1000);
                return providers;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Order> CreateOrder(User user, List<Product> products, FoodProvider foodProv)
        {
            try
            {
                Console.WriteLine("Stiamo creando il tuo ordine");
                Order order = _foodFactory.CreateOrder(products);
                order.Products.AddRange(products);

                // Verifica se l'ordine è già presente nella coda degli ordini
                if (!foodProv.Orders.Any(existingOrder => existingOrder.Id == order.Id))
                {
                    foodProv.Orders.Enqueue(order);  // Aggiungi l'ordine alla coda degli ordini del provider

                    await foodProv.ProcessOrders();  // Processa gli ordini in attesa

                    var bucket = new Bucket { Order = order };
                    await NotifyUserForOrderCreation(order);
                    Console.WriteLine($"Prezzo Totale: {order.TotalPrice}");
                    await Task.Delay(1000);
                    Console.WriteLine("Grazie per il pagamento!");
                    Console.WriteLine("Ordine creato");
                    await NotifyUserForShipping(order);
                    Console.Write("Grazie per averci scelto!");
                    await NofifyUserForOrderIsArrivals(order, user);

                    return order;
                }
                else
                {
                    Console.WriteLine($"Ordine con ID {order.Id} già presente nella coda degli ordini.");
                    return null;
                }
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
                var menu = foodProv?.Menù?.ToList() ?? new List<Product>();

                if (menu.Any())
                {
                    return menu;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
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

        private bool IsProviderOpen(FoodProvider provider, TimeSpan time)
        {
            return provider?.Opening <= time && time <= provider?.Closed;
        }

        private async Task NotifyUserForOrderCreation(Order order)
        {
            await Task.Delay(order.TotalPreparationTime * 1000);
            Console.WriteLine("L'ordine è stato creato e lo stiamo elaborando.");
        }

        private async Task NotifyUserForShipping(Order order)
        {
            await Task.Delay(500);
            order.Status = OrderStatusEnum.OnTheGo;
            Console.WriteLine("Il tuo ordine è stato spedito.");
        }

        private async Task NofifyUserForOrderIsArrivals(Order order,User user)
        {

            await Task.Delay(500);
            order.Status = OrderStatusEnum.Arrivals;
            if(user.Type == UserType.officeManager)
            {
                Console.WriteLine("Avvisa il giudice che il suo pasto è arrivato");
            }
            else
            {
                Console.WriteLine("Il tuo ordine è stato consegnato, Buon Appetito!");
            }

        }
            

        public FoodProvider GetFoodProvider(string name)
        {
            return _foodProviders.FirstOrDefault(x => x.Name == name);
        }
    }

}
