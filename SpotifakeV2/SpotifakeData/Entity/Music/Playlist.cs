using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Entity.Music
{
    public class Playlist
    {
        int id;
        User? _user;
        List<Song>? _songs;
        string? _name;

        public int Id { get => id; set => id = value; }
        public User? User { get => _user; set => _user = value; }
        public List<Song>? Songs { get => _songs; set => _songs = value; }
        public string? Name { get => _name; set => _name = value; }
    }
}
