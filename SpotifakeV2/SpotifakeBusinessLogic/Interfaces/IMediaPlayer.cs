using SpotifakeData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Interfaces
{
    public interface IMediaPlayer
    {
        public string PlaySong(User u, string songName);
        public string PlayAlbum(User u, int albumId);
        public string PlayPlaylist(User u, int playListId);
        public string PauseSong();
        public string NextSong(User user);
        public string PreviousSong(User user);
    }
}
