using Microsoft.Extensions.Logging;
using SpotifakeData.Repository;
using SpotifakeService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class GenericService<T> : IService<T> where T : class
    {
        private readonly GenericRepository<T> _repository;
        private readonly ILogger <GenericService<T>> _logger;
        private readonly ILogger<GenericRepository<T>> _loggerFactory;

        public GenericService(string path, ILogger<GenericService<T>> logger)
        {
            _repository = new GenericRepository<T>(path, _loggerFactory);
            _logger = logger;
        }

        public void AddItem(T item)
        {
            try
            {
                _repository.Add(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errore {ex}");
                throw;
            }
        }

        public List<T> GetAllItem()
        {
            try
            {
                var items = _repository.GetALL();
                return items;
            }
            catch (Exception ex)
            {
                _logger.LogError("Errore nell recupero");
                throw;
            }
        }

        public T GetItem(int id)
        {
            try
            {
                var item = _repository.GetById(id);
                return  item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;         
            }
        }
    }
}
