using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spotifake.Model.Music
{
    public class Song
    {
        int _Id;
        int _rating;
        string _name;
        string _genre;
        int _duration;
        string _releaseDate;
        List<Album> _albums;
        List<Group> _group;
        List<Artist> _artists;

    

        public Song()
        {
            _artists = new List<Artist>();
            _albums = new List<Album>();
            _group = new List<Group>();
        }
        public Song(Artist artist, Album album, int duration, string genre, string title, string releaseDate)
        {
            _artists = new List<Artist>();
            _albums = new List<Album>();
            _duration = duration;
            _genre = genre;
            _name = title;
            _releaseDate = releaseDate;
            _artists.Add(artist);
            _albums.Add(album);
        }
        public Song(Group group, Album album, int duration, string genre, string title, string releaseDate)
        {
            _group = new List<Group>();
            _albums = new List<Album>();
            _duration = duration;
            _genre = genre;
            _name = title;
            _releaseDate = releaseDate;
            _group.Add(group);
            _albums.Add(album);
        }
        public Song(Artist artist, Group group, Album album, int duration, string genre, string title, string releaseDate)
        {
            _group = new List<Group>();
            _albums = new List<Album>();
            _artists = new List<Artist>();
            _duration = duration;
            _genre = genre;
            _name = title;
            _releaseDate = releaseDate;
            _group.Add(group);
            _artists.Add(artist);
            _albums.Add(album);
        }
        public Song(Artist artist, int duration, string genre, string title, string releaseDate)
        {
            _artists = new List<Artist>();
            _duration = duration;
            _genre = genre;
            _name = title;
            _releaseDate = releaseDate;
            _artists.Add(artist);
        }
        public Song(Group group, int duration, string genre, string title, string releaseDate)
        {
            _group = new List<Group>();
            _duration = duration;
            _genre = genre;
            _name = title;
            _releaseDate = releaseDate;
            _group.Add(group);
        }
        public string Name { get => _name; set => _name = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public int Duration { get => _duration; set => _duration = value; }
        
        public int Rating { get => _rating; set => _rating = value; }
        public int Id { get => _Id; set => _Id = value; }
        public List<Album> Albums { get => _albums; set => _albums = value; }
        public List<Group> Group { get => _group; set => _group = value; }
        public List<Artist> Artists { get => _artists; set => _artists = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }

        public void UpdateRating()
        {
            _rating++;
        }
    }
}
