using SpotifakeClasses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeClasses.Entities
{
    public class Song
    {
        private List<Artist> _artist;
        private List<Album> _album;
        private List<Group> _groups;
        private int _duration;
        private string _genre;
        private string _title;
        private string _releaseDate;
        private int _id;
        private int _rating;
        public Song()
        {
            _artist = new List<Artist>();
            _album = new List<Album>();
            _groups = new List<Group>();
        }
        public Song(Artist artist, Album album, int duration, string genre, string title, string releaseDate)
        {
            _artist =new List<Artist>();
            _album = new List<Album>();
            _duration = duration;
            _genre = genre;
            _title = title;
            _releaseDate = releaseDate;
            _artist.Add(artist);
            _album.Add(album);
        }
        public Song(Group group, Album album, int duration, string genre, string title, string releaseDate)
        {
            _groups = new List<Group>();
            _album = new List<Album>();
            _duration = duration;
            _genre = genre;
            _title = title;
            _releaseDate = releaseDate;
            _groups.Add(group);
            _album.Add(album);
        }
        public Song(Artist artist,Group group, Album album, int duration, string genre, string title, string releaseDate)
        {
            _groups = new List<Group>();
            _album = new List<Album>();
            _artist = new List<Artist>();   
            _duration = duration;
            _genre = genre;
            _title = title;
            _releaseDate = releaseDate;
            _groups.Add(group);
            _artist.Add(artist);
            _album.Add(album);
        }
        public Song(Artist artist, int duration, string genre, string title, string releaseDate)
        {
            _artist = new List<Artist>();
            _duration = duration;
            _genre = genre;
            _title = title;
            _releaseDate = releaseDate;
            _artist.Add(artist);
        }
        public Song(Group group, int duration, string genre, string title, string releaseDate)
        {
            _groups = new List<Group>();
            _duration = duration;
            _genre = genre;
            _title = title;
            _releaseDate = releaseDate;
            _groups.Add(group);
        }
        public void AddArtist(Artist a)
        {
            _artist.Add(a);
        }
        public void AddAlbum(Album a)
        {
            _album.Add(a);
        }
        public void AddGroup(Group g)
        {
            _groups.Add(g);
        }
        public void UpdateRating()
        {
            _rating++;
        }
        public List<Artist> Artist { get => _artist; }
        public List<Album> Album { get => _album; }
        public int Duration { get => _duration; set => _duration = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public string Title { get => _title; set => _title = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public int Id { get => _id; set => _id = value; }
        public int Rating { get => _rating; set => _rating = value; }
    }
}
