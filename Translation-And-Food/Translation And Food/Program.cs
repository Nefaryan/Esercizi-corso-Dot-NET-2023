using System;
using System.Collections.Generic;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Services;

namespace Translation_And_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FoodProvider> providers = new List<FoodProvider>();
            List<Bucket> buckets = new List<Bucket>();

            FoodDeliveryServices foodDeliveryServices = new FoodDeliveryServices(providers,buckets);
            AppService appService = new AppService(foodDeliveryServices);
            UIClass ui = new UIClass(appService);

            ui.Run();
        }
    }
}
