using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpotifakeData.DataContext;
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
        private readonly DBContext dBContext;

        public PlaylistRepository(ILogger<PlaylistRepository> logger)
        {
            _logger = logger;
            dBContext = new DBContext(_folderPath);
        }

        public List<Playlist> GetAll()
        {
            try
            {
                var playlists = dBContext.GetAll<Playlist>();
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
              var Playlist = dBContext.GetById<Playlist>(id);
              return Playlist;
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
                dBContext.Add(playlist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della playlist con ID {playlist.Id}.");
                throw;
            }
        }
    }
}
