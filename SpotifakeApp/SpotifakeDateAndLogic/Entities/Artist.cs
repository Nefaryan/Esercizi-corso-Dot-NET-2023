using SpotifakeClasses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeClasses.Entities
{
       public class Artist : Person
    {
        private string _artName;
        private List<Album> _albums;
        private List<Song> _songs;
        private Group _group;
        private string _bio;

        public Artist()
        {
            _albums = new List<Album>();
            _songs = new List<Song>();  
        }

        public Artist(string name,string surname,string dateOfBirth,string artName, List<Album> albums, List<Song> songs, string bio):
            base(name,surname,dateOfBirth)
        {
            _artName = artName;
            _albums = albums;
            _songs = songs;
            _bio=bio;
            _songs=new List<Song>();  
            _albums=new List<Album>();  
        }

        public Artist(string name, string surname, string dateOfBirth,string artName):base(name,surname,dateOfBirth)
        {
            _artName = artName;
            _songs = new List<Song>();
            _albums = new List<Album>();
        }

        public void PublishSong(Album a, int duration, string genre, string title, string release)
        {
            _songs.Add(new Song(this, a, duration, genre, title, release));
        }
        public void PublishSong(string title, int duration, string genre, string release)
        {
            _songs.Add(new Song(this, duration, genre, title, release));
        }
        public void PublishAlbum(string Title, string release, int nTracks, bool live, List<Song> songs)
        {
            _albums.Add(new Album(Title, release, nTracks, live, this, songs));
        }
        public void AddSong(Song s)
        { //used for feat songs
            _songs.Add(s);
        }
        public void AddAlbum(Album a)
        { //used for feat albums
            _albums.Add(a);
        }
            public void JoinGroup(Group group)
        {
            group.AddMember(this);
            _group = group;
        }
        public void LeaveGroup() {
            try
            {
                _group.RemoveMember(this);
                _group = null;
            }
            catch(System.NullReferenceException ex)
            {
                List<Exception> list = new List<Exception> { ex }; 
                FileHandler<Exception>.WriteOnFile("Errors.txt", list); ;
            }
        }

        public void ShowSongs()
        {
            foreach (Song song in _songs)
            {
                if (song != null)
                    Console.WriteLine($"{song.Title}");
            }
        }
        public void ShowAlbums()
        {
            foreach (Album album in _albums)
            {
                if (album != null)
                    Console.WriteLine($"{album.Title}");
            }
        }
        public string ArtName { get => _artName; }
        public List<Album> Albums { get => _albums; }
        public List<Song> Songs { get => _songs; }
        public Group Group { get => _group; }
        public string Bio { get => _bio; }

        public override string ToString()
        {
            return _artName + " " +base.Name+" "+base.Surname+" "+base.DateOfBirth + " " + Bio;
        }
    }
}
