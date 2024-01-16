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
            _foodDeliveryServices = foodDeliveryServices;
        }

        public async Task<string> GetAllProviderInTime(DateTime time)
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
                return "Si è verificato un erorre";
            }
        }

        public async Task<string> Menu(FoodProvider foodprovider)
        {
            try
            {
                await Task.Delay(1000);
                var menù = _foodDeliveryServices.FoodProviderMenu(foodprovider);
                if (menù.Any())
                {
                    var productInfo = menù.Select(p => $"{p.Id} - {p.Name} - {p.Price}$").ToList();
                    var result = string.Join(Environment.NewLine, productInfo);

                    return result;
                }
                else
                {
                    return "si è verificato un errore";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error:{ex.Message}");
            }
        }

        public async Task<string> SelectProductForOrder(FoodProvider foodProvider)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la selezione dei prodotti: {ex.Message}");
                return "Si è verificato un errore durante la selezione dei prodotti.";
            }
        }

        public FoodProvider GetProvider(string providerName)
        {
            return _foodDeliveryServices.GetFoodProvider(providerName);
        }

    }
}
