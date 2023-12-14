using Microsoft.Extensions.Logging;
using SpotifakeData.DTO;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository;
using SpotifakeData.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class PlaylistService
    {
        private readonly IGenericRepository<Playlist> _repository;
        private readonly SongService _songService;
        private readonly ILogger<PlaylistService> _logger;

        public PlaylistService(
            IGenericRepository<Playlist> repository,
            SongService songService,
            ILogger<PlaylistService> logger)
        {
            _repository = repository;
            _songService = songService;
            _logger = logger;
        }

        public void CreatePlaylist(Playlist playlist)
        {
            try
            {
                _repository.Add(playlist);
                _logger.LogInformation($"Playlist '{playlist.Name}' creata con successo.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la creazione della playlist '{playlist.Name}'.");
                throw;
            }
        }

        public void AddSongToPlaylist(int playlistId, int songId)
        {
            try
            {
                var playlist = _repository.GetById(playlistId);
                var song = _songService.GetSongById(songId);

                if (playlist != null && song != null)
                {
                    if (playlist.Songs == null)
                    {
                        playlist.Songs = new List<Song>();
                    }

                    Song songs = new Song();
                    songs.Id = song.ID;
                    songs.Title = song.Title;
                    songs.Duration = song.Duration;
                    songs.ReleaseDate = song.ReleaseDate;
                    songs.Genre = song.Genre;


                    playlist.Songs.Add(songs);
                    _repository.Add(playlist);

                    _logger.LogInformation($"Canzone '{song.Title}' aggiunta con successo alla playlist '{playlist.Name}'.");
                }
                else
                {
                    _logger.LogError($"Playlist o canzone non trovata con gli Id forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone alla playlist con Id {playlistId}.");
                throw;
            }
        }

        public List<PlaylistDTO> GetAllPlaylist()
        {
            try
            {
                var list = _repository.GetALL();
                return list.Select(playlist => new PlaylistDTO(playlist)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}", ex);
                throw;
            
            }
        }

        public PlaylistDTO? GetAllPlaylistById(int playlistId)
        {
            try
            {
               var playlist = _repository.GetById(playlistId);
               return  playlist != null ? new PlaylistDTO(playlist) : null;    

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della playlist con Id {playlistId}.");
                throw;
            }
        }
    }
}
