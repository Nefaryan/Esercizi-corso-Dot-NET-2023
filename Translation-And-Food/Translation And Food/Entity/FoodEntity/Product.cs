using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.Util;

namespace Translation_And_Food.Entity.FoodEntity
{
    internal class Product
    {
        private static readonly Random random = new Random();

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public MealType MealType { get; set; }
        public int preparationTime { get; set; }

        public Product(string name, int price, MealType mealType, int preparationTime)
        {
            Id = random.Next(1, 1000);
            Name = name;
            Price = price;
            MealType = mealType;
            this.preparationTime = preparationTime;
        }
    }
}
