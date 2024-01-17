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
        public Queue<Order> Orders { get; set; } = new Queue<Order>();
        public Queue<Product> ProductsInPrep { get; set; } = new Queue<Product> ();
        public int ProductsInPreparationCount => ProductsInPrep.Count;

        public FoodProvider()
        {
            Orders = new Queue<Order>();
        }

        public bool CanAcceptOder()
        {
            return ProductsInPreparationCount < 4;
        }

        public async Task<bool> ProcessOrders()
        {
            while (Orders.Count > 0 && CanAcceptOder())
            {
                Order order = Orders.Dequeue();
                foreach (Product product in order.Products)
                {
                    if (!await ProcessProduct(product))
                    {
                        Console.WriteLine("Tutte i nostri dipendenti sono occupati sarai servito non appena possibile");
                        return false;
                    }
                }
            }

            return true;
        }

        private async Task<bool> ProcessProduct(Product product)
        {
            await Task.Delay(product.preparationTime * 5);
            ProductsInPrep.Enqueue(product);
            return true;
        }


    }
}

