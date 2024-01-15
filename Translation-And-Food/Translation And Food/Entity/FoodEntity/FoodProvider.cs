using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translation_And_Food.Entity.FoodEntity
{
    internal class FoodProvider
    {
        public DateTime Opening { get; set; }
        public DateTime Closed { get; set; }
        public List<Product> Menù { get; set; }
        public string Name { get; set; }
        public Queue<Order> Orders { get; set; }
        public int OrderInQueue { get; set; }

        public FoodProvider()
        {
            Orders = new Queue<Order>();
        }

        public bool CanAcceptOder()
        {
            return OrderInQueue < 4;
        }
    }
}
