using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.FoodEntity;

namespace Translation_And_Food.Interfaces
{
    internal interface IFood
    {
        List<Product> Products { get; }
    }
}

