using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translation_And_Food.Entity.FoodEntity
{
    internal class FoodDelivery
    {
        public List<Order> OrderList;
        public List<FoodProvider> FoodProviders;
        public FoodDelivery()
        {
            OrderList = new List<Order>();
            FoodProviders = new List<FoodProvider>();
        }
    }
}
