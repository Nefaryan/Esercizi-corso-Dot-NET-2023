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
            /*
             * var albumRepository = new GenericRepository<Album>(@"C:\Users\giuse\Desktop\SpotiFake\Albums", logger);
               var artistRepository = new GenericRepository<Artist>(@"C:\Users\giuse\Desktop\SpotiFake\Artist", logger);
               var groupRepository = new GenericRepository<Group>(@"C:\Users\giuse\Desktop\SpotiFake\Group", logger);
               var playlistRepository = new GenericRepository<Playlist>(@"C:\Users\giuse\Desktop\SpotiFake\Playlist", logger);
               var songRepository = new GenericRepository<Song>(@"C:\Users\giuse\Desktop\SpotiFake\Songs", logger);
             */

            var folderPath = @"C:\Users\giuse\Desktop\SpotiFake\ASong";
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<GenericRepository<Song>>();
            var repository = new GenericRepository<Song>(folderPath,logger);

            Song song = new Song();
            song.Id = 5;
            song.Title = "Raphael Final's ACT";
            song.Duration = 182;

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

