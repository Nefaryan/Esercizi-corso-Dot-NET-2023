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

        public Album() { }
   
        public Album(int id, string title, bool live)
        {
            _ID = id;
            _title = title;
            _song = new List<Song>();
            _isLiveVersionAlbum = live;  
        }

        public Album(int id, string title, Artist artist, bool isLiveAlbum)
        {
            ID = id;
            Title = title;
            Artist = artist;
        }

        public string Title { get => _title; set => _title = value; }
        public bool IsLiveVersionAlbum { get => _isLiveVersionAlbum; set => _isLiveVersionAlbum = value; }
        public int NOfTrack { get => _nOfTrack; set => _nOfTrack = value; }
        public Artist Artist { get => _artist; set => _artist = value; }
        public Group Gruop { get => _gruop; set => _gruop = value; }
        public List<Song> Song { get => _song; set => _song = value; }
        public int ID { get => _ID; set => _ID = value; }
    }
}
