using Microsoft.Extensions.Logging;
using SpotifakeData.DataContext;
using SpotifakeData.Entity.Music;
using SpotifakeData.Entity;
using SpotifakeData.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifakeData.Utils;

namespace SpotifakeData.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DBContext? _dbContext;
        private readonly ILogger<GenericRepository<T>>? _logger;
        private readonly FolderPaths _folderPaths;

        public GenericRepository(FolderPaths folderPaths, ILogger<GenericRepository<T>> logger)
        {
            _folderPaths = folderPaths;
            _logger = logger;

            ConfigurePathByEntityType();
        }

        private void ConfigurePathByEntityType()
        {
            if (typeof(T) == typeof(Song))
            {
                ConfigurePath(_folderPaths.Song);
            }
            else if (typeof(T) == typeof(User))
            {
                ConfigurePath(_folderPaths.User);
            }
            else if (typeof(T) == typeof(Movie))
            {
                ConfigurePath(_folderPaths.Movie);
            }
            else if (typeof(T) == typeof(Playlist))
            {
                ConfigurePath(_folderPaths.Playlist);
            }
            else if (typeof(T) == typeof(Radio))
            {
                ConfigurePath(_folderPaths.Radio);
            }
            else if (typeof(T) == typeof(Album))
            {
                ConfigurePath(_folderPaths.Album);
            }
            else if (typeof(T) == typeof(Group))
            {
                ConfigurePath(_folderPaths.Group);
            }
            else if (typeof(T) == typeof(Artist))
            {
                ConfigurePath(_folderPaths.Artist);
            }
            else
            {
                throw new InvalidOperationException($"Tipo {typeof(T)} non gestito nella configurazione del percorso.");
            }
        }

        private void ConfigurePath(string folderPath)
        {
            if (!string.IsNullOrEmpty(folderPath))
            {
                _dbContext = new DBContext(folderPath);
            }
            else
            {
                _logger.LogError($"Percorso non configurato per il tipo {typeof(T)}.");
                throw new InvalidOperationException($"Percorso non configurato per il tipo {typeof(T)}.");
            }
        }

        public void Add(T item)
        {

            try
            {
                _dbContext.Add(item);
            }
            catch (Exception ex)
            {
                _logger.LogError("Errore durante l'aggiunta al datasource", ex);
                throw;
            }
        }

        public List<T> GetALL()
        {
            try
            {
                var items = _dbContext.GetAll<T>();
                return items;
            }
            catch (Exception ex)
            {
                _logger.LogError("Errore la lettura dal datasource", ex);
                throw;
            }
        }

        public T GetById(int id)
        {
            try
            {
                var item = _dbContext.GetById<T>(id);
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError("Errore durante la lettura del datafolder", ex);
                throw;
            }
        }
    }
}

