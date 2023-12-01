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
    public class ArtistRepository
    {
        private readonly string _folderPath = @"C:\Users\giuse\Desktop\SpotiFake\Artist";
        private readonly ILogger<ArtistRepository> _logger;
        private readonly DBContext dBContext;

        public ArtistRepository(ILogger<ArtistRepository> logger)
        {
            _logger = logger;
            dBContext = new DBContext(_folderPath);
        }

        public List<Artist> GetAll()
        {
            try
            {
                var artists = dBContext.GetAll<Artist>();
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
                var artist = dBContext.GetById<Artist>(id);
                return artist;
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
               dBContext.Add(artist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'artista con ID {artist.Id}.");
                throw;
            }
        }
    }
}
