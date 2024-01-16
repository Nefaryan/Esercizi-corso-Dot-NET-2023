using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;

namespace Translation_And_Food.Services
{
    internal class AppService
    {
        private readonly FoodDeliveryServices _foodDeliveryServices;

        public AppService(FoodDeliveryServices foodDeliveryServices)
        {
            _foodDeliveryServices = foodDeliveryServices ?? throw new ArgumentNullException(nameof(foodDeliveryServices));
        }

        public async Task<string> GetAllProviderInTime(TimeSpan time)
        {
            try
            {
                var providers = await _foodDeliveryServices.FindFoodProvidersForTime(time);

                if (providers.Any())
                {
                    return string.Join(Environment.NewLine, providers.Select(provider => provider.Name));
                }
                else
                {
                    return "Nessun food provider disponibile per la fascia oraria selezionata.";
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Errore durante la ricerca dei food provider: {ex.Message}");
                return "Si è verificato un errore durante la ricerca dei food provider.";
            }
        }

        public async Task<string> GetAllProviderForMealType(MealType meal)
        {
            try
            {
                var providers = await _foodDeliveryServices.FindFoodProviderForType(meal);

                if (providers.Any())
                {
                    return string.Join(Environment.NewLine, providers.Select(provider => provider.Name));
                }
                else
                {
                    return "Nessun food provider disponibile per la fascia oraria selezionata.";
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Errore durante la ricerca dei food provider: {ex.Message}");
                return "Si è verificato un errore durante la ricerca dei food provider.";
            }
        }

        public async Task<string> CreateOrder(MealType type, List<Product> products, FoodProvider provider)
        {
            try
            {
                var order = await _foodDeliveryServices.CreateOrder(type, products, provider);
                return order.ToString();
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"{ex.Message}");
                return "Si è verificato un errore";
            }
        }

        public async Task<string> Menu(FoodProvider foodProvider)
        {
            try
            {
                await Task.Delay(1000);

                var menu = _foodDeliveryServices.FoodProviderMenu(foodProvider);

                if (menu.Any())
                {
                    var productInfo = menu.Select(p => $"{p.Id} - {p.Name} - {p.Price}$");
                    return string.Join(Environment.NewLine, productInfo);
                }
                else
                {
                    return "Si è verificato un errore";
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<List<Product>> SelectProductForOrder(FoodProvider foodProvider)
        {
            try
            {
                await Task.Delay(1000);
                return _foodDeliveryServices.SelectProductFromProvider(foodProvider)?.ToList();
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"Errore durante la selezione dei prodotti: {ex.Message}");
                throw;
            }
        }

        public FoodProvider GetProvider(string providerName)
        {
            return _foodDeliveryServices.GetFoodProvider(providerName);
        }
    }

}
