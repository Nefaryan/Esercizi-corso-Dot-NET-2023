using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly string _folderPath = @"C:\Users\giuse\Desktop\SpotiFake\Albums\User";
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(string folderPath, ILogger<UserRepository> logger)
        {
            _folderPath = folderPath;
            _logger = logger;

            Directory.CreateDirectory(_folderPath);
        }

        public List<User> GetAll()
        {
            try
            {
                var users = new List<User>();

                foreach (var file in Directory.GetFiles(_folderPath, "*.json"))
                {
                    var jsonData = File.ReadAllText(file);
                    var user = JsonConvert.DeserializeObject<User>(jsonData);
                    users.Add(user);
                }

                return users;
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
                var filePath = Path.Combine(_folderPath, $"{id}.json");

                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<User>(jsonData);
                }

                return null;
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
                var userId = user.Id;
                var filePath = Path.Combine(_folderPath, $"{userId}.json");

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                var jsonData = JsonConvert.SerializeObject(user, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'utente con ID {user.Id}.");
                throw;
            }
        }
    }
}
