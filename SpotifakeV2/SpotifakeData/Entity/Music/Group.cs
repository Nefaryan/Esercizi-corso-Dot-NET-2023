using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Entity.Music
{
    public class Group
    {
        int _id;
        string _gruopName;
        List<Artist> _artists;
        List<Album> _albums;
        List<Song> _song;
        string _bio;

        public int Id { get => _id; set => _id = value; }
        public string GruopName { get => _gruopName; set => _gruopName = value; }
        public List<Artist> Artists { get => _artists; set => _artists = value; }
        public List<Album> Albums { get => _albums; set => _albums = value; }
        public List<Song> Song { get => _song; set => _song = value; }
        public string Bio { get => _bio; set => _bio = value; }
    }
}
