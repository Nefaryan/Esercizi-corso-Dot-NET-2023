using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;


namespace Servicelayer.EmailService
{
    public class SmtpMailClient
    {
        private readonly EmailSetting _setting;

        public SmtpMailClient(IOptions<EmailSetting> setting)
        {
            _setting = setting.Value;
        }

        public void SendEmail(string to, string subject, string body)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Host = _setting.Host;
                smtp.Port = _setting.Port;
                smtp.EnableSsl = _setting.Security == "STARTTLS";
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_setting.Username, _setting.Password);


                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_setting.Username),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                smtp.Send(mailMessage);
            }
        }


    }
}
