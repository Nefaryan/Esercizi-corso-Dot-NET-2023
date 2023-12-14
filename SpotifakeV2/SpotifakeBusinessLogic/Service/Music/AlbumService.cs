using Microsoft.Extensions.Logging;
using SpotifakeData.DTO.AlbumsDTO;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository;
using SpotifakeData.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class AlbumService
    {
        private readonly IGenericRepository<Album> _albumRepository;
        private readonly ILogger<AlbumService> _logger;

        public AlbumService(IGenericRepository<Album> albumRepository, ILogger<AlbumService> logger)
        {
            _albumRepository = albumRepository;
            _logger = logger;
        }

        public List<AlbumDTO> GetAllAlbums()
        {
            try
            {
                var allAlbum = _albumRepository.GetALL();
                return allAlbum.Select(album => new AlbumDTO(album)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero di tutti gli album.");
                throw;
            }
        }

        public AlbumDTO? GetAlbumById(int id)
        {
            try
            {
                var album = _albumRepository.GetById(id);
                return album != null ? new AlbumDTO(album) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero dell'album con Id {id}.");
                throw;
            }
        }

        public void AddAlbum(AlbumDTO albumDTO)
        {
            try
            {
                Album album = new Album();
                album.Title = albumDTO.Title;
                album.NOfTrack = albumDTO.NumberOfTrack;
                _albumRepository.Add(album);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'album con Id {albumDTO.ID}.");
                throw;
            }
        }

        public List<AlbumDTO> GetTop5Album()
        {
            try
            {
                var allAlbums = _albumRepository.GetALL();
                var albumsWithAverageRating = allAlbums.Select(album =>
                {
                    // Calcola la media dei rating delle canzoni
                    double averageRating = album.Song?.Any() ?? false
                        ? album.Song.Average(song => song.Rating)
                        : 0;

                    // Assegna la media dei rating all'album
                    return new { Album = new AlbumDTO(album), AverageRating = averageRating };
                });

                // Ordina gli album per la media dei rating in ordine decrescente e prendi al massimo 5
                var sortedAlbums = albumsWithAverageRating.OrderByDescending(item => item.AverageRating)
                                                          .Take(5)
                                                          .Select(item => item.Album)
                                                          .ToList();
                return sortedAlbums;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la restituzione degli album con la media dei rating più alta.");
                throw;
            }
        }

    }
    
}
