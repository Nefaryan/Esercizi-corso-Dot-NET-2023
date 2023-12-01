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
    public class GroupRepository
    {
        private readonly string _folderPath =  @"C:\Users\giuse\Desktop\SpotiFake\Group";
        private readonly ILogger<GroupRepository> _logger;
        private readonly DBContext dBContext;

        public GroupRepository(ILogger<GroupRepository> logger)
        {
           
            _logger = logger;
            dBContext = new DBContext(_folderPath);        
        }

        public List<Group> GetAll()
        {
            try
            {
                var groups = dBContext.GetAll<Group>();
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
                var Group = dBContext.GetById<Group>(id);
                return Group;
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
                dBContext.Add(group);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta del gruppo con ID {group.Id}.");
                throw;
            }
        }
    }
}
