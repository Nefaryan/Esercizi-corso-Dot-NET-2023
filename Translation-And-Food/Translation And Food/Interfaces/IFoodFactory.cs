using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_And_Food.Entity.FoodEntity;

namespace Translation_And_Food.Interfaces
{
    internal interface IFoodFactory
    {
        IFood CreateOrderForBreakfast()
        {
            return new Order();
        }
        
        IFood CreateOrderForLunch()
        {
            return new Order();
        }

        IFood CreateOrderForDinner()
        {
            return new Order();
        }
    }
}
