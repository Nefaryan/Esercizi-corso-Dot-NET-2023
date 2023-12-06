using Microsoft.Extensions.Logging;
using SpotifakeData.DataContext;
using SpotifakeData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Repository
{
    public class MovieRepository
    {
        private readonly string _folderPath = @"C:\Users\giuse\Desktop\SpotiFake\Movie";
        private readonly ILogger<MovieRepository> _logger;
        private DBContext _dbContext;

        public MovieRepository(ILogger<MovieRepository> logger)
        {
            _logger = logger;
            _dbContext = new DBContext(_folderPath);
        }

        public List<Movie> GetAll()
        {
            try
            {
                return _dbContext.GetAll<Movie>();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Errore durante la letture dei film");
                throw;
            }
        }
        public Movie GetById(int id)
        {
            try
            {
                return _dbContext.GetById<Movie>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Eorre durante la lettura dell film con Id: {id}", ex);
                throw;
            }
        }

    /*    public Movie GetByName(string name)
        {
            try
            {
                return _dbContext.GetByName<Movie>(name);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Eorre durante la lettura dell film con il nome: {name}", ex);
                throw;
            }
        }*/

        public void Added(Movie movie)
        {
            try
            {
                _dbContext.Add(movie);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Erorre durante l'iserimento del movie");
                throw;
            }
        }
    }
}
