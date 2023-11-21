using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    //TODO : IMPLEMENT TRY-CATCH FOR EXCEPTION
    internal class User : Person
    {
        string _username;
        string _password;
        List<Playlist> _playlist;
        List<Song> _preferitSong;
        List<Radio> _radio;
        Setting _setting;

        public User(string name, string surname, string dateOfBirth, string userName, string password, Setting setting, List<Playlist> playlist = null) : base(name, surname, dateOfBirth)
        {
            _username = userName;
            _password = password;
            _setting = setting;
            _playlist = playlist;
            _playlist= new List<Playlist>();
            _preferitSong = new List<Song>();
            _radio = new List<Radio>();
        }

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        internal List<Song> PreferitSong { get => _preferitSong; set => _preferitSong = value; }
        internal List<Playlist> Playlist { get => _playlist; set => _playlist = value; }
        internal List<Radio> Radio { get => _radio; set => _radio = value; }
        internal Setting Setting { get => _setting; set => _setting = value; }

        public void CreatePlayList(Playlist playlist)
        {
            _playlist.Add(playlist);
            playlist.User = this;
            Console.WriteLine($"Playlist: {playlist.Name} created");
        }

        public void DeletePlayList(Playlist playlist)
        {
            _playlist.Remove(playlist);
            playlist.User = null;
            Console.WriteLine($"Playlist: {playlist.Name} deleted");
        }

        public void AddSongToPlayList(Song song, string playlistName)
        {
            Playlist playlist = GetPlayListByName(playlistName);
            if(playlist != null)
            {
                playlist.AddSong(song);
                Console.WriteLine($"Song: {song.Name} added into playlist: {playlist.Name}");
            }
            else
            {
                Console.WriteLine("Si è verificato un errore");
            }
        }

        public void RemoveSongFromPlayList(Song song, string playlistName)
        {
            Playlist playlist = GetPlayListByName(playlistName);
            if(playlist != null)
            {
                playlist.RemoveSong(song);
                Console.WriteLine($"Song: {song.Name} removed from playlist: {playlist.Name}");
            }
            else 
            {
                Console.WriteLine("Si è verificato un errore");
            }

        }

        public void ModifySetting(bool darkTheme, string equalizer,bool Premium, int deviceConnected)
        {
            Setting setting = new Setting(darkTheme, equalizer, Premium, deviceConnected);
            setting.User = this;
        }
        private Playlist GetPlayListByName(string name)
        {
            Playlist playlist = _playlist.Find(x => x.Name == name);
            if (playlist != null)
            {
                return playlist;
            }
            else
            {
                return null;
            }
        }
    }
}
