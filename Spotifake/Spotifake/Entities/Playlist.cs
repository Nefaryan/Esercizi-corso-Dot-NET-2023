using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    internal class Playlist
    {
       User _user;
       List<Song> _songs;
       string _name;

        public Playlist(string name)
        {
            _name = name;
            _songs = new List<Song>();
        }

        public string Name { get => _name; set => _name = value; }
        internal User User { get => _user; set => _user = value; }

        public void AddSong(Song song)
        {
            _songs.Add(song);
        }

        public void RemoveSong(Song song) 
        {
            _songs.Remove(song);
        }




    }
}
