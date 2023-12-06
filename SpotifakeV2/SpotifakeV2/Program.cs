using SpotifakeService.Service;
using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using SpotifakeData.Entity;
using SpotifakeService;
using Microsoft.Extensions.Logging;
using SpotifakeData.Repository;

namespace SpotifakePresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var folderPath = @"C:\Users\giuse\Desktop\SpotiFake\Song";
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<GenericRepository<Song>>();
            var repository = new GenericRepository<Song>(folderPath,logger);

            Song song = new Song();
            song.Id = 6;
            song.Title = "Baahl Theme";
            song.Duration = 192;

            repository.Add(song);
            var allitem = repository.GetALL();
            Console.WriteLine("Tutti gli elemnti:");
            foreach (var item in allitem)
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine("--------------------------");
            var item1 = repository.GetById(5);
            Console.WriteLine(item1.Title);






        }
    }
 }

