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
        public Queue<Product> ProductsInPrep { get; set; } = new Queue<Product>();
        public int ProductsInPrepCount => ProductsInPrep.Count;

        public FoodProvider()
        {
            Orders = new Queue<Order>();
        }

        public bool CanAcceptOder()
        {
            lock (ProductsInPrep)
            {
                return ProductsInPrepCount < 4;
            }
        }

        private async Task<bool> ProcessProduct(Product product)
        {
            await Task.Delay(product.preparationTime * 5);

            lock (ProductsInPrep)
            {
                if (ProductsInPrepCount < 4)
                {
                    ProductsInPrep.Enqueue(product);
                    return true;
                }
                else
                {
                    Console.WriteLine("Limite di prodotti in preparazione raggiunto.");
                    Task.Delay(1000);
                    return false;
                }
            }
        }


        public async Task<bool> ProcessOrders()
        {
            List<Order> ordersToProcess;

            lock (Orders)
            {
                ordersToProcess = Orders.ToList();
                Orders.Clear(); 
            }

            foreach (Order order in ordersToProcess)
            {
                if (!order.IsProcessed)
                {
                    foreach (Product product in order.Products)
                    {
                        if (!await ProcessProduct(product))
                        {
                            Console.WriteLine("Tutti i nostri dipendenti sono occupati, sarai servito non appena possibile");
                            return false;
                        }
                    }
                    order.IsProcessed = true;
                }
            }

            return true;
        }

    }

}

