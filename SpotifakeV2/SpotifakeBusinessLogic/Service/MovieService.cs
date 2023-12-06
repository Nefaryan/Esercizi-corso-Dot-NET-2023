using Microsoft.Extensions.Logging;
using SpotifakeData.DTO;
using SpotifakeData.Entity;
using SpotifakeData.Repository.OLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class MovieService
    {
        private readonly MovieRepository repository;
        private readonly ILogger<MovieService> logger;

        public MovieService(MovieRepository repository, ILogger<MovieService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public List<MovieDTO> GetMovies()
        {
            try
            {
                var movies = repository.GetAll();
                return movies.Select(m => new MovieDTO(m)).ToList();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Errore durante il recupero dei film");
                throw;
            }
        }
        public MovieDTO? GetMovieById(int id)
        {
            try
            {
                var movie = repository.GetById(id);
                return movie != null ? new MovieDTO(movie) : null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Errore durante il recupero del film con ID {id}.");
                throw;
            }
        }
       /* public MovieDTO? GetMovieByName(string name) 
        {
            try
            {
                var movie = repository.GetByName(name);
                return movie != null ? new MovieDTO(movie) : null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Errore durante il recupero del film con nome {name}.");
                throw;
            }

        }*/
        public void AddMovie(Movie movie)
        {
            try
            {
                repository.Added(movie);
            }
            catch(Exception ex )
            {
                logger.LogError(ex,$"Errore durante l'aggiunta del movie");
                throw; 
            }
        }

        public List<MovieDTO> GetTop5Movie()
        {
            try
            {
                var allMovie = repository.GetAll();
                var movieWithTopRating = allMovie.OrderByDescending(m => m.Raiting).Take(5).ToList();
                return movieWithTopRating.Select(m => new MovieDTO(m)).ToList();
            }
            catch(Exception ex )
            {
                logger.LogError(ex, "Errore durante la selezione dei movie");
                throw;
            
            }
        }
    }
}
