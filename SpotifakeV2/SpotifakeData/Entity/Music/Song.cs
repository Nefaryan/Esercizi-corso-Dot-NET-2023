using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Entity.Music
{
    public class Song
    {
        int _Id;
        int _rating;
        string _title;
        string _genre;
        int _duration;
        DateTime _releaseDate;
        List<Album> _albums;
        List<Group> _group;
        List<Artist> _artists;
        public Song() { }

        public int Id { get => _Id; set => _Id = value; }
        public int Rating { get => _rating; set => _rating = value; }
        public string Title { get => _title; set => _title = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public DateTime ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public List<Album> Albums { get => _albums; set => _albums = value; }
        public List<Group> Group { get => _group; set => _group = value; }
        public List<Artist> Artists { get => _artists; set => _artists = value; }
    }
}
