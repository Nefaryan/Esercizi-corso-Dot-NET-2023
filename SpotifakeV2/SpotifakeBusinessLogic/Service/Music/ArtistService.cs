using Microsoft.Extensions.Logging;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository.OLD.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class ArtistService
    {
        private readonly ArtistRepository _artistRepository;
        private readonly AlbumRepository _albumRepository;
        private readonly SongRepository _songRepository;
        private readonly ILogger<ArtistService> _logger;

        public ArtistService(
            ArtistRepository artistRepository,
            AlbumRepository albumRepository,
            SongRepository songRepository,
            ILogger<ArtistService> logger)
        {
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
            _songRepository = songRepository;
            _logger = logger;
        }

        public void CreateAlbumForArtist(int artistId, Album album)
        {
            try
            {
                var artist = _artistRepository.GetById(artistId);
                if (artist == null)
                {
                    _logger.LogError($"Artista con ID {artistId} non trovato.");
                    return;
                }
                album.Artist = artist;
                _albumRepository.Add(album);
                _logger.LogInformation($"Album '{album.Title}' creato con successo per l'artista '{artist.ArtistName}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la creazione dell'album per l'artista con ID {artistId}.");
                throw;
            }
        }

        public void CreateSongForArtist(int artistId, Song song)
        {
            try
            {
                var artist = _artistRepository.GetById(artistId);
                if (artist == null)
                {
                    _logger.LogError($"Artista con ID {artistId} non trovato.");
                    return;
                }
                song.Artists = new List<Artist> { artist };
                _songRepository.Add(song);
                _logger.LogInformation($"Canzone '{song.Title}' creata con successo per l'artista '{artist.ArtistName}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la creazione della canzone per l'artista con ID {artistId}.");
                throw;
            }
        }

        public void AddSongToAlbum(int albumId, Song song)
        {
            try
            {
                var album = _albumRepository.GetById(albumId);
                if (album == null)
                {
                    _logger.LogError($"Album con ID {albumId} non trovato.");
                    return;
                }
                song.Albums = new List<Album> { album };
                _songRepository.Add(song);
                _logger.LogInformation($"Canzone '{song.Title}' aggiunta con successo all'album '{album.Title}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone all'album con ID {albumId}.");
                throw;
            }
        }

        public void AddSongToArtist(int artistId, Song song)
        {
            try
            {
                var artist = _artistRepository.GetById(artistId);
                if (artist == null)
                {
                    _logger.LogError($"Artista con ID {artistId} non trovato.");
                    return;
                }
                song.Artists = new List<Artist> { artist };
                _songRepository.Add(song);
                _logger.LogInformation($"Canzone '{song.Title}' aggiunta con successo all'artista '{artist.ArtistName}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone all'artista con ID {artistId}.");
                throw;
            }
        }
    }
}
