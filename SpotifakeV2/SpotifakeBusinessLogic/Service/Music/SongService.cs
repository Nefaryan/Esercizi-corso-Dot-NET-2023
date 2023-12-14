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

namespace SpotifakeService.Service
{
    public class SongService
    {
        private readonly IGenericRepository<Song> _songRepository;
        private readonly ILogger<SongService> _logger;

        public SongService(IGenericRepository<Song> songRepository, ILogger<SongService> logger)
        {
            _songRepository = songRepository;
            _logger = logger;
        }

        public List<SongDTO> GetAllSongs()
        {
            try
            {
                var songs = _songRepository.GetALL();
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
                _logger.LogError(ex, $"Errore durante il recupero della canzone con Id {id}.");
                throw;
            }
        }
        public SongDTO? GetSongByName(string name)
        {
            try
            {
                var song = _songRepository.GetALL().FirstOrDefault(song => song.Title == name);
                return song != null ? new SongDTO(song) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della canzone con nome {name}.");
                throw;
            }
        }
        public void AddSong(SongDTO songDTO)
        {
            try
            {
                Song song = new Song();
                song.Id = songDTO.ID;
                song.Title = songDTO.Title;
                song.Duration = songDTO.Duration;
                song.Rating = songDTO.Raiting;
                song.ReleaseDate = songDTO.ReleaseDate;
                _songRepository.Add(song);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone con Id {songDTO.ID}.");
                throw;
            }
        }

        public List<SongDTO> GetTop5Song()
        {
            try
            {
                var songList = _songRepository.GetALL();

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
