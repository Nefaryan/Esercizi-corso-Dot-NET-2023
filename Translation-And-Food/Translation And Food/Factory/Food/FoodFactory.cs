using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;
using Translation_And_Food.Interfaces;

namespace Translation_And_Food.Factory.Food
{
    internal class FoodFactory : IFoodFactory
    {
        public Order CreateOrder(List<Product> products)
        {
            return new Order { Products = products, Status = OrderStatusEnum.InPreparation };
        }
    }
}

