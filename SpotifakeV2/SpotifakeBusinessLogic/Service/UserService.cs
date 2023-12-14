using Microsoft.Extensions.Logging;
using SpotifakeData.Entity.Music;
using SpotifakeData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifakeData.Repository;
using SpotifakeData.Repository.Interfaces;


namespace SpotifakeService.Service
{
    public class UserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly PlaylistService _playlistService;
        private readonly SongService _songService;
        private readonly ILogger<UserService> _logger;

        public UserService(
             IGenericRepository<User> userRepository,
            PlaylistService playlistSer,
            SongService songSer,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _playlistService = playlistSer;
            _songService = songSer;
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
                var playlist = _playlistService.GetAllPlaylistById(playlistId);

                if (user != null && playlist != null)
                {
                    if (user.Playlist == null)
                    {
                        user.Playlist = new List<Playlist>();
                    }

                    Playlist playlist1 = new Playlist();
                    playlist1.Id = playlist.ID;
                    playlist1.Name = playlist.Name;
                   
                    user.Playlist.Add(playlist1);
                    _userRepository.Add(user);

                    _logger.LogInformation($"Playlist '{playlist.Name}' aggiunta con successo all'utente '{user.Username}'.");
                }
                else
                {
                    _logger.LogError($"Utente o playlist non trovata con gli Id forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della playlist all'utente con Id {userId}.");
                throw;
            }
        }

        public void AddSongToPlaylist(int userId, int playlistId, int songId)
        {
            try
            {
                var user = _userRepository.GetById(userId);
                var playlist = user?.Playlist?.FirstOrDefault(p => p.Id == playlistId);
                var song = _songService.GetSongById(songId);

                if (user != null && playlist != null && song != null)
                {
                    if (playlist.Songs == null)
                    {
                        playlist.Songs = new List<Song>();
                    }

                    Song song1 = new Song();
                    song1.Id = songId;
                    song1.Title = song.Title;
                    song1.Genre = song.Genre;
                    song1.ReleaseDate = song.ReleaseDate;
                    song1.Duration = song.Duration;
                    playlist.Songs.Add(song1);
                    _userRepository.Add(user);

                    _logger.LogInformation($"Canzone '{song.Title}' aggiunta con successo alla playlist '{playlist.Name}' dell'utente '{user.Username}'.");
                }
                else
                {
                    _logger.LogError($"Utente, playlist o canzone non trovata con gli Id forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone alla playlist dell'utente con Id {userId}.");
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
                    _logger.LogError($"Utente o playlist non trovata con gli Id forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione della playlist dall'utente con Id {userId}.");
                throw;
            }
        }

        public User? LogIn(string username, string password)
        {
            try
            {
                var ListOfUser = _userRepository.GetALL();

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

