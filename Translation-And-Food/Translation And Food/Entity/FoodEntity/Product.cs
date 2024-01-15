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
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public MealType MealType { get; set; }
        public int preparationTime { get; set; }
    }
}
