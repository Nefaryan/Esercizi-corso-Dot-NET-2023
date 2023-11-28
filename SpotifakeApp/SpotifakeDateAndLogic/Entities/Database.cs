using SpotifakeClasses.Entities;
using SpotifakeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SpotifakeClasses.Entities
{
    public class Database  //we'll fake a database with this class
    {
        private List<Artist> _artists;
        private List<Group> _groups;
        User _user;
        public Database() { 
            _artists = new List<Artist>();  
            _groups = new List<Group>();    
        }
        public Database(List<String> artistFile,List<String> groupFile)
        {
            _artists = FileHandler<Artist>.CreateObject(artistFile);
            _groups = FileHandler<Group>.CreateObject(groupFile);
        }
        public void ShowArtists()
        {
           foreach(Artist artist in _artists) { 
                ShowArtist(artist);
            }
        }
        public void ShowGroups() {
            foreach (Group group in _groups)
            {
                ShowGroup(group);
            }
        }
        public void ShowSongs()
        {
            foreach(Artist artist in _artists)
            {
                if(artist != null)
                    artist.ShowSongs();
            }
            foreach (Group group in _groups)
            {
                if (group != null)
                    group.ShowSongs();
            }
        }
        public void ShowAlbums()
        {
            foreach (Artist artist in _artists)
            {
                if(artist!=null)
                    artist.ShowAlbums();
            }
            foreach (Group group in _groups)
            {
                if(group!=null)
                    group.ShowAlbums();
            }
        }
        public void SearchSong(String s) {
            List<Song> foundSong=new List<Song>();
            try
            {
                foreach (Artist artist in _artists)
                {
                    foundSong = foundSong.Concat(artist.Songs.Where(song => song.Title.Equals(s)).ToList()).ToList();

                }
                foreach (Group group in _groups)
                {
                    foundSong = foundSong.Concat(group.Songs.Where(song => song.Title.Equals(s)).ToList()).ToList();
                }
                foreach (Song song in foundSong)
                {

                    Console.WriteLine($"{song.Title}");
                    Console.WriteLine($"{song.Genre}");
                    Console.WriteLine($"{song.Duration}");
                    Console.WriteLine($"{song.ReleaseDate}");

                }
            }
            catch (NullReferenceException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list);
            }
        }
        public Song SelectSong(int id) //returns the first song with the desired id
        {
            Song song=null;
            try {
                foreach (Artist artist in _artists)
                {
                    song = artist.Songs.FirstOrDefault(song => song.Id.Equals(id));
                    if (song != null)
                        return song;
                }
            } catch (NullReferenceException ex) {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list); 
            }
            try
            {
                foreach (Group group in _groups)
                {
                    song = group.Songs.FirstOrDefault(song => song.Id.Equals(id));
                    if (song != null)
                        return song;
                }
                Console.WriteLine("Nessuna canzone con quel titolo");
                return null;
            }
            catch(NullReferenceException ex) {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list); ;
                return null;
            }
               
        }

        public Playlist SelectPlaylist( int id) {
            foreach(Playlist list in _user.Playlists)
            {
                if(list.Id.Equals(id)) 
                    return list;
            }
            return null;
        }

        public Radio SelectRadio(int id)
        {
            foreach (Radio radio in _user.FavouriteRadios)
            {
                if (radio.Id.Equals(id))
                    return radio;
            }
            return null;
        }

        public void AddArtist(Artist a)
        {
            _artists.Add(a);    
        }
        public void setUser(User u)
        {
            _user= u;
        }
        public void AddGroup(Group g)
        {
            _groups.Add(g); 
        }
        private void ShowArtist(Artist a) {

            if (a == null)
                return;
            Console.WriteLine(a.ArtName);
            a.ShowAlbums();
            a.ShowSongs();
        }
        public void ShowRadios()
        {
            try { _user.ShowRadios(); }
            catch (NullReferenceException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list); ;
            }    
                
        }
        public void ShowPlaylists()
        {
            try { _user.ShowPlaylists(); }
            catch (NullReferenceException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list); ;
            }

        }
        private void ShowGroup(Group g)
        {

            if (g == null)
                return;
            Console.WriteLine(g.Name);
            g.ShowAlbums();
            g.ShowSongs();
        }

       
    }
}