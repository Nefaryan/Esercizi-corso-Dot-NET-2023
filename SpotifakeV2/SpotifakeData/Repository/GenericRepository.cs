using Microsoft.Extensions.Logging;
using SpotifakeData.DataContext;
using SpotifakeData.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DBContext? _dbContext;
        private readonly ILogger<GenericRepository<T>>? _logger;
        private readonly string? _folderPath;

        public GenericRepository(string folderPath, ILogger<GenericRepository<T>> logger)
        {
            _folderPath = folderPath;
            _logger = logger;
            _dbContext = new DBContext(_folderPath);
        }

        public void Add(T item)
        {
            try
            {
                _dbContext.Add(item);
            }
            catch (Exception ex)
            {
                _logger.LogError("Errore durante l'aggiunta al datasource",ex);
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
                _logger.LogError("Errore la lettura dal datasource",ex);
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
                _logger.LogError("Eorre durante la lettura del datafolder",ex);
                throw;      
            }
        }
    }
}
