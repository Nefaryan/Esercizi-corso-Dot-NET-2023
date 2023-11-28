using Spotifake.Entities;
using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeDataAndLogic.Data
{
    internal class FakeDatabase
    {
        List<Album> _albums = new List<Album>();
        List<Artist> _artists = new List<Artist>();
        List<Song> _songs = new List<Song>();
        List<User> _users = new List<User>();
        List<Playlist> _playlists = new List<Playlist>();
        bool islogged = false;

        public FakeDatabase()
        {
            _users = new List<User>();
            _artists = new List<Artist>();
            _songs = new List<Song>();
            _albums = new List<Album>();
            _playlists = new List<Playlist>();
        }

        internal List<Album> Albums { get => _albums; set => _albums = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }
        internal List<User> Users { get => _users; set => _users = value; }
        public bool Islogged { get => islogged; set => islogged = value; }
        internal List<Playlist> Playlists { get => _playlists; set => _playlists = value; }
        public void ShowMeUsers()
        {
            foreach (User user in Users) { Console.WriteLine(user.Username + " " + user.Password); }
        }

        public void ShowMeArtists()
        {
            if (Artists != null)
            {
                int i = 0;
                foreach (Artist artist in Artists)
                {
                    i++;
                    Console.WriteLine(i + "-" + artist.ArtistName);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void ShowMeAlbums()
        {
            int i = 0;
            if (Albums != null)
            {
                foreach (Album album in Albums)
                {
                    i++;
                    Console.WriteLine(i + "-" + album.Title);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void ShowMeOneAlbum(Album album)
        {
            int i = 0;
            List<Song> songs = album.Song;
            foreach (Song s in songs)
            {
                i++;
                Console.WriteLine(i + "" + s.Name);
            }



        }
        public void ShowMeOneArtist(Artist artist)
        {
            Console.WriteLine("Albums by " + artist.ArtistName + ":");
            for (int i = 0; i < artist.Album.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {artist.Album[i].Title}");
            }
        }
        public void ShowMeOnePlaylist(Playlist playlist)
        {
            int i = 0;
            List<Song> songs = playlist.Songs;
            foreach (Song s in songs)
            {
                i++;
                Console.WriteLine(i + "" + s.Name);
            }



        }
        public void ShowMeSongs()
        {
            int i = 0;
            if (Songs != null)
            {
                foreach (Song song in Songs)
                {

                    i++;
                    Console.WriteLine(i + "-" + song.Name);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }

        public void ShowMePlaylists()
        {
            if (Playlists != null)
            {
                int i = 0;
                foreach (Playlist playlist in Playlists)
                {
                    i++;
                    Console.WriteLine(i + " " + playlist.Name);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }


        public void AddArtistToDB(Artist artist)
        {
            if (Artists != null) { Artists.Add(artist); }
            else { Console.WriteLine("No one in list"); }

        }
        public void AddPlaylistsToDB(Playlist playlist)
        {
            if (Playlists != null) { Playlists.Add(playlist); }
            else { Console.WriteLine("No one playlist in Spotify!"); }

        }
        public void AddAlbumToDB(Album album)
        {
            if (Albums != null) { Albums.Add(album); }
            else { Console.WriteLine("No one in list"); }

        }
        public void AddSongsToDB(Song song)
        {
            if (Songs != null) { Songs.Add(song); }
            else { Console.WriteLine("No one in list"); }

        }
        public FakeDatabase InitializeDatabase()
        {
            FakeDatabase database = new FakeDatabase();

            Artist MichaelJackson = new("Michael", "Jackson", "29-08-1958", "Michael Jackson", "The greatest star of all times!");
            Artist MachineGunKelly = new("Colson", "Baker", "22-04-1990", "Machine Gun Kelly", "Colson Baker (born April 22, 1990), known professionally as Machine Gun Kelly (MGK), is an American rapper, singer, songwriter, musician, and actor.");
            Artist Yungblud = new("Dominic", "Richard", "05-08-1997", "Yungblud", "Yungblud, pseudonym of Dominic Richard Harrison, is a British singer-songwriter.");
            Album Dangerous = new("Dangerous", "1991", 12, MichaelJackson, null, false);
            Album Century = new("21st Century Liability", "2018", 10, Yungblud, null, false);
            Album Mainstream = new("Mainstream Sellout", "2022", 15, MachineGunKelly, null, false);
            Song healtheworld = new(MichaelJackson,Dangerous, 100, "POP", "Heal the world", "1991");
            Song fakelove = new(MachineGunKelly, Mainstream,130, "Punk", "Fake love", "2022");
            Song iloveyou = new(Yungblud, Century, 200, "Rock", "I love you", "2017");
           

            User user = new User(1,"Marco", "gino", "12-05-1990","fico","fico2");
            Playlist playlist1 = new Playlist(user,"Unlucky",1);

            Dangerous.Song.Add(healtheworld);
            Century.Song.Add(iloveyou);
            Mainstream.Song.Add(fakelove);
            MichaelJackson.AddAlbum(Dangerous);
            MachineGunKelly.AddAlbum(Mainstream);
            Yungblud.AddAlbum(Century);
            healtheworld.Albums.Add(Dangerous);
            fakelove.Albums.Add(Mainstream);
            iloveyou.Albums.Add(Century);
            playlist1.AddSong(healtheworld);
            playlist1.AddSong(fakelove);
            playlist1.AddSong(healtheworld);
            database.Playlists.Add(playlist1);
            database.AddArtistToDB(MichaelJackson);
            database.AddArtistToDB(MachineGunKelly);
            database.AddArtistToDB(Yungblud);
            database.AddAlbumToDB(Dangerous);
            database.AddAlbumToDB(Century);
            database.AddAlbumToDB(Mainstream);
            database.AddSongsToDB(healtheworld);
            database.AddSongsToDB(fakelove);
            database.AddSongsToDB(iloveyou);

            return database;
        }



        public void Register(User utente)
        {

            Users.Add(utente);

        }
        public void Login(string username, string psw, User user)
        {
            if (Users != null)
            {
                bool userFound = false;

                foreach (User u in Users)
                {
                    if (u.Username == username && u.Password == psw)
                    {
                        user.IsLogged = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Welcome to spotify" + " " + username);

                        userFound = true;
                        islogged = true;
                        break;
                    }
                }

                if (!userFound)
                {
                    Console.WriteLine("You don't have a registered user!");
                    islogged = false;
                    user.IsLogged = false;
                }
            }
            else
            {
                Console.WriteLine("Nessun utente nella lista");
                islogged = false;
                user.IsLogged = false;
            }
        }

    }
}

