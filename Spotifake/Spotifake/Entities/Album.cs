using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    internal class Album
    {
        string _title;
        Artist _artist;
        Gruop _gruop;
        bool _isLiveVersionAlbum;
        List<Song> _song;
        int _nOfTrack;

        //Costruttore per gli album legati ad un artista
        public Album(string title, Artist artist, bool live)
        {
            _title = title;
            _artist = artist;
            _song = new List<Song>();
            _nOfTrack = _song.Count;
            _isLiveVersionAlbum = live;
        }

        //Costruttore per gli album legati ad un gruppo
        public Album(string title, Gruop gruop, bool live)
        {
            _title = title;
            _gruop = gruop;
            _song = new List<Song>();
            _isLiveVersionAlbum = live;
            _nOfTrack = _song.Count;
        }

        public string Title { get => _title; set => _title = value; }
        public bool IsLiveVersionAlbum { get => _isLiveVersionAlbum; set => _isLiveVersionAlbum = value; }
        public int NOfTrack { get => _nOfTrack; set => _nOfTrack = value; }
        internal Artist Artist { get => _artist; set => _artist = value; }
        internal Gruop Gruop { get => _gruop; set => _gruop = value; }
        internal List<Song> Song { get => _song; set => _song = value; }
    }
}
