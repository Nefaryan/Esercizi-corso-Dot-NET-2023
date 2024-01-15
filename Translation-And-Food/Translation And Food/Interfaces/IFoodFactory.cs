using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;

namespace Translation_And_Food.Interfaces
{
    internal interface IFoodFactory
    {
        public Order CreateOrder(MealType type);
    }
}
