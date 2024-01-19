using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Translation_And_Food.Entity;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;
using Translation_And_Food.Event;
using Translation_And_Food.Factory.Food;


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
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("Stiamo creando il tuo ordine");
                Order order = _foodFactory.CreateOrder();

                if (foodProv.Orders.Any(existingOrder => existingOrder.Id == order.Id))
                {
                    Console.WriteLine("Errore: L'ordine è già presente nella coda degli ordini.");
                    return null;
                }

                order.Products = new List<Product>(products);

                if (products == null || !products.Any())
                {
                    Console.WriteLine("Errore: Nessun prodotto selezionato per l'ordine.");
                    return null;
                }

                foodProv.Orders.Enqueue(order);  

                await foodProv.ProcessOrders();

                var bucket = new Bucket { Order = order };
                await NotifyUserForOrderCreation(order);

                Console.WriteLine($"Prezzo Totale: {order.TotalPrice}");
                await Task.Delay(1000);
                Console.WriteLine("Grazie per il pagamento!");
                Console.WriteLine("Ordine creato");
                await NotifyUserForShipping(order);
                Console.Write("Grazie per averci scelto!");
                await NofifyUserForOrderIsArrivals(order, user);
                Console.WriteLine("-----------------------------------------------------------------------");

                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la creazione dell'ordine: {ex.Message}");
                return null;
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

        public List<Product> SelectProductsFromMenu(FoodProvider foodProvider)
        {
            Console.WriteLine($"Menu del FoodProvider {foodProvider.Name}:");
            Console.WriteLine("-----------------------------");

            DisplayMenu(foodProvider);

            Console.WriteLine("-----------------------------");
            Console.Write("Inserisci il numero del prodotto che desideri aggiungere (0 per terminare): ");
            List<Product> selectedProducts = new List<Product>();

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int userInput) && userInput >= 0)
                {
                    if (userInput == 0)
                        break;

                    var selectedProduct = GetProductFromMenu(foodProvider, userInput);
                    if (selectedProduct != null)
                    {
                        selectedProducts.Add(selectedProduct);
                        Console.WriteLine($"Hai aggiunto {selectedProduct.Name} al tuo ordine.");
                    }
                    else
                    {
                        Console.WriteLine("Prodotto non valido. Riprova.");
                    }
                }
                else
                {
                    Console.WriteLine("Inserimento non valido. Riprova.");
                }
            }

            return selectedProducts;
        }


        private bool IsProviderOpen(FoodProvider provider, TimeSpan time)
        {
            return provider?.Opening <= time && time <= provider?.Closed;
        }

        private async Task NotifyUserForOrderCreation(Order order)
        {
            await Task.Delay(order.TotalPreparationTime * 1000);
            Console.WriteLine("L'ordine è stato creato e lo stiamo elaborando.");

            OrderCreationEvent?.Invoke(this, new OrderEventsArgs(order));
        }

        private async Task NotifyUserForShipping(Order order)
        {
            await Task.Delay(500);
            order.Status = OrderStatusEnum.OnTheGo;
            Console.WriteLine("Il tuo ordine è stato spedito.");

            OrderShippingEvent?.Invoke(this, new OrderEventsArgs(order));
        }

        private async Task NofifyUserForOrderIsArrivals(Order order, User user)
        {
            await Task.Delay(500);
            order.Status = OrderStatusEnum.Arrivals;
            if (user.Type == UserType.officeManager)
            {
                Console.WriteLine("Avvisa il giudice che il suo pasto è arrivato");
            }
            else
            {
                Console.WriteLine("Il tuo ordine è stato consegnato, Buon Appetito!");
            }

            OrderArrivalEvent?.Invoke(this, new OrderEventsArgs(order));
        }

        public event EventHandler<OrderEventsArgs> OrderCreationEvent;
        public event EventHandler<OrderEventsArgs> OrderShippingEvent;
        public event EventHandler<OrderEventsArgs> OrderArrivalEvent;


        public FoodProvider GetFoodProvider(string name)
        {
            return _foodProviders.FirstOrDefault(x => x.Name == name);
        }

        private void DisplayMenu(FoodProvider foodProvider)
        {
            var menu = FoodProviderMenu(foodProvider);

            if (menu != null && menu.Any())
            {
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i].Name} - {menu[i].Price}€");
                }
            }
            else
            {
                Console.WriteLine("Il FoodProvider non ha un menu disponibile.");
            }
        }

        private Product GetProductFromMenu(FoodProvider foodProvider, int userInput)
        {
            var menu = FoodProviderMenu(foodProvider);

            if (menu != null && menu.Any() && userInput <= menu.Count)
            {
                return menu[userInput - 1];
            }

            return null;
        }
    }

}
