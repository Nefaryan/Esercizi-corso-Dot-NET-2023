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

        public List<MovieRepository> GetAll()
        {
            return null;
        }
        public Movie GetById(int id)
        {
            return null;
        }

        public Movie GetByName(string name)
        {
            return null;
        }

        public void Added(Movie movie)
        {
           //TODO
        }
    }
}
