using Spotifake.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Utils
{
    internal class FakeDB 
    {

        List<Album> _albums;
        List<Playlist> _playlist;
        List<Song> _song;

        public FakeDB() 
        {
          _albums = new List<Album>();
          _playlist = new List<Playlist>();
          _song = new List<Song>();
        
        }

        public void AddSong(Song song)
        {
            _song.Add(song);
        }

        public void addAlbum(Album album)
        {
            _albums.Add(album);
        
        }

        public void addPlaylist(Playlist playlist)
        {
            _playlist.Add(playlist);
        }

        internal void ShowArtists()
        {
          List<Artist> artists = _song.SelectMany(s => s.Artists).Distinct().ToList();
           foreach (Artist artist in artists)
           {
                Console.WriteLine(artist.ArtistName);          
           }
        }

        internal void ShowPlaylists()
        {
            foreach(Playlist playlist in _playlist) 
            {
                Console.WriteLine($"Playlist : {playlist.Name}");
                foreach(Song song in playlist.Songs)
                {
                    Console.WriteLine($" {song.Name}");
                
                }            
            }
        }

        internal void ShowAlbums()
        {
            foreach (Album album in _albums)
            {
                Console.WriteLine($"Album: {album.Title}");
                foreach (Song song in album.Song)
                {
                    Console.WriteLine($"  {song.Name}");
                }
            }
        }

        internal void SearchSong(string songName)
        {
            var results = _song.Where(song => song.Name.Contains(songName)).ToList();

            if (results.Any())
            {
                Console.WriteLine("Risultati della ricerca:");
                foreach (Song song in results)
                {
                    Console.WriteLine($"  {song.Name}");
                }
            }
            else
            {
                Console.WriteLine("Nessun risultato trovato.");
            }
        }

        internal Song SelectSong(string songTitle)
        {
            Song selectedSong = _song.FirstOrDefault(song => song.Name.Equals(songTitle));

            if (selectedSong != null)
            {
                Console.WriteLine($"Canzone selezionata: {selectedSong.Name} ");
            }
            else
            {
                Console.WriteLine($"Nessuna canzone trovata con il titolo: {songTitle}");
            }

            return selectedSong;
        }

        public Playlist SelectPlaylist(string playlistName)
        {
            Playlist selectedPlaylist = _playlist.FirstOrDefault(p =>  p.Name.Equals(playlistName));
            if (selectedPlaylist != null) 
            {
                Console.WriteLine($"Playlist selezionata");
            }
            else
            {
                Console.WriteLine("Nessuna playlist trovata");
            }
            return selectedPlaylist;
        }
    }
}
