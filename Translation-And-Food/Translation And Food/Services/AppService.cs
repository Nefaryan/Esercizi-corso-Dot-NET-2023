using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
