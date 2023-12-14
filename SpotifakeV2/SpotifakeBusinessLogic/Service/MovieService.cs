using Microsoft.Extensions.Logging;
using SpotifakeData.DTO;
using SpotifakeData.Entity;
using SpotifakeData.Repository;
using SpotifakeData.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class MovieService
    {
        private readonly IGenericRepository<Movie> _repository;
        private readonly ILogger<MovieService> _logger;

        public MovieService(IGenericRepository<Movie> repository, ILogger<MovieService> logger)
        {
             _repository =repository;
             _logger = logger;
        }

        public List<MovieDTO> GetMovies()
        {
            try
            {
                var movies = _repository.GetALL();
                return movies.Select(m => new MovieDTO(m)).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero dei film");
                throw;
            }
        }
        public MovieDTO? GetMovieById(int id)
        {
            try
            {
                var movie = _repository.GetById(id);
                return movie != null ? new MovieDTO(movie) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero del film con Id {id}.");
                throw;
            }
        }
       public MovieDTO? GetMovieByName(string name) 
        {
            try
            {
                var movie = _repository.GetALL().FirstOrDefault(m => m.Title == name);
                return movie != null ? new MovieDTO(movie) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero del film con nome {name}.");
                throw;
            }

        }
        public void AddMovie(MovieDTO movieDTO)
        {
            try
            {
                Movie movie = new Movie();
                movie.Title = movieDTO.Title;
                movie.Duration = movieDTO.Duration;
                movie.Regista  = movieDTO.Regista;
                movie.Raiting = movieDTO.Raiting;
                movie.Genre = movieDTO.Genre;
                _repository.Add(movie);
            }
            catch(Exception ex )
            {
                _logger.LogError(ex,$"Errore durante l'aggiunta del movie");
                throw; 
            }
        }

        public List<MovieDTO> GetTop5Movie()
        {
            try
            {
                var allMovie = _repository.GetALL();
                var movieWithTopRating = allMovie.OrderByDescending(m => m.Raiting).Take(5).ToList();
                return movieWithTopRating.Select(m => new MovieDTO(m)).ToList();
            }
            catch(Exception ex )
            {
                _logger.LogError(ex, "Errore durante la selezione dei movie");
                throw;
            
            }
        }
    }
}
