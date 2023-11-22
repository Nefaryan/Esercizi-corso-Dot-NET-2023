using Esercizio_FileSystem.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Esercizio_FileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Account> accounts = new List<Account> { new Account(1, 30000), new Account(2, 800) };
            List<Customer> customers = new List<Customer> { new Customer("Mario", 25), new Customer("Biondi", 25) };

            WriteListToFile("accounts.txt", accounts);


            WriteListToFile("customers.txt", customers);

        }

        static void WriteListToFile<T>(string fileName, List<T> list)
        {
            try
            {
                string projectDirectory = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(projectDirectory, fileName);

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var item in list)
                    {
                        sw.WriteLine(item.ToString());
                    }
                }

                Console.WriteLine($"Il contenuto della lista è stato scritto nel file '{filePath}' con successo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore durante la scrittura del file '{fileName}': {ex.Message}");
            }

        }

    }
}
