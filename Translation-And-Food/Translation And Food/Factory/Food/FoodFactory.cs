using System.Threading.Tasks;
using Translation_And_Food.Entity.FoodEntity;
using Translation_And_Food.Entity.Util;
using Translation_And_Food.Interfaces;

namespace Translation_And_Food.Factory.Food
{
    internal class FoodFactory : IFoodFactory
    {
        public Order CreateOrder()
        {
            return new Order {Status = OrderStatusEnum.InPreparation };
        }
    }
}

