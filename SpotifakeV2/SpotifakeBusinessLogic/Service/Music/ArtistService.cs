using Microsoft.Extensions.Logging;
using SpotifakeData.DTO;
using SpotifakeData.DTO.AlbumsDTO;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository;
using SpotifakeData.Repository.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class ArtistService
    {
        private readonly GenericRepository<Artist> _artistRepository;
        private readonly AlbumService albumService;
        private readonly SongService songService;
        private readonly ILogger<ArtistService> _logger;

        public ArtistService(
            GenericRepository<Artist> genericRepository,
            AlbumService albumServices,
            SongService songServ,
            ILogger<ArtistService> logger)
        {
            _artistRepository = genericRepository;
            albumService = albumServices;
            songService = songServ;
            _logger = logger;
        }

        public void CreateAlbumForArtist(int artistId, AlbumDTO albumDTO)
        {
            try
            {
                var artist = _artistRepository.GetById(artistId);
                if (artist == null)
                {
                    _logger.LogError($"Artista con ID {artistId} non trovato.");
                    return;
                }
                albumDTO.Artist = artist;
                albumService.AddAlbum(albumDTO);
                _logger.LogInformation($"Album '{albumDTO.Title}' creato con successo per l'artista '{artist.ArtistName}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la creazione dell'album per l'artista con ID {artistId}.");
                throw;
            }
        }

        public void CreateSongForArtist(int artistId, SongDTO songDTO)
        {
            try
            {
                var artist = _artistRepository.GetById(artistId);
                if (artist == null)
                {
                    _logger.LogError($"Artista con ID {artistId} non trovato.");
                    return;
                }
                songDTO.Artists= new List<Artist> { artist };
                songService.AddSong(songDTO);
                _logger.LogInformation($"Canzone '{songDTO.Title}' creata con successo per l'artista '{artist.ArtistName}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la creazione della canzone per l'artista con ID {artistId}.");
                throw;
            }
        }

        public void AddSongToAlbum(int albumId, SongDTO songDTO)
        {
            try
            {
                var album = albumService.GetAlbumById(albumId);
                if (album == null)
                {
                    _logger.LogError($"Album con ID {albumId} non trovato.");
                    return;
                }
                Song song = new Song();
                song.Title = songDTO.Title;
                song.Id = songDTO.ID;
                song.ReleaseDate = songDTO.ReleaseDate;
                song.Genre = songDTO.Genre;
                song.Rating = songDTO.Raiting;
                album.Songs.Add(song);
                songService.AddSong(songDTO);
                _logger.LogInformation($"Canzone '{song.Title}' aggiunta con successo all'album '{album.Title}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone all'album con ID {albumId}.");
                throw;
            }
        }

        public void AddSongToArtist(int artistId, SongDTO songDTO)
        {
            try
            {
                var artist = _artistRepository.GetById(artistId);
                if (artist == null)
                {
                    _logger.LogError($"Artista con ID {artistId} non trovato.");
                    return;
                }
                Song song = new Song();
                song.Title = songDTO.Title;
                song.Id = songDTO.ID;
                song.ReleaseDate = songDTO.ReleaseDate;
                song.Genre = songDTO.Genre;
                song.Rating = songDTO.Raiting;
                song.Artists = new List<Artist> { artist };
                songService.AddSong(songDTO);
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
