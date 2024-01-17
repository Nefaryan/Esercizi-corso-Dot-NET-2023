using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.Util;
using Translation_And_Food.Interfaces;

namespace Translation_And_Food.Entity.FoodEntity
{
    internal class FoodProvider
    {
        public TimeSpan Opening { get; set; }
        public TimeSpan Closed { get; set; }
        public List<Product> Menù { get; set; }
        public string Name { get; set; }
        public Queue<Order> Orders { get; set; }
        public int OrderInQueue => Orders.Count;

        public FoodProvider()
        {
            Orders = new Queue<Order>();
        }

        public bool CanAcceptOder()
        {
            return OrderInQueue < 4;
        }

        public async Task<bool> ProcessOrder(Order order)
        {
            await Task.Delay(order.TotalPreparationTime * 5);
            order.Status = OrderStatusEnum.Ready;
            Orders.Enqueue(order);
            return true;
        }
    }
}

