using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotifake.Model.Music;
using SpotifakeDataAndLogic.Model;

namespace Spotifake.Entities
{
    //TODO : IMPLEMENT TRY-CATCH FOR EXCEPTION
    public class User : Person
    {
        int _Id;
        string _username;
        string _password;
        List<Playlist> _playlist;
        List<Song> _preferitSong;
        List<Radio> _radio;
        PremiumType PremiumType { get; set; }
        int _usingTime;
        bool _isLogged;

        public User(int id, string name, string surname, string dateOfBirth, string userName, string password) : base(name, surname, dateOfBirth)
        {
            _Id = id;
            _username = userName;
            _password = password;
         
           
            _playlist= new List<Playlist>();
            _preferitSong = new List<Song>();
            _radio = new List<Radio>();

            switch(PremiumType) 
            {
                case PremiumType.FREE:
                    _usingTime = 360000; // 100 ore in secondi per gli utenti free
                    break;
                case PremiumType.PREMIUM:
                    _usingTime = 3600000; // 1000 0re in secondi per utenti premium
                    break;
                case PremiumType.GOLD:
                    _usingTime = -1; // ilimitato
                    break;
                default:
                    _usingTime = 360000;
                    break;
            }
        }

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public List<Song> PreferitSong { get => _preferitSong; set => _preferitSong = value; }
        public List<Playlist> Playlist { get => _playlist; set => _playlist = value; }
        public List<Radio> Radio { get => _radio; set => _radio = value; }

        public int Id { get => _Id; set => _Id = value; }
        public bool IsLogged { get => _isLogged; set => _isLogged = value; }
        public int UsingTime { get => _usingTime; set => _usingTime = value; }

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
        public void ShowPlaylists()
        {
            foreach (Playlist item in _playlist)
            {
                if (item == null)
                    break;
                Console.WriteLine($"{item.Name}");
                
            }
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
