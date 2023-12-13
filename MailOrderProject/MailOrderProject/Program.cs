using DataLayer.Model;
using DataLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Servicelayer;
using Servicelayer.EmailService;
using Servicelayer.EmailService.MailTamplate;
using System;

namespace MailOrderProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsetting.json").Build();

            var mailSet = new EmailSetting();
            config.GetSection("EmailSettings").Bind(mailSet);
            var provider = new ServiceCollection()
                .Configure<EmailSetting>(opt =>
                {
                    opt.Host = mailSet.Host;
                    opt.Port = mailSet.Port;
                    opt.Username = mailSet.Username;
                    opt.Password = mailSet.Password;
                    opt.Security = mailSet.Security;

                }).AddSingleton<OrderRepo>()
                .AddSingleton<SmtpMailClient>()
                .AddSingleton<MailService>()
                .AddSingleton<GenericCustomerTemplate>()
                .AddSingleton<FidelityCustomerTemplate>()
                .AddSingleton<OrderService>()
                .BuildServiceProvider();

            var orderService = provider.GetRequiredService<OrderService>();
            var mailClient = provider.GetRequiredService<SmtpMailClient>();

            var order1 = new Order();
            order1.CustomerEmail = "giuseppe.roberti9950@gmail.com";
            order1.OrderDate = DateTime.Now;
            order1.CustomerName = "Giuseppe";
            order1.Id = 1;

            orderService.GenericGenerateOrder(order1);

        }
    }
}
