using Spotifake.Model.Music;
using SpotifakeDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeLogic.Logic
{
    internal class PlayListLogic
    {
        private readonly PlaylistRepo playlistRepo;
        private readonly SongRepo songRepo;

        public PlayListLogic(PlaylistRepo playlistRepo, SongRepo songRepo)
        {
            this.playlistRepo = playlistRepo;
            this.songRepo = songRepo;
        }

        public void CreatePlaylist(int id, string name)
        {
            Playlist playlist = new Playlist(name, id);
            playlistRepo.WritePlaylistOnFile(playlist);
        }

        public void AddSongToPlaylist(string playlistName, string songName)
        {
            Playlist playlist = playlistRepo.GetByName(playlistName);
            Song song = songRepo.FindSongByName(songName);

            if (song != null && playlist != null)
            {
                playlist.AddSong(song);
                playlistRepo.WritePlaylistOnFile(playlist);
            }
        }

        public Playlist GetPlaylistByName(string name)
        {
            return playlistRepo.GetByName(name);
        }
    }
}
