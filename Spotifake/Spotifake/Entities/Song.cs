using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    internal class Song
    {
        string _name;
        string _genre;
        string _duration;
        string _relaseDate;
        List<Album> _albums;
        List<Gruop> _group;
        List<Artist> _artists;
    

        public Song(string name, string genre, string duration, string relaseDate)
        {
            _name = name;
            _genre = genre;
            _duration = duration;
            _relaseDate = relaseDate;
            _albums = new List<Album>();
            _group = new List<Gruop>();
            _artists = new List<Artist>();
        }
        public string Name { get => _name; set => _name = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public string Duration { get => _duration; set => _duration = value; }
        public string RelaseDate { get => _relaseDate; set => _relaseDate = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }
        internal List<Gruop> Group { get => _group; set => _group = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
    }
}
