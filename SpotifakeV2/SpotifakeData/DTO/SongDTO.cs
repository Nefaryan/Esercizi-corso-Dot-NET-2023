using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.DTO
{
    public class SongDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Raiting { get; set; }
        public List<Artist> Artists { get; set; } 
        public List<Album> Albums { get; set; }
        public SongDTO(Song song) 
        {
            ID = song.Id;
            Title = song.Title; 
            Genre = song.Genre; 
            Duration = song.Duration;
            ReleaseDate = song.ReleaseDate;
            Raiting = song.Rating;
            Artists = song.Artists;
            Albums = song.Albums;
        }
    }
}
