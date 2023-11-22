using Spotifake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    //TODO: COMPLETARE L'IMPLEMENTAZIONE

    internal class MediaPlayer : IMedia
    {
        List<Song> _songs;
        List<Playlist> _playlist;
        int _currentSongIndex;
        bool _isPlaying;

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
                Console.WriteLine("Attiva L'abbonamento per usufruire della funzione");            
            }
        }

        public void PauseSong()
        {
            _isPlaying = false;
            Console.WriteLine("");
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
                var PlayList = _playlist.FirstOrDefault(p => p.Name == playlistName);
                if(PlayList != null)
                {
                   // var SongInPlayList = PlayList.Songs
                
                }
            }
            
        }

        public void PlaySong(string songName)
        {
            throw new NotImplementedException();
        }

        public void PreviousSong(User user)
        {
            throw new NotImplementedException();
        }

        public void StopSong()
        {
            throw new NotImplementedException();
        }

        private void PlayCurrentSong()
        {
            _isPlaying = true;
            Console.WriteLine($"Ridproduzione di: {_songs[_currentSongIndex].Name} in corso");
        }
    }
}
