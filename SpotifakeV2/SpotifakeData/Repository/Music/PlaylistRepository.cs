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
    public class PlaylistRepository
    {
        private readonly string _folderPath = @"C:\Users\giuse\Desktop\SpotiFake\Playlist";
        private readonly ILogger<PlaylistRepository> _logger;

        public PlaylistRepository(string folderPath, ILogger<PlaylistRepository> logger)
        {
            _folderPath = folderPath;
            _logger = logger;

            Directory.CreateDirectory(_folderPath);
        }

        public List<Playlist> GetAll()
        {
            try
            {
                var playlists = new List<Playlist>();

                foreach (var file in Directory.GetFiles(_folderPath, " *.json"))
                {
                    var jsonData = File.ReadAllText(file);
                    var playlist = JsonConvert.DeserializeObject<Playlist>(jsonData);
                    playlists.Add(playlist);
                }

                return playlists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura di tutte le playlist.");
                throw;
            }
        }

        public Playlist GetById(int id)
        {
            try
            {
                var filePath = Path.Combine(_folderPath, $"{id}.json");

                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<Playlist>(jsonData);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la lettura della playlist con ID {id}.");
                throw;
            }
        }

        public void Add(Playlist playlist)
        {
            try
            {
                var playlistId = playlist.Id;
                var filePath = Path.Combine(_folderPath, $"{playlistId}.json");

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                var jsonData = JsonConvert.SerializeObject(playlist, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della playlist con ID {playlist.Id}.");
                throw;
            }
        }
    }
}
