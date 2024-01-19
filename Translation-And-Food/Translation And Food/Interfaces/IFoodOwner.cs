using System.Collections.Generic;
using Translation_And_Food.Entity.FoodEntity;

namespace Translation_And_Food.Interfaces
{
    internal interface IFoodOwner
    {
        List<Product> Products { get; }
    }
}

