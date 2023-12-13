using DataLayer.Model;
using Servicelayer.EmailService.MailTamplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelayer.EmailService
{
    public class MailService
    {
        private readonly FidelityCustomerTemplate _fTemplate;
        private readonly GenericCustomerTemplate _gTemplate;
        private readonly SmtpMailClient _mailClient;

        public MailService(FidelityCustomerTemplate fTemplate,
            GenericCustomerTemplate gTemplate, SmtpMailClient mailClient)
        {
            _fTemplate = fTemplate;
            _gTemplate = gTemplate;
            _mailClient = mailClient;
        }

        public void FidelityConfermationMail(Order order)
        {
            var mailText = _fTemplate.Mail(order);
            _mailClient.SendEmail(order.CustomerEmail, "Shipping", mailText);
        }

        public void GenericConfermationMail(Order order)
        {
            var mailText = _gTemplate.Mail(order);
            _mailClient.SendEmail(order.CustomerEmail, "Shipping", mailText);
        }
    }
}
