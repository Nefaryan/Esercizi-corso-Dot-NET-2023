using Microsoft.Extensions.Logging;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class PlaylistService
    {
        private readonly PlaylistRepository _playlistRepository;
        private readonly SongRepository _songRepository;
        private readonly ILogger<PlaylistService> _logger;

        public PlaylistService(
            PlaylistRepository playlistRepository,
            SongRepository songRepository,
            ILogger<PlaylistService> logger)
        {
            _playlistRepository = playlistRepository;
            _songRepository = songRepository;
            _logger = logger;
        }

        public void CreatePlaylist(Playlist playlist)
        {
            try
            {
                _playlistRepository.Add(playlist);
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
                var playlist = _playlistRepository.GetById(playlistId);
                var song = _songRepository.GetById(songId);

                if (playlist != null && song != null)
                {
                    if (playlist.Songs == null)
                    {
                        playlist.Songs = new List<Song>();
                    }

                    playlist.Songs.Add(song);
                    _playlistRepository.Add(playlist);

                    _logger.LogInformation($"Canzone '{song.Title}' aggiunta con successo alla playlist '{playlist.Name}'.");
                }
                else
                {
                    _logger.LogError($"Playlist o canzone non trovata con gli ID forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone alla playlist con ID {playlistId}.");
                throw;
            }
        }

        public List<Playlist> GetAllPlaylist()
        {
            try
            {
                return _playlistRepository.GetAll();

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}", ex);
                throw;
            
            }
        }

        public Playlist GetAllPlaylistById(int playlistId)
        {
            try
            {
               return _playlistRepository.GetById(playlistId);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della playlist con ID {playlistId}.");
                throw;
            }
        }
    }
}
