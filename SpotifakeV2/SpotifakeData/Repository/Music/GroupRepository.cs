using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Repository.Music
{
    public class GroupRepository
    {
        private readonly string _folderPath =  @"C:\Users\giuse\Desktop\SpotiFake\Group";
        private readonly ILogger<GroupRepository> _logger;

        public GroupRepository(string folderPath, ILogger<GroupRepository> logger)
        {
            _folderPath = folderPath;
            _logger = logger;

            Directory.CreateDirectory(_folderPath);
        }

        public List<Group> GetAll()
        {
            try
            {
                var groups = new List<Group>();

                foreach (var file in Directory.GetFiles(_folderPath, " *.json"))
                {
                    var jsonData = File.ReadAllText(file);
                    var group = JsonConvert.DeserializeObject<Group>(jsonData);
                    groups.Add(group);
                }

                return groups;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura di tutti i gruppi.");
                throw;
            }
        }

        public Group GetById(int id)
        {
            try
            {
                var filePath = Path.Combine(_folderPath, $"{id}.json");

                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<Group>(jsonData);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la lettura del gruppo con ID {id}.");
                throw;
            }
        }

        public void Add(Group group)
        {
            try
            {
                var groupId = group.Id;
                var filePath = Path.Combine(_folderPath, $"{groupId}.json");

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                var jsonData = JsonConvert.SerializeObject(group, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta del gruppo con ID {group.Id}.");
                throw;
            }
        }
    }
}
