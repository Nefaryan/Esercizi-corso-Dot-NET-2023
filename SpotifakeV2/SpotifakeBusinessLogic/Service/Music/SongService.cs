using Microsoft.Extensions.Logging;
using SpotifakeData.DTO;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class SongService
    {
        private readonly SongRepository _songRepository;
        private readonly ILogger<SongService> _logger;

        public SongService(SongRepository songRepository, ILogger<SongService> logger)
        {
            _songRepository = songRepository;
            _logger = logger;
        }

        public List<SongDTO> GetAllSongs()
        {
            try
            {
                var songs = _songRepository.GetAll();
                return songs.Select(song => new SongDTO(song)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero di tutte le canzoni.");
                throw;
            }
        }

        public SongDTO? GetSongById(int id)
        {
            try
            {
                var song = _songRepository.GetById(id);
                return song != null? new SongDTO(song) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della canzone con ID {id}.");
                throw;
            }
        }
        public SongDTO? GetSongByName(string name)
        {
            try
            {
                var song = _songRepository.GetByName(name);
                return song != null ? new SongDTO(song) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della canzone con nome {name}.");
                throw;
            }
        }
        public void AddSong(Song song)
        {
            try
            {
                _songRepository.Add(song);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone con ID {song.Id}.");
                throw;
            }
        }

        public List<SongDTO> GetTop5Song()
        {
            try
            {
                var songList = _songRepository.GetAll();

                var topSongs = songList.OrderByDescending(song => song.Rating).Take(5).ToList();
                return topSongs.Select(song => new SongDTO(song)).ToList();

            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "Errore durante la restituzione delle canzoni con il rating più alto.");
                throw;

            }
        }

    }
}
