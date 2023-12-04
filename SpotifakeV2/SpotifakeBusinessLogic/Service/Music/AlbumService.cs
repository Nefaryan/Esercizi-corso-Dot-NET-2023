﻿using Microsoft.Extensions.Logging;
using SpotifakeData.DTO.AlbumsDTO;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class AlbumService
    {
        private readonly AlbumRepository _albumRepository;
        private readonly ILogger<AlbumService> _logger;

        public AlbumService(AlbumRepository albumRepository, ILogger<AlbumService> logger)
        {
            _albumRepository = albumRepository;
            _logger = logger;
        }

        public List<AlbumDTO> GetAllAlbums()
        {
            try
            {
                var allAlbum = _albumRepository.GetAll();
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
                _logger.LogError(ex, $"Errore durante il recupero dell'album con ID {id}.");
                throw;
            }
        }

        public void AddAlbum(Album album)
        {
            try
            {
                _albumRepository.Add(album);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'album con ID {album.ID}.");
                throw;
            }
        }

        public List<AlbumDTO> GetTop5Album()
        {
            try
            {
                var allAlbums = _albumRepository.GetAll();
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
