using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Entity.Music
{
    public class Artist : Person
    {
        int _Id;
        string _artistName;
        List<Album> _album;
        List<Song> _songs;
        Group _group;

        public int Id { get => _Id; set => _Id = value; }
        public string ArtistName { get => _artistName; set => _artistName = value; }
        public List<Album> Album { get => _album; set => _album = value; }
        public List<Song> Songs { get => _songs; set => _songs = value; }
        public Group Group { get => _group; set => _group = value; }
    }
}
