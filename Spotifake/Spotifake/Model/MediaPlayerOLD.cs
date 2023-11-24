using Spotifake.Interfaces;
using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    //TODO: COMPLETARE L'IMPLEMENTAZIONE

    public class MediaPlayerOLD : IMedia
    {
        List<Song> _songs;
        List<Playlist> _playlist;
        int _currentSongIndex;
        bool _isPlaying;

        public MediaPlayerOLD()
        {
            _currentSongIndex = 0;
            _isPlaying = false;
            _songs = new List<Song>();
            _playlist = new List<Playlist>();
        
        
        }

        public void NextSong(User user)
        {
            if (user.Setting.IsPremium)
            {
                if (_currentSongIndex < _songs.Count - 1)
                {
                    _currentSongIndex++;
                    PlayCurrentSong();
                }
                else
                {
                    Console.WriteLine("Playlist terminata");
                }
            }
            else
            {
                Console.WriteLine("Attiva l'abbonamento per usufruire della funzione");
            }
        }

        public void PauseSong()
        {
            _isPlaying = false;
            Console.WriteLine("Riproduzione in pausa");
        }

        public void PlayAlbum(string albumName)
        {
            try
            {
                var SongInTheAlbum = _songs.Where(song
                => song.Albums.Any(album => album.Title == albumName)).ToList();

                if (SongInTheAlbum.Any())
                {
                    Console.WriteLine($"Riproduco L'album: {albumName}");

                    foreach (var song in SongInTheAlbum)
                    {
                        Console.WriteLine($"Brano in riproduzione : {song.Name}");
                        Thread.Sleep(song.Duration * 1000);
                    }
                }
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.ToString());
            } 
        }

        public void PlayPlaylist(string playlistName)
        {
            try
            {
                var playlist = _playlist.FirstOrDefault(p => p.Name == playlistName);

                if (playlist != null)
                {
                    var songsInPlaylist = playlist.Songs;

                    if (songsInPlaylist.Any())
                    {
                        Console.WriteLine($"Riproduzione della playlist: {playlistName}");

                        foreach (var song in songsInPlaylist)
                        {
                            Console.WriteLine($"Brano in riproduzione: {song.Name}");
                            Thread.Sleep(song.Duration * 1000);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"La playlist '{playlistName}' è vuota.");
                    }
                }
                else
                {
                    Console.WriteLine($"Nessuna playlist trovata con il nome: {playlistName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la riproduzione della playlist: {ex.Message}");
            }

        }

        public void PlaySong(string songName)
        {
            var selectedSong = _songs.FirstOrDefault(song => song.Name.Equals(songName));

            if (selectedSong != null)
            {
                _currentSongIndex = _songs.IndexOf(selectedSong);
                PlayCurrentSong();
            }
            else
            {
                Console.WriteLine($"Nessuna canzone trovata con il nome: {songName}");
            }
        }

        public void PreviousSong(User user)
        {
            if (user.Setting.IsPremium)
            {
                if (_currentSongIndex > 0)
                {
                    _currentSongIndex--;
                    PlayCurrentSong();
                }
                else
                {
                    Console.WriteLine("Playlist terminata");
                }
            }
            else
            {
                Console.WriteLine("Attiva l'abbonamento per usufruire della funzione");
            }

        }

        public void StopSong()
        {
            _isPlaying = false;
            Console.WriteLine("Riproduzione fermata");
        }

        internal void AddToQueue(Song selectedSong)
        {
            _songs.Add(selectedSong);
            Console.WriteLine($"Canzone aggiunta alla coda: {selectedSong.Name}");
        }

        internal void PlayQueue()
        {
            if (_songs.Any())
            {
                Console.WriteLine("Riproduzione della coda:");

                foreach (var song in _songs)
                {
                    Console.WriteLine($"Brano in riproduzione: {song.Name}");
                    Thread.Sleep(song.Duration * 1000);
                }
            }
            else
            {
                Console.WriteLine("La coda è vuota.");
            }
        }

        private void PlayCurrentSong()
        {
            _isPlaying = true;
            Console.WriteLine($"Ridproduzione di: {_songs[_currentSongIndex].Name} in corso");
            Thread.Sleep(_songs[_currentSongIndex].Duration * 1000);
        }

        public void AddPlayList(Playlist playlist)
        {
            _playlist.Add(playlist);
        }
    }
}
