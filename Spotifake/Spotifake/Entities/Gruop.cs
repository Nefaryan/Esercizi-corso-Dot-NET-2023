using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    internal class Gruop
    {
        string _gruopName;
        List<Artist> _artists;
        List<Album> _albums;
        List<Song> _song;
        string _bio;

        public Gruop(string name,string bio) 
        {
            _bio = bio;
            _gruopName = name;
            _artists = new List<Artist>();
            _albums = new List<Album>();
            _song = new List<Song>();
        
        }

        public string GruopName { get => _gruopName; set => _gruopName = value; }
        public string Bio { get => _bio; set => _bio = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
        internal List<Song> Song { get => _song; set => _song = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }
    }
}
