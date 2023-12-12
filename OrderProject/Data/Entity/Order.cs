using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    internal class Order
    {
        int _Id;
        DateTime _OrderDate;
        Customer _Customer;
        List<Product> _Products;
        double _Total;
    }
}
