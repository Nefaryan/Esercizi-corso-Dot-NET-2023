using Microsoft.Extensions.Logging;
using SpotifakeBusinessLogic.Interfaces;
using SpotifakeBusinessLogic.Service;
using SpotifakeData.Entity;
using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifakeBusinessLogic
{
    public class MediaPlayer : IMediaPlayer
    {
        private int currentSongIndex;
        private bool _isPlaying;
        private readonly SongService _songService;
        private readonly AlbumService _albumService;
        private readonly PlaylistService _playlistService;
        private readonly ILogger<MediaPlayer> _logger;

        public MediaPlayer(
            SongService songService,
            AlbumService albumService,
            PlaylistService playlistService,
            ILogger<MediaPlayer> logger)
        {
            _songService = songService;
            _albumService = albumService;
            _playlistService = playlistService;
            _logger = logger;
            currentSongIndex = 0;
            _isPlaying = false;
        }

        public string SeeAllSong()
        {
            try
            {
                var allSongs = _songService.GetAllSongs();

                if (allSongs.Any())
                {
                   
                    var songInfo = allSongs.Select(song => $" {song.Id} - {song.Title} - {song.Artists?.FirstOrDefault()?.ArtistName}").ToList();
                    var result = string.Join(Environment.NewLine, songInfo);// Ogni elemento della lista verrà stampato su una nuova linea

                    _logger.LogInformation($"Visualizzazione di tutte le canzoni.");

                    return result;
                }
                else
                {
                    _logger.LogInformation("Nessuna canzone disponibile.");
                    return "Nessuna canzone disponibile.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la visualizzazione di tutte le canzoni.");
                return "Errore durante la visualizzazione di tutte le canzoni.";
            }
        }

        public string Top5Song() 
        {
            try
            {
                var topSongs = _songService.GetTop5Song();

                if (topSongs.Any())
                {
                    
                    var songInfo = topSongs.Select(song => $" {song.Id} - {song.Title} - {song.Artists?.FirstOrDefault()?.ArtistName}").ToList();
                    var result = string.Join(Environment.NewLine, songInfo);

                    _logger.LogInformation($"Visualizzazione delle top 5 canzoni per rating.");

                    return result;
                }
                else
                {
                    _logger.LogInformation("Nessuna canzone disponibile per la visualizzazione delle top 5.");
                    return "Nessuna canzone disponibile per la visualizzazione delle top 5.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la visualizzazione delle top 5 canzoni.");
                return "Errore durante la visualizzazione delle top 5 canzoni.";
            }

        }

        public string NextSong(User user)
        {
            try
            {
                if (user.Setting.PremiumType == PremiumTypeEnum.GOLD)
                {
                    var allSongs = _songService.GetAllSongs();

                    if (currentSongIndex < allSongs.Count - 1)
                    {
                        currentSongIndex++;
                        return PlaySong(user, allSongs[currentSongIndex].Title);
                    }
                    else
                    {
                        return "Playlist ended";
                    }
                }
                else
                {
                    return "Activate the subscription to use this feature";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during the NextSong operation.");
                return "An error occurred during the NextSong operation.";
            }

        }

        public string PauseSong()
        {
            _isPlaying = false;
            return "Song stopped";
        }

        public string PlayAlbum(string albumName)
        {
            throw new NotImplementedException();
        }

        public string PlayPlaylist(User u, string playlistName)
        {
            throw new NotImplementedException();
        }

        public string PlaySong(User u, string songName)
        {
            try
            {
                var song = _songService.GetSongByNeame(songName);

                if (song != null)
                {
                    if (CanUserPlaySong(u, song))
                    {
                        song.Rating++;
                        UpdateUserRemainingTime(u, song.Duration);

                        return PlayCurrentSong(song);
                    }
                    else
                    {
                        return "Impossibile riprodurre la canzone. Controlla il tuo abbonamento e il tempo rimanente.";
                    }
                }
                else
                {
                    _logger.LogInformation($"La canzone '{songName}' non è stata trovata.");
                    return $"La canzone '{songName}' non è stata trovata.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la riproduzione della canzone '{songName}' per l'utente '{u.Username}'.");
                return $"Errore durante la riproduzione della canzone '{songName}'.";
            }
        }

        public string PreviousSong(User user)
        {
            throw new NotImplementedException();
        }

        public string StopSong()
        {
            throw new NotImplementedException();
        }

        private string PlayCurrentSong(Song song)
        {
            string result = $"Playing: {song.Title}";
            Console.WriteLine(result);
            return result;
        }
        //Metodo per controllare se L'utente può riprodurre la canzone
        private bool CanUserPlaySong(User user, Song song)
        {
            return user.Setting.RemainigTime > 0 || user.Setting.PremiumType == PremiumTypeEnum.GOLD;
        }

        //Metod per fare l'update del tempo rimanente
        private void UpdateUserRemainingTime(User user, int duration)
        {
            if (user.Setting.PremiumType != PremiumTypeEnum.GOLD)
            {
                user.Setting.RemainigTime -= duration;
            }
        }
    }
}
