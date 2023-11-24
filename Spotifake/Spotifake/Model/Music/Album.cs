using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Model.Music
{
    public class Album
    {
        int _ID;
        string _title;
        Artist _artist;
        Group _gruop;
        bool _isLiveVersionAlbum;
        List<Song> _song;
        int _nOfTrack;
        private string albumTitle;

        //Costruttore per gli album legati ad un artista
        public Album(int id, string title, Artist artist, bool live)
        {
            _ID = id;
            _title = title;
            _artist = artist;
            _song = new List<Song>();
            _nOfTrack = _song.Count;
            _isLiveVersionAlbum = live;
        }

        //Costruttore per gli album legati ad un gruppo
        public Album(int id, string title, bool live)
        {
            _ID = id;
            _title = title;
            _song = new List<Song>();
            _isLiveVersionAlbum = live;
            _nOfTrack = _song.Count;
        }

        public Album(string albumTitle)
        {
            this.albumTitle = albumTitle;
        }

        public string Title { get => _title; set => _title = value; }
        public bool IsLiveVersionAlbum { get => _isLiveVersionAlbum; set => _isLiveVersionAlbum = value; }
        public int NOfTrack { get => _nOfTrack; set => _nOfTrack = value; }
        internal Artist Artist { get => _artist; set => _artist = value; }
        internal Group Gruop { get => _gruop; set => _gruop = value; }
        internal List<Song> Song { get => _song; set => _song = value; }
        public int ID { get => _ID; set => _ID = value; }
    }
}
