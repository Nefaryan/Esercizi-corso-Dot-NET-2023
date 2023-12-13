using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class OrderRepo
    {
        public void AddOrder(Order order)
        {
            Console.WriteLine($"Order whit id {order.Id} savade");

        }
    }
}
