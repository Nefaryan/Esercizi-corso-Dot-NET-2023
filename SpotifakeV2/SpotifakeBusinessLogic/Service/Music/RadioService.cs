using Microsoft.Extensions.Logging;
using SpotifakeData.DTO;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository;
using SpotifakeData.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service.Music
{
    public class RadioService
    {
        private readonly IGenericRepository<Radio> _repository;
        private readonly SongService _songService;
        private readonly ILogger<RadioService> _logger;

        public RadioService (IGenericRepository<Radio> repository, ILogger<RadioService> logger, SongService songService)
        {
            _repository = repository;
            _logger = logger;
            _songService = songService;
        }

        public RadioDTO GetById (int id)
        {
            try
            {
                var radio = _repository.GetById (id);
                return new RadioDTO(radio);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errore durante il recupero, {ex.Message}");
                throw;
            
            }
        }

        public void AddRadio(RadioDTO radioDTO)
        {
            try
            { 
                Radio radio = new Radio();
                radio.Id = radioDTO.Id;
                radio.Name = radioDTO.Name;
                radio.SongList = new List<Song>();
                _repository.Add(radio);
                
            }
            catch(Exception ex)
            {
                _logger.LogError($"Errore durante l'aggiunta della radio");
                throw;
            
            }
        }


    }
}
