using Microsoft.Extensions.Logging;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeBusinessLogic.Service
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

        public List<Song> GetAllSongs()
        {
            try
            {
                return _songRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero di tutte le canzoni.");
                throw;
            }
        }

        public Song GetSongById(int id)
        {
            try
            {
                return _songRepository.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della canzone con ID {id}.");
                throw;
            }
        }
        public Song GetSongByNeame(string name)
        {
            try
            {
                return _songRepository.GetByName(name);
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

        public List<Song> GetTop5Song()
        {
            try
            {
                var songList = _songRepository.GetAll();

                var song = songList.OrderByDescending(song => song.Rating).Take(5).ToList();
                return song;

            }catch(Exception ex) 
            {
                _logger.LogError(ex, "Errore durante la restituzione delle canzoni con il rating più alto.");
                throw;

            }
        }

    }
}
