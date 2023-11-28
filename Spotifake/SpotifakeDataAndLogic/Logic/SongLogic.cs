using Spotifake.Model.Music;
using SpotifakeDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeLogic.Logic
{
    public class SongLogic
    {
        private readonly SongRepo songRepo;

        public SongLogic(SongRepo songRepo)
        {
            this.songRepo = songRepo;
        }

        public Song FindSongByName(string name)
        {
            return songRepo.FindSongByName(name);
        }

        public void WriteSongOnFile(Song song)
        {
            List<Song> songs = new List<Song> { song };
            songRepo.WriteSongOnFile(song);
        }

        public List<Song> ReadSongFromFile()
        {
            return songRepo.ReadSongFromFile();
        }
    }
}
