﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Translation_And_Food.Entity.Util;
using Translation_And_Food.Interfaces;

namespace Translation_And_Food.Entity.FoodEntity
{
    internal class Order: IFood
    {
        private static readonly Random random = new Random();

        public int Id { get; set; }
        public OrderStatusEnum Status { get; set; }
        public List<Product> Products { get; set; }
        public int TotalPrice => Products.Sum(p => p.Price);
        public int TotalPreparationTime => Products.Sum(p => p.preparationTime);

        public Order() 
        {
          Id = random.Next(1,1000);
        }

        public override string ToString()
        {
            return $"{Id} -- {TotalPrice} ";
        }
    }
}

