using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Translation_And_Food.Entity;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.TranslationEntity;
using Translation_And_Food.Entity.Util;
using Translation_And_Food.Factory.Translation;
using Translation_And_Food.Services;

namespace Translation_And_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Name = "Giacomo";
            user.Type = UserType.officeManager;
           
            
            List<FoodProvider> providers = new List<FoodProvider>();
            List<Bucket> buckets = new List<Bucket>();
            List<Product> Colazione = new List<Product>
            {
                new Product("Caffè",1,MealType.Colazione,1),
                new Product("Cornetto",2,MealType.Colazione,2)
            };
            List<Product> Pranzo = new List<Product>{

                new Product("Amatriciana",1,MealType.Pranzo,12),
                new Product("Tagliata di manzo",2,MealType.Pranzo,42)

            };
            List<Product> Cena = new List<Product>()
            {
                new Product("Pizza",1,MealType.Cena,35),
                new Product("Kebab",2,MealType.Cena,20)
            };

            FoodProvider foodProvider = new FoodProvider();
            foodProvider.Menù = Colazione;
            foodProvider.Name = "Baretto";
            foodProvider.Opening = new TimeSpan(7, 0, 0);
            foodProvider.Closed = new TimeSpan(11, 0, 0);

            FoodProvider foodProvider1 = new FoodProvider();
            foodProvider1.Menù = Pranzo;
            foodProvider1.Name = "Cipollotta";
            foodProvider1.Opening = new TimeSpan(11, 30, 0);
            foodProvider1.Closed = new TimeSpan(16, 0, 0);

            FoodProvider foodProvider2 = new FoodProvider();
            foodProvider2.Menù = Cena;
            foodProvider2.Name = "Bestia Kebab";
            foodProvider2.Opening = new TimeSpan(17, 30, 0);
            foodProvider2.Closed = new TimeSpan(22, 0, 0);

            providers.Add(foodProvider1);
            providers.Add(foodProvider2);
            providers.Add(foodProvider);

            List<Translator> translators = new List<Translator>();
            Translator t1 = new Translator();
            t1.Name = "Pippo";
            t1.Language = "Tedesco";
            translators.Add(t1);

            FoodDeliveryServices foodDeliveryServices = new FoodDeliveryServices(providers,buckets);
            var tranlatorsFactory = new TranslationFactory();
            TranslationService translationService = new TranslationService(tranlatorsFactory,translators);
            AppService appService = new AppService(foodDeliveryServices,translationService);
            UIClass ui = new UIClass(appService);

            ui.Run(user);

        }
    }
}
