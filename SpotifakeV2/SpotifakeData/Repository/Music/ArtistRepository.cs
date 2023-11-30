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
    public class ArtistRepository
    {
        private readonly string _folderPath = @"C:\Users\giuse\Desktop\SpotiFake\Artist";
        private readonly ILogger<ArtistRepository> _logger;

        public ArtistRepository(string folderPath, ILogger<ArtistRepository> logger)
        {
            _folderPath = folderPath;
            _logger = logger;

            Directory.CreateDirectory(_folderPath);
        }

        public List<Artist> GetAll()
        {
            try
            {
                var artists = new List<Artist>();

                foreach (var file in Directory.GetFiles(_folderPath, " *.json"))
                {
                    var jsonData = File.ReadAllText(file);
                    var artist = JsonConvert.DeserializeObject<Artist>(jsonData);
                    artists.Add(artist);
                }

                return artists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura di tutti gli artisti.");
                throw;
            }
        }

        public Artist GetById(int id)
        {
            try
            {
                var filePath = Path.Combine(_folderPath, $"{id}.json");

                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<Artist>(jsonData);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la lettura dell'artista con ID {id}.");
                throw;
            }
        }

        public void Add(Artist artist)
        {
            try
            {
                var artistId = artist.Id;
                var filePath = Path.Combine(_folderPath, $"{artistId}.json");

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                var jsonData = JsonConvert.SerializeObject(artist, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'artista con ID {artist.Id}.");
                throw;
            }
        }
    }
}
