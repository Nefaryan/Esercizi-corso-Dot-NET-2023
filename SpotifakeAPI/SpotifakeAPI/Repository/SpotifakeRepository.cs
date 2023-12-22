using Microsoft.Extensions.Logging;
using SpotifakeAPI.Models;
using SpotifakeAPI.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotifakeAPI.Repository
{
    public class SpotifakeRepository<T>  : IGenericRepository<T> where T : class
    {
        private readonly SpotifakeDBContext _dbContext;
        private readonly ILogger<SpotifakeRepository<T>> _logger;

        public SpotifakeRepository(SpotifakeDBContext dbContext,
            ILogger<SpotifakeRepository<T>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public string Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting Item");
                var t = _dbContext.Set<T>().Find(id);
                if(t == null)
                {
                    throw new Exception("Item not find");
                }
                _dbContext.Set<T>().Remove(t);
                _dbContext.SaveChanges();
                _logger.LogInformation("Item deletd");
                return "Entity deleted successfully";
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                _logger.LogInformation("Get all item");
                var list = _dbContext.Set<T>().ToList();
                if(list==null)
                {
                    throw new Exception("Item not find");
                }
                _logger.LogInformation("All items found");
                return list;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
            
        }

        public T GetById(int id)
        {
            try
            {
                _logger.LogInformation("Finding item by id");
                var t = _dbContext.Set<T>().Find(id);
                if(t == null)
                {
                    throw new Exception("Item not found");
                }
                _logger.LogInformation("Item found");
                return t;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        public void SaveData(T t)
        {
            try
            {
                _logger.LogInformation($"Try Insert item in DB");
                _dbContext.Add(t);
                _dbContext.SaveChanges();
                _logger.LogInformation("Item inser into DB");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        public void Update(int id, T t)
        {
            try
            {
                _logger.LogInformation("Update entity");
                var tToUp = _dbContext.Set<T>().Find(id);
                if(tToUp == null )
                {
                    throw new InvalidOperationException("Entity Nont Found");
                }
                _dbContext.Entry(tToUp).CurrentValues.SetValues(t);
                _dbContext.SaveChanges();
                _logger.LogInformation("Entity Update!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }
    }

}
