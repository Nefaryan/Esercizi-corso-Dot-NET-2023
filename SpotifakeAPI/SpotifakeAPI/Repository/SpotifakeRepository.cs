using Microsoft.Extensions.Logging;
using SpotifakeAPI.Models;
using SpotifakeAPI.Repository.Repository;
using System;
using System.Collections.Generic;

namespace SpotifakeAPI.Repository
{
    public class SpotifakeRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SpotifakeDBContext _dbContext;
        private readonly ILogger<SpotifakeRepository<T>> _logger;

        public string Delete(int id)
        {
            try
            {
                throw new System.NotImplementedException();
            }
            catch(Exception ex)
            {
                throw new System.NotImplementedException();
            }
        }

        public List<T> GetAll()
        {
            try
            {
               throw new System.NotImplementedException();
            }
            catch(Exception ex)
            {
                throw new System.NotImplementedException();
            }
            
        }

        public T GetById(int id)
        {
            try
            {
                throw new System.NotImplementedException();
            }
            catch(Exception ex)
            {
                throw new System.NotImplementedException();
            }
        }

        public void SaveData(T t)
        {
            try
            {
                throw new System.NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException();
            }
        }

        public void Update(int id, T t)
        {
            try
            {
                throw new System.NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException();
            }
        }
    }

}
