using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;
using Translation_And_Food.Interfaces;

namespace Translation_And_Food.Factory
{
    internal class FoodFactory : IFoodFactory
    {
        public Order CreateOrder()
        {
            return new Order { Products = new List<Product>(), Status = OrderStatusEnum.InPreparation };
        }
    }
}

