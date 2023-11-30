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
    public class SongRepository
    {
        private static readonly string _folderPath = @"C:\Users\giuse\Desktop\SpotiFake\Songs";
        private readonly ILogger<SongRepository> _logger;
        static SongRepository()
        {
            Directory.CreateDirectory(_folderPath);
        }

        public SongRepository(ILogger<SongRepository> logger)
        {
            _logger = logger;
        }

        public List<Song> GetAll()
        {
            try
            {
                var songs = new List<Song>();

                foreach (var file in Directory.GetFiles(_folderPath, "*.json"))
                {
                    var jsonData = File.ReadAllText(file);
                    var song = JsonConvert.DeserializeObject<Song>(jsonData);
                    songs.Add(song);
                }

                return songs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura di tutte le canzoni.");
                throw;
            }
        }

        public Song GetById(int id)
        {
            try
            {
                var filePath = Path.Combine(_folderPath, $"{id}.json");

                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<Song>(jsonData);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la lettura della canzone con ID {id}.");
                throw;
            }
        }

        public Song GetByName(string title)
        {
            try
            {
                var filePath = Path.Combine(_folderPath, $"{title}.json");
                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<Song>(jsonData);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la lettura della canzone con titolo {title}.");
                throw;
            }
        }

        public void Add(Song song)
        {
            try
            {
                var songId = song.Id;
                var filePath = Path.Combine(_folderPath, $"{songId}.json");

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                var jsonData = JsonConvert.SerializeObject(song, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone con ID {song.Id}.");
                throw;
            }
        }
    }


}

