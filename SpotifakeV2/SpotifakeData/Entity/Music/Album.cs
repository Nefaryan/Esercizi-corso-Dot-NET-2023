using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpotifakeData.Entity.Music
{
    public class Album
    {
        int _Id;
        string _title;
        Artist _artist;
        Group _gruop;
        bool _isLiveVersionAlbum;
        List<Song> _song;
        int _nOfTrack;
        int _raiting;

      
        public int ID { get => _Id; set => _Id = value; }
        public string Title { get => _title; set => _title = value; }
        public Artist Artist { get => _artist; set => _artist = value; }
        public Group Gruop { get => _gruop; set => _gruop = value; }
        public bool IsLiveVersionAlbum { get => _isLiveVersionAlbum; set => _isLiveVersionAlbum = value; }
        public List<Song> Song { get => _song; set => _song = value; }
        public int NOfTrack { get => _nOfTrack; set => _nOfTrack = value; }
        public int Raiting { get => _raiting; set => _raiting = value; }
    }
}
