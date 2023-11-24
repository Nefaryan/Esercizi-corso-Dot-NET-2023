using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Model.Music
{
    //TODO: Inserire gestione delle eccezioni
    public class Group
    {
        int _id;
        string _gruopName;
        List<Artist> _artists;
        List<Album> _albums;
        List<Song> _song;
        string _bio;
        private string groupName;

        public Group(int id, string name, string bio)
        {
            _id = id;
            _bio = bio;
            _gruopName = name;
            _artists = new List<Artist>();
            _albums = new List<Album>();
            _song = new List<Song>();
        }

        public Group(string groupName)
        {
            this.groupName = groupName;
        }

        public string GruopName { get => _gruopName; set => _gruopName = value; }
        public string Bio { get => _bio; set => _bio = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
        internal List<Song> Song { get => _song; set => _song = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }
        public int Id { get => _id; set => _id = value; }

        public void AddArtist(Artist artist)
        {
            artist.Group = this;
            _artists.Add(artist);
        }

        public void RemoveArtist(Artist artist)
        {
            _artists.Remove(artist);
            artist.Group = null;
        }

        public void CreateSong(int id, string name, string genre, int duration, string relaseDate)
        {
            Song song = new Song(id, name, genre, duration, relaseDate);
            _song.Add(song);
        }
        public void CreateAlbum(int id, string title, bool live)
        {
            Album album = new Album(id, title, live);
            album.Gruop = this;
            _albums.Add(album);
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
            Song song = _song.Find(x => x.Name == name);
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
            Album album = _albums.Find(x => x.Title == title);
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
