using Microsoft.Extensions.Logging;
using SpotifakeService.Interfaces;
using SpotifakeService.Service;
using SpotifakeData.Entity;
using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SpotifakeData.DTO;
using SpotifakeData.DTO.AlbumsDTO;

namespace SpotifakeService
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

                    var songInfo = allSongs.Select(song => $" {song.ID} - {song.Title}").ToList();
                    var result = string.Join(Environment.NewLine, songInfo);// Ogni elemento della lista verrà stampato su una nuova linea

                    _logger.LogInformation("Visualizzazione di tutte le canzoni.");

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

        public string SeeAllAlbum()
        {
            try
            {
                var allAlbum = _albumService.GetAllAlbums();
                if (allAlbum.Any())
                {
                    var albumInfo = allAlbum.Select(album => $"{album.ID} - {album.Title}").ToList();
                    var result = string.Join(Environment.NewLine, albumInfo);

                    _logger.LogInformation("Visualizzazione di tutti gli album");

                    return result;
                }
                else
                {
                    _logger.LogInformation("Nessun album disponibile");
                    return "Nessun album disponibile";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la visualizzazione degli album");
                return "Erorre durante la visualizzazione degli album";
            }
        }

        public string Top5Album()
        {
            return GetTop5(
                () => _albumService.GetTop5Album(),
                album => $"{album.Title} - {album.Songs.FirstOrDefault()?.Title}",
                "Nessun album trovato"
            );
        }

        public string Top5Song()
        {
            return GetTop5(
                () => _songService.GetTop5Song(),
                song => $" {song.ID} - {song.Title}",
                "Nessuna canzone disponibile per la visualizzazione delle top 5."
            );
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
            try
            {
                var album = _albumService.GetAlbumById(albumId);
                if (album != null && album.Songs != null && album.Songs.Any())
                {
                    currentSongIndex = -1;
                    return PlayNextSongInAlbum(u, album);

                }
                else
                {
                    return $"L'album non è stato trovato";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"L'album con id {albumId} non è stato trovato");
                return $"Errore durante la riproduzione de'album con Id {albumId}.";
            }
        }

        public string SeeAllPlayList()
        {
            try
            {
                var allPlaylist = _playlistService.GetAllPlaylist();
                if (allPlaylist.Any())
                {
                    var playlistInfo = allPlaylist.Select(p => $"{p.ID} - {p.Name}").ToList();
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
            catch (Exception ex)
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

                    currentSongIndex = -1;

                    return PlayNextSongInPlaylist(user, playlist);
                }
                else
                {
                    return $"La playlist con Id {playlistId} non è stata trovata o è vuota.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la riproduzione della playlist con Id {playlistId} per l'utente '{user.Username}'.");
                return $"Errore durante la riproduzione della playlist con Id {playlistId}.";
            }
        }

         public string PlaySong(User u, string songName)
          {
              try
              {
                  var song = _songService.GetSongByName(songName);

                  if (song != null)
                  {
                      if (CanUserPlaySong(u, song))
                      {
                          song.Raiting++;
                          UpdateUserRemainingTime(u, song.Duration);

                          _isPlaying = true;
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
                        song.Raiting++;
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

        private string PlayCurrentSong(SongDTO song)
        {
            string result = $"Playing: {song.Title}";
            return result;
        }

        private SongDTO RunRandomSong()
        {
            List<SongDTO> songs = _songService.GetAllSongs();
            Random random = new Random();
            SongDTO randomSong = songs[random.Next(songs.Count)];
            PlayCurrentSong(randomSong);
            return randomSong;
        }

        //Metodo per controllare se L'utente può riprodurre la canzone
        private bool CanUserPlaySong(User user, SongDTO song)
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

        private string PlayNextSongInPlaylist(User user, PlaylistDTO playlist)
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

        private string PlayNextSongInAlbum(User user, AlbumDTO album)
        {
            try
            {
                var allSongs = album.Songs;

                if (currentSongIndex < allSongs.Count)
                {
                    currentSongIndex++;
                    return PlaySongById(user, allSongs[currentSongIndex].Id);
                }
                else
                {
                    return "Album ended";
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la riproduzione dell'album");
                return "An error occurred during the PlayNextSongInAlbum operation.";
            }

        }

        private string GetTop5<T>(Func<List<T>> getDataFunc, Func<T, string> projectionFunc, string errorMessage)
        {
            try
            {
                var data = getDataFunc();

                if (data.Any())
                {
                    var info = data.Select(projectionFunc).ToList();
                    var result = string.Join(Environment.NewLine, info);

                    _logger.LogInformation($"Visualizzazione delle top 5 {typeof(T).Name}.");

                    return result;
                }
                else
                {
                    _logger.LogInformation($"Nessun {typeof(T).Name} trovato.");
                    return $"Nessun {typeof(T).Name} trovato.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la visualizzazione delle top 5 {typeof(T).Name}.");
                return $"Errore durante la visualizzazione delle top 5 {typeof(T).Name}.";
            }
        }
    }
}
