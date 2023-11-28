using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spotifake.Model.Music
{
    public class Album
    {
       
        string _title;
        Artist _artist;
        Group _group;
        bool _isLiveVersionAlbum;
        List<Song> _song;
        int _nOfTrack;
        int _rating;
        string _releaseDate;

        public Album() { }

        public Album(string title, string releaseDate, int numbOfTracks, Artist artist, Group group, bool liveVersion)
        {
            _title = title;
            _releaseDate = releaseDate;
            _nOfTrack = numbOfTracks;
            _artist = artist;
            _group = group;
            _isLiveVersionAlbum = liveVersion;
            _song = new List<Song>();
        }

        public string Title { get => _title; set => _title = value; }
        public bool IsLiveVersionAlbum { get => _isLiveVersionAlbum; set => _isLiveVersionAlbum = value; }
        public int NOfTrack { get => _nOfTrack; set => _nOfTrack = value; }
        public Artist Artist { get => _artist; set => _artist = value; }
        public Group Gruop { get => _group; set => _group = value; }
        public List<Song> Song { get => _song; set => _song = value; }
        public int Rating { get => _rating; set => _rating = value; }

        public void Add(Song song)
        {
            _song.Add(song);
            _song.OrderByDescending(x => x.Rating).ToList();
        }

        public void AlbumRating()
        {
            _rating = _song.Sum(x => x.Rating);
        }
    }
}
