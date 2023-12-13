using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelayer.EmailService.MailTamplate
{
    public class GenericCustomerTemplate
    {
        public string Mail(Order order)
        {
            return $"Dear {order.CustomerName} your oder whit id:" +
                $" {order.Id} and date {order.OrderDate} has confirmed!";
        }
    }
}
