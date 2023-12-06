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
    public class SongRepository
    {
        private static readonly string _folderPath = @"C:\Users\giuse\Desktop\SpotiFake\Songs";
        private readonly ILogger<SongRepository> _logger;
        private readonly DBContext dBContext;

        public SongRepository(ILogger<SongRepository> logger)
        {
            _logger = logger;
            dBContext = new DBContext(_folderPath);
        }

        public List<Song> GetAll()
        {
            try
            {
                var songs = dBContext.GetAll<Song>();
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
               return dBContext.GetById<Song>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la lettura della canzone con ID {id}.");
                throw;
            }
        }

      /*  public Song GetByName(string title)
        {
            try
            {
               return dBContext.GetByName<Song>(title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la lettura della canzone con titolo {title}.");
                throw;
            }
        }*/

        public void Add(Song song)
        {
            try
            {
              dBContext.Add(song);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone con ID {song.Id}.");
                throw;
            }
        }
    }


}

