using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotifake.Entities;

namespace Spotifake.Model.Music
{
    public class Playlist
    {
        int id;
        User _user;
        List<Song> _songs;
        string _name;
        int _rating;

        public Playlist(string name, int id)
        {
            _name = name;
            _songs = new List<Song>();
            Id = id;
        }
        public Playlist(User u,string name, int id)
        {
            User = u;
            _name = name;
            _songs = new List<Song>();
            Id = id;
        }
        public Playlist() { }
        public string Name { get => _name; set => _name = value; }
        public int Id { get => id; set => id = value; }
        public User User { get => _user; set => _user = value; }
        public List<Song> Songs { get => _songs; set => _songs = value; }

        public void AddSong(Song song)
        {
            _songs.Add(song);
            
        }

        public void RemoveSong(Song song)
        {
            _songs.Remove(song);
        }

        public void PlayListReting()
        {
            _rating = _songs.Sum(x => x.Rating);
        }

        public void ShowAllSong()
        {
            foreach (Song song in _songs)
            {
                if (song != null)
                    Console.WriteLine($"{song.Name}");
            }

        }




    }
}
