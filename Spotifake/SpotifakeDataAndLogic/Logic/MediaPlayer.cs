using Spotifake.Entities;
using Spotifake.Interfaces;
using Spotifake.Model.Music;
using SpotifakeDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifakeLogic.Logic
{
    public class MediaPlayer : IMedia


    {
        private readonly SongRepo songRepo;
        private readonly PlaylistRepo playlistRepo;
        private readonly SongLogic songLogic;
        private int currentSongIndex;
        private bool _isPlaying;


        public MediaPlayer()
        {
            songRepo = new SongRepo();
            playlistRepo = new PlaylistRepo();
            songLogic = new SongLogic(songRepo);
            currentSongIndex = 0;
            _isPlaying = false;
        }

        public string SeeAllSong()
        {
            StringBuilder result = new StringBuilder();
            List<Song> list = songRepo.ReadSongFromFile().ToList();

            foreach (Song song in list)
            {
                result.AppendLine($"{song.Id}.  {song.Name}");
            }

            return result.ToString();
        }

        public string NextSong(User user)
        {
            if (user.Setting.PremiumType1 == SpotifakeDataAndLogic.PremiumType.GOLD)
            {
                List<Song> allSongs = songLogic.GetAllSong();
                if (currentSongIndex < allSongs.Count - 1)
                {
                    currentSongIndex++;
                    return PlayCurrentSong(allSongs[currentSongIndex]);
                }
                else
                {
                    return "Playlist ended";
                }
            }
            else
            {
                return "Activate the subscription to use this feature";
            }
        }

        public string PauseSong()
        {
            return "Playback paused";
        }

        public string PlayAlbum(string albumName)
        {
            List<Song> songsInAlbum = songRepo.FindSongsInAlbum(albumName);

            if (songsInAlbum.Any())
            {
                StringBuilder result = new StringBuilder($"Now playing album: {albumName}\n");

                foreach (var song in songsInAlbum)
                {
                    result.AppendLine($"Playing song: {song.Name}");
                    Thread.Sleep(song.Duration * 1000);
                }

                return result.ToString();
            }
            else
            {
                return $"Album '{albumName}' not found or empty.";
            }
        }

        public string PlayPlaylist(User user,string playlistName)
        {
            List<Song> songsInPlaylist = playlistRepo.FindSongsInPlaylist(playlistName);

            if (songsInPlaylist.Any())
            {
                StringBuilder result = new StringBuilder($"Now playing playlist: {playlistName}\n");

                foreach (var song in songsInPlaylist)
                {
                    result.AppendLine($"Playing song: {song.Name}");
                    user.Setting.RemainigTime =-song.Duration;
                }

                return result.ToString();
            }
            else
            {
                return $"Playlist '{playlistName}' not found or empty.";
            }
        }

        public string PlaySong(User u, string songName)
        {
            Song song = songLogic.FindSongByName(songName);

            if (song != null)
            {
                song.Rating++;
                u.Setting.RemainigTime = -song.Duration;
                return PlayCurrentSong(song);
            }
            else
            {
                return $"Song '{songName}' not found.";
            }
        }

        public string PlaySongById(User u, int id)
        {
            Song song = songLogic.FindSongBYId(id);
            if(u.Setting.RemainigTime > 0 || u.Setting.PremiumType1 == SpotifakeDataAndLogic.PremiumType.GOLD) 
            {
                if (song != null)
                {
                    song.Rating++;
                    u.Setting.RemainigTime = -song.Duration;
                    return PlayCurrentSong(song);
                }
                else
                {
                    return $"Song '{song.Name}' not found.";
                }

            }
            else
            {
                //retunr RunRandomSong() -- need implementazione
                return $"Hai finito il tempo a disposizione o è scaduto l'abbonamento," +
                $"per continunare a poter scegliere le canzoni da ascoltare aspetta il prossimo mese o riattiva l'abbonamento";

            }
           

        }
        public string PreviousSong(User user)
        {
            if (user.Setting.PremiumType1 == SpotifakeDataAndLogic.PremiumType.GOLD)
            {
                List<Song> allSongs = songLogic.GetAllSong();
                if (currentSongIndex > 0)
                {
                    currentSongIndex--;
                    return PlayCurrentSong(allSongs[currentSongIndex]);
                }
                else
                {
                    return "Playlist ended";
                }
            }
            else
            {
                return "Activate the subscription to use this feature";
            }
        }

        public string StopSong()
        {
            if (_isPlaying)
            {
                _isPlaying = false;
                return "Playback stopped";
            }
            else
            {
                return "No song is currently playing";
            }
        }

        public List<Song> TopRatingSongs()
        {
            List<Song> songs = songLogic.GetAllSong();

            
            List<Song> topRatedSongs = songs.OrderByDescending(song => song.Rating).ToList();

           
            topRatedSongs = topRatedSongs.Take(5).ToList();

            Console.WriteLine("Top 5 rated songs:");
            foreach (var song in topRatedSongs)
            {
                Console.WriteLine($"Song: {song.Name}, Rating: {song.Rating}");
            }

            return topRatedSongs;
        }

        //Need Implementation
        public Song RunRandomSong()
        {
            return null;
        }
        private string PlayCurrentSong(Song song)
        {
            string result = $"Playing: {song.Name}";
            Console.WriteLine(result);
            Thread.Sleep(song.Duration * 1000);
            return result;
        }
        
    }
}
