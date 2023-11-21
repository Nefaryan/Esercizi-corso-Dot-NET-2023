using Spotifake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    internal class MediaPlayer : IMedia
    {
        List<Song> songs;

        public void NextSong()
        {
            throw new NotImplementedException();
        }

        public void PauseSong()
        {
            throw new NotImplementedException();
        }

        public void PlayAlbum(string albumName)
        {
            throw new NotImplementedException();
        }

        public void PlayPlaylist(string playlistName)
        {
            throw new NotImplementedException();
        }

        public void PlaySong(string songName)
        {
            throw new NotImplementedException();
        }

        public void PreviousSong()
        {
            throw new NotImplementedException();
        }

        public void StopSong()
        {
            throw new NotImplementedException();
        }
    }
}
