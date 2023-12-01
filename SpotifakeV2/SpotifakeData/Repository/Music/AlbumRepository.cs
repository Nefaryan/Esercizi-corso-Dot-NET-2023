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
    public class AlbumRepository
    {
        private static readonly string _folderPath = @"C:\Users\giuse\Desktop\SpotiFake\Albums";
        private readonly ILogger<AlbumRepository> _logger;
        private readonly DBContext _dbContext;
 

        public AlbumRepository(ILogger<AlbumRepository> logger)
        {
            _logger = logger;
            _dbContext = new DBContext(_folderPath);
        }


        public List<Album> GetAll()
        {
            try
            {
                var albums = _dbContext.GetAll<Album>();
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
                var album = _dbContext.GetById<Album>(id);
                return album;
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
                _dbContext.Add(album);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'album con ID {album.ID}.");
                throw;
            }
        }
    }

}

