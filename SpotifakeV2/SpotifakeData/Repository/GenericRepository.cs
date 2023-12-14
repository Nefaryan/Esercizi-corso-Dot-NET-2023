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
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SpotifakeData.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<GenericRepository<T>> _logger;
        private string _path;

        public GenericRepository(string path,ILogger<GenericRepository<T>> logger, DBContext dbContext)
        {
            _path = path;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbContext = new DBContext(path);
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
                _logger.LogError("Errore nella lettura dal datasource", ex);
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

