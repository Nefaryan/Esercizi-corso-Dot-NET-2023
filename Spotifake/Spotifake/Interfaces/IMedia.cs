using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Interfaces
{
    internal interface IMedia
    {
        public void PlaySong(string songName);
        public void PlayAlbum(string albumName);
        public void PlayPlaylist(string playlistName);
        public void StopSong();
        public void PauseSong();
        public void NextSong();
        public void PreviousSong();


    }
}
