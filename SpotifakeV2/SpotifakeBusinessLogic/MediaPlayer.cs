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

        public string PlayAlbum(User u, int albumId)
        {
            throw new NotImplementedException();
        }

        public string SeeAllPlayList()
        {
            try
            {
                var allPlaylist = _playlistService.GetAllPlaylist();
                if (allPlaylist.Any())
                {
                    var playlistInfo = allPlaylist.Select(p => $"{p.Id} - {p.Name}").ToList();
                    var result = string.Join(Environment.NewLine, playlistInfo);

                    _logger.LogInformation($"Visualizzazione di tutte le playlist");
                    return result;
                }
                else
                {
                    _logger.LogInformation($"Nessuna playlist disponibile");
                    return "Nessuna playlist disponibile";
                }
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "Errore");
                return "Errore durante la visualizzazione delle playlist";

            }
            
        }

        public string PlayPlaylist(User user, int playlistId)
        {
            try
            {
                var playlist = _playlistService.GetAllPlaylistById(playlistId);

                if (playlist != null && playlist.Songs != null && playlist.Songs.Any())
                {
                    // Imposta l'indice corrente a -1 per indicare che la riproduzione è iniziata dalla prima canzone
                    currentSongIndex = -1;

                    return PlayNextSongInPlaylist(user, playlist);
                }
                else
                {
                    return $"La playlist con ID {playlistId} non è stata trovata o è vuota.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la riproduzione della playlist con ID {playlistId} per l'utente '{user.Username}'.");
                return $"Errore durante la riproduzione della playlist con ID {playlistId}.";
            }
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
                        RunRandomSong();
                        return "Impossibile riprodurre la canzone. Controlla il tuo abbonamento e il tempo rimanente," +
                            "fino a quel momento ascolterai canzoni completamente randomiche";
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

        public string PlaySongById(User u, int Id)
        {
            try
            {
                var song = _songService.GetSongById(Id);

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
                        RunRandomSong();
                        return "Impossibile riprodurre la canzone. Controlla il tuo abbonamento e il tempo rimanente," +
                            "fino a quel momento ascolterai canzoni completamente randomiche";
                    }
                }
                else
                {
                    _logger.LogInformation($"La canzone '{song.Title}' non è stata trovata.");
                    return $"La canzone '{song.Title}' non è stata trovata.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la riproduzione della canzone");
                return "Errore durante la riproduzione della canzone";
            }
        }


        public string PreviousSong(User user)
        {
            try
            {
                if (user.Setting.PremiumType == PremiumTypeEnum.GOLD)
                {
                    var allSongs = _songService.GetAllSongs();

                    if (currentSongIndex > 0)
                    {
                        currentSongIndex--;
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

        private string PlayCurrentSong(Song song)
        {
            string result = $"Playing: {song.Title}";
            Console.WriteLine(result);
            return result;
        }

        public Song RunRandomSong()
        {
            List<Song> songs = _songService.GetAllSongs();
            Random random = new Random();
            Song randomSong = songs[random.Next(songs.Count)];
            PlayCurrentSong(randomSong);
            return randomSong;
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

        private string PlayNextSongInPlaylist(User user, Playlist playlist)
        {
            try
            {
                
                currentSongIndex++;

                if (currentSongIndex < playlist.Songs.Count)
                {
                    var nextSong = playlist.Songs[currentSongIndex];
                    return PlaySong(user, nextSong.Title);
                }
                else
                {
                    currentSongIndex = -1; 
                    return "Playlist completata.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la riproduzione della prossima canzone della playlist per l'utente '{user.Username}'.");
                return "Errore durante la riproduzione della prossima canzone della playlist.";
            }
        }
    }
}
