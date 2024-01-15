using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;

namespace Translation_And_Food.Factory
{
    internal class MealProviderFactory
    {
        private readonly List<FoodProvider> _foodProviders;

        public MealProviderFactory(List<FoodProvider> foodProviders)
        {
            _foodProviders = foodProviders;
        }

        public List<FoodProvider> FindProvidersByMealType(MealType mealType)
        {
            return _foodProviders.Where(provider => provider.Menù.Any(product => product.MealType == mealType)).ToList();
        }
    }
}
