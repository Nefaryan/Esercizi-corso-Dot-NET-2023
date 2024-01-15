using System;
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
        public int Id { get; set; }
        public OrderStatusEnum Status { get; set; }
        public List<Product> Products { get; set; }
        public int TotalPrice => Products.Sum(p => p.Price);
        public int TotalPreparationTime => Products.Max(p => p.preparationTime);
    }
}
