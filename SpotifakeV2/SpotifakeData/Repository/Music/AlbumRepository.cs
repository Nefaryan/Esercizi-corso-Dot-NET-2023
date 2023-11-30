using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Repository.Music
{
    public class AlbumRepository
    {
        private static readonly string _folderPath = @"C:\Users\giuse\Desktop\SpotiFake\Albums";
        private readonly ILogger<AlbumRepository> _logger;

        static AlbumRepository()
        {
            Directory.CreateDirectory(_folderPath);
        }

        public AlbumRepository(ILogger<AlbumRepository> logger)
        {
            _logger = logger;
        }


        public List<Album> GetAll()
        {
            try
            {
                var albums = new List<Album>();

                foreach (var file in Directory.GetFiles(_folderPath, "*.json"))
                {
                    var jsonData = File.ReadAllText(file);
                    var album = JsonConvert.DeserializeObject<Album>(jsonData);
                    albums.Add(album);
                }

                return albums;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura di tutti gli album.");
                throw;
            }
        }

        public Album GetById(int id)
        {
            try
            {
                var filePath = Path.Combine(_folderPath, $"{id}.json");

                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<Album>(jsonData);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la lettura dell'album con ID {id}.");
                throw;
            }
        }

        public void Add(Album album)
        {
            try
            {
                var albumId = album.ID;
                var filePath = Path.Combine(_folderPath, $"{albumId}.json");

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                var jsonData = JsonConvert.SerializeObject(album, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'album con ID {album.ID}.");
                throw;
            }
        }
    }

}

