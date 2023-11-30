using SpotifakeData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeBusinessLogic.Interfaces
{
    public interface IMediaPlayer
    {
        public string PlaySong(User u, string songName);
        public string PlayAlbum(string albumName);
        public string PlayPlaylist(User u, string playlistName);
        public string StopSong();
        public string PauseSong();
        public string NextSong(User user);
        public string PreviousSong(User user);
    }
}
