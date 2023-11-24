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
        public Artist(int id, string name, string surname, string dateOfB, string artistName, string biog, Group group) : base(name, surname, dateOfB)
        {
            _Id = id;
            _artistName = artistName;
            _album = new List<Album>();
            _songs = new List<Song>();
            _bio = biog;
            _group = group;
        }

        //Costruttore per Artista singolo
        public Artist(string name, string surname, string dateOfB, string artistName, string biog) : base(name, surname, dateOfB)
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

        public void CreateNewSong(int id, string name, string genre,
            int duration, string relaseDate)
        {
            try
            {
                Song newSong = new Song(id, name, genre, duration, relaseDate);

                newSong.Artists.Add(this);
                _songs.Add(newSong);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

        }

        //Metodo per inserire nella lista una song già creata
        public void AddSon(Song song)
        {
            _songs.Add(song);
        }

        //Metodo per inserire nella lista una song che vado a creare
        public void AddSong(int id, string name, string genre, int duration, string relaseDate)
        {
            Song song1 = new Song(id, name, genre, duration, relaseDate);
            _songs.Add(song1);
        }

        public void CreateNewAlbum(int id, string title, bool isLiveAlbum)
        {
            try
            {
                Album album = new Album(id, title, this, isLiveAlbum);
                _album.Add(album);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
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

    }
}
