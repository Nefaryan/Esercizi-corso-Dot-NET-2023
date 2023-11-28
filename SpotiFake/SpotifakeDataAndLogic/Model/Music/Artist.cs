using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotifake.Entities;

namespace Spotifake.Model.Music
{
    public class Artist : Person
    {
        int _Id;
        string _artistName;
        List<Album> _album;
        List<Song> _songs;
        string _bio;
        Group _group;

        
        //Costruttore per un artista che si trova in un gruppo
        public Artist(string name, string surname, string bday,
            int id,  string artistName, string biog, Group group)  : base(name,surname,bday)
        {
            _Id = id;
            _artistName = artistName;
            _album = new List<Album>();
            _songs = new List<Song>();
            _bio = biog;
            _group = group;
        }

        //Costruttore per Artista singolo
        public Artist(string name, string surname, string bday, string artistName, string biog): 
            base(name,surname,bday)    
        {
            _artistName = artistName;
            _album = new List<Album>();
            _songs = new List<Song>();
            _bio = biog;

        }

      

        public string ArtistName { get => _artistName; set => _artistName = value; }
        public string Bio { get => _bio; set => _bio = value; }
        public Group Group { get => _group; set => _group = value; }
        internal List<Album> Album { get => _album; set => _album = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }
        public int Id { get => _Id; set => _Id = value; }

        public void AddSong(Song song)
        {
            _songs.Add(song);
        }

        public void AddSongToAlbum(string songName, string AlbumName)
        {
            Song song = FindSongByName(songName);
            Album album = FindAlbumByName(AlbumName);

            if (song != null && album != null)
            {
                album.Song.Add(song);
                song.Albums.Add(album);
            }
        }

        private Song FindSongByName(string name)
        {
            Song song = _songs.Find(x => x.Name == name);
            if (song != null)
            {
                return song;
            }
            else
            {
                return null;
            }
        }

        private Album FindAlbumByName(string title)
        {
            Album album = _album.Find(x => x.Title == title);
            if (album != null)
            {
                return album;
            }
            else
            {
                return null;
            }

        }

        public void ShowSongs()
        {
            foreach (Song song in _songs)
            {
                if (song != null)
                    Console.WriteLine($"{song.Name}");
            }
        }
        public void ShowAlbums()
        {
            foreach (Album album in _album)
            {
                if (album != null)
                    Console.WriteLine($"{album.Title}");
            }
        }

        public override string ToString()
        {
            return $"{ArtistName},{Bio}";
        }

        internal void AddAlbum(Album album)
        {
            _album.Add(album);
        }
    }
}
