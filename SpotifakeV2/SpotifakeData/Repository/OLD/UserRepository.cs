using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpotifakeData.DataContext;
using SpotifakeData.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Repository
{
    public class UserRepository
    {
        private readonly string _folderPath = @"C:\Users\giuse\Desktop\SpotiFake\User";
        private readonly ILogger<UserRepository> _logger;
        private DBContext _dbContext;
        
        public UserRepository( ILogger<UserRepository> logger)
        {
            
            _logger = logger;
            _dbContext = new DBContext(_folderPath);
        }

        public List<User> GetAll()
        {
            try
            {
              return _dbContext.GetAll<User>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura di tutti gli utenti.");
                throw;
            }
        }

        public User GetById(int id)
        {
            try
            {
               return _dbContext.GetById<User>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la lettura dell'utente con ID {id}.");
                throw;
            }
        }

        public void Add(User user)
        {
            try
            {
                _dbContext.Add(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'utente.");
                throw;
            }
        }
    }
}
