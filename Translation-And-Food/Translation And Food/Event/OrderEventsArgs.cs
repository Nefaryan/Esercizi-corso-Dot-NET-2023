using System;
using Translation_And_Food.Entity.FoodEntity;

namespace Translation_And_Food.Event
{
    internal class OrderEventsArgs : EventArgs
    {
        public Order Order { get; set; }

        public OrderEventsArgs(Order order)
        {
            Order = order;
        }

    }
}
