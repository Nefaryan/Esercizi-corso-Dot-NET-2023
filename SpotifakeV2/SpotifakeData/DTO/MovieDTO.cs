using SpotifakeData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.DTO
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string Regista { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int ID { get; set; }
        public int Raiting { get; set; }
        public DateTime ReleaseDate { get; set; }

        public MovieDTO(Movie movie)
        {
            Title = movie.Title;
            Regista = movie.Regista;
            Duration = movie.Duration;
            Genre = movie.Genre;
            ID = movie.Id;
            Raiting = movie.Raiting;
            ReleaseDate = movie.ReleaseDate1;
        }
    }
}
