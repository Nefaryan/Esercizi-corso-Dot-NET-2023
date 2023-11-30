using Microsoft.Extensions.Logging;
using SpotifakeBusinessLogic.Interfaces;
using SpotifakeBusinessLogic.Service;
using SpotifakeData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeBusinessLogic
{
    public class MediaPlayer : IMediaPlayer
    {

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
                    // Puoi formattare e visualizzare le informazioni sulle canzoni come preferisci
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
            throw new NotImplementedException();
        }

        public string PauseSong()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public string PreviousSong(User user)
        {
            throw new NotImplementedException();
        }

        public string StopSong()
        {
            throw new NotImplementedException();
        }
    }
}
