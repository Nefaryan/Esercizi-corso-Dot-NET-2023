using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelayer.EmailService.MailTamplate
{
    public class FidelityCustomerTemplate
    {
        public string Mail(Order order)
        {
            return $"Dear {order.CustomerName} your oder whit id:" +
                $" {order.Id} and date {order.OrderDate} has confirmed!" +
                $"For the next order you have a 35% discount";
        }

    }
}
