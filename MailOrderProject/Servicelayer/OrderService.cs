using DataLayer.Model;
using DataLayer.Repository;
using Servicelayer.EmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelayer
{
    public class OrderService
    {
        private readonly OrderRepo repo;
        private readonly MailService emailService;

        public OrderService(OrderRepo repo, MailService emailService)
        {
            this.repo = repo;
            this.emailService = emailService;
        }

        public void FidelityGenerateOrder(Order order)
        {
            repo.AddOrder(order);
            emailService.FidelityConfermationMail(order);
        
        }

        public void GenericGenerateOrder(Order order)
        {
            repo.AddOrder(order);
            emailService.GenericConfermationMail(order);

        }
    }
}
