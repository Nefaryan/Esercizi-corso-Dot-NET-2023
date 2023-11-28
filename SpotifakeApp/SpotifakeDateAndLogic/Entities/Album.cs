using SpotifakeClasses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpotifakeClasses.Entities
{
    public class Album
    {
        private string _title;
        private string _releaseDate;
        private int _nOfTracks;
        private bool _isLive;
        private List<Artist> _artists;
        private List<Group> _groups;
        private List<Song> _songs;
        private decimal _rating;
        public Album()
        {
            _artists=new List<Artist>();
            _groups=new List<Group>();  
            _songs=new List<Song>();    
        }


        public Album(string title, string releaseDate, int nOfTracks, bool isLive, Artist artist,Group group, List<Song> songs)
        {
            _title = title;
            _releaseDate = releaseDate;
            _nOfTracks = nOfTracks;
            _isLive = isLive;
            _artists = new List<Artist>();
            _groups = new List<Group>();
            _songs = songs;
            _artists.Add(artist);
            _groups.Add(group);
        }

        public Album(string title, string releaseDate, int nOfTracks, bool isLive, Artist artist, List<Song> songs)
        {
            _title = title;
            _releaseDate = releaseDate;
            _nOfTracks = nOfTracks;
            _isLive = isLive;
            _artists =new List<Artist>();
            _songs = songs;
            _artists.Add(artist);
        }

        public Album(string title, string releaseDate, int nOfTracks, bool isLive, Group group, List<Song> songs)
        {
            _title = title;
            _releaseDate = releaseDate;
            _nOfTracks = nOfTracks;
            _isLive = isLive;
            _groups = new List<Group>();
            _songs = songs;
            _groups.Add(group);
        }

        public Album(string title, string releaseDate, int nOfTracks, bool isLive, Artist artist,Song song)
        {
            _title = title;
            _releaseDate = releaseDate;
            _nOfTracks = nOfTracks;
            _isLive = isLive;
            _artists = new List<Artist>();
            _songs = new List<Song>();
            _artists.Add(artist);
            _songs.Add(song);
        }

        public void CalcRating()
        {
            decimal rating = 0;
            foreach (Song song in _songs)
                rating+= song.Rating;
            _rating = rating / _nOfTracks;
        }
        public string Title { get => _title; set => _title = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public int NOfTracks { get => _nOfTracks; set => _nOfTracks = value; }
        public bool IsLive { get => _isLive; set => _isLive = value; }
        public List<Artist> Artists { get => _artists; set => _artists = value; }
        public List<Group> Groups { get => _groups; set => _groups = value; }
        public List<Song> Songs { get => _songs; set => _songs = value; }
        public decimal Rating { get => _rating; set => _rating = value; }
    }
}
