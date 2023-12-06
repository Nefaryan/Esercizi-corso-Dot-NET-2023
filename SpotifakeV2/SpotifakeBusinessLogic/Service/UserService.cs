using Microsoft.Extensions.Logging;
using SpotifakeData.Entity.Music;
using SpotifakeData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifakeData.Repository.OLD.Music;
using SpotifakeData.Repository.OLD;

namespace SpotifakeService.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly PlaylistRepository _playlistRepository;
        private readonly SongRepository _songRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(
            UserRepository userRepository,
            PlaylistRepository playlistRepository,
            SongRepository songRepository,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _playlistRepository = playlistRepository;
            _songRepository = songRepository;
            _logger = logger;
        }

        public void CreateUser(User user)
        {
            try
            {
                _userRepository.Add(user);
                _logger.LogInformation($"Utente '{user.Username}' creato con successo.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la creazione dell'utente '{user.Username}'.");
                throw;
            }
        }

        public void AddPlaylistToUser(int userId, int playlistId)
        {
            try
            {
                var user = _userRepository.GetById(userId);
                var playlist = _playlistRepository.GetById(playlistId);

                if (user != null && playlist != null)
                {
                    if (user.Playlist == null)
                    {
                        user.Playlist = new List<Playlist>();
                    }

                    user.Playlist.Add(playlist);
                    _userRepository.Add(user);

                    _logger.LogInformation($"Playlist '{playlist.Name}' aggiunta con successo all'utente '{user.Username}'.");
                }
                else
                {
                    _logger.LogError($"Utente o playlist non trovata con gli ID forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della playlist all'utente con ID {userId}.");
                throw;
            }
        }

        public void AddSongToPlaylist(int userId, int playlistId, int songId)
        {
            try
            {
                var user = _userRepository.GetById(userId);
                var playlist = user?.Playlist?.FirstOrDefault(p => p.Id == playlistId);
                var song = _songRepository.GetById(songId);

                if (user != null && playlist != null && song != null)
                {
                    if (playlist.Songs == null)
                    {
                        playlist.Songs = new List<Song>();
                    }

                    playlist.Songs.Add(song);
                    _userRepository.Add(user);

                    _logger.LogInformation($"Canzone '{song.Title}' aggiunta con successo alla playlist '{playlist.Name}' dell'utente '{user.Username}'.");
                }
                else
                {
                    _logger.LogError($"Utente, playlist o canzone non trovata con gli ID forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone alla playlist dell'utente con ID {userId}.");
                throw;
            }
        }

        public void DeletePlaylist(int userId, int playlistId)
        {
            try
            {
                var user = _userRepository.GetById(userId);
                var playlistToRemove = user?.Playlist?.FirstOrDefault(p => p.Id == playlistId);

                if (user != null && playlistToRemove != null)
                {
                    user.Playlist.Remove(playlistToRemove);
                    _userRepository.Add(user);

                    _logger.LogInformation($"Playlist '{playlistToRemove.Name}' eliminata con successo dall'utente '{user.Username}'.");
                }
                else
                {
                    _logger.LogError($"Utente o playlist non trovata con gli ID forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione della playlist dall'utente con ID {userId}.");
                throw;
            }
        }

        public User? LogIn(string username, string password)
        {
            try
            {
                var ListOfUser = _userRepository.GetAll();

                var user = ListOfUser.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
                if (user != null)
                {
                    _logger.LogInformation($"Login successful for user '{username}'.");
                    return user;
                }
                else
                {
                    _logger.LogInformation($"Login failed for user '{username}'.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during the login operation.");
                throw; 
            }
        }
    }
}

