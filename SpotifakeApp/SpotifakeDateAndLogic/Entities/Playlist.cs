using SpotifakeClasses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeClasses.Entities
{
    public class Playlist
    {
        private string _name;
        private List<Song> _songs;
        private User _user;
        private int _id;
        public Playlist()
        {   
             _user = new User();    
             _songs = new List<Song>();
        }
        public Playlist(String name,List<Song> songs, User user)
        {
            _name = name;
            _songs = songs;
            _user = user;
        }
        public Playlist(String name, User user)
        {
            _name = name;
            _songs = new List<Song>();
            _user = user;
        }
        public void AddSong(Song s) => _songs.Add(s);
        public void AddSongs(List<Song> s)
        {
            foreach(Song item in  s) {
                if (item != null)
                    _songs.Add(item);
            }
        }
        public void RemoveSong(Song s) => _songs.Remove(s);

        public void RemoveSongs(List<Song> s)
        {
            foreach (var item in s) { if (item != null) _songs.Remove(item); }
        }
        public void ShowSongs()
        {
            foreach (Song song in _songs)
            {
                if (song != null)
                    Console.WriteLine($"{song.Title}");
            }
        }
        public List<Song> Songs { get => _songs; }
        public User User { get => _user; set => _user = value; }
        public string Name { get => _name; set => _name = value; }
        public int Id { get => _id; set => _id = value; }
    }
}
