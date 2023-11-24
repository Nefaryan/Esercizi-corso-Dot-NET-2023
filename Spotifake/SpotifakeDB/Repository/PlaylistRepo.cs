using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeDB.Repository
{
    public class PlaylistRepo
    {
        private const string FolderPath = @"C:\\Users\\giuse\\Desktop\\SpotiFake\";
        private const string FilePath = "Playlist.csv";

        private const string FullPath = FolderPath + FilePath;

        private SongRepo SongRepo;

        public void CreatePlayList(int id,string name)
        {
            Playlist playlist = new Playlist(name,id);
            WritePlaylistOnFile(playlist);
        }

        public void AddSongToPlayList(string playlistName, string songName)
        {
            Playlist p = GetByName(playlistName);
            Song song = SongRepo.FindSongByName(songName);

            if(song != null && p !=null) 
            {
                p.AddSong(song);
                WritePlaylistOnFile(p);
            }
        }

        public Playlist GetByName(string name)
        {
            List<Playlist> list = ReadPlaylistFromFile();
            return list.FirstOrDefault(x => x.Name == name);
        }


        public void WritePlaylistOnFile(Playlist playlist)
        {
            List<Playlist> list = new List<Playlist>() { playlist };
            CSVData<Playlist>.WriteonFile(FullPath, list);
        }

        public List<Playlist> ReadPlaylistFromFile()
        {
            return CSVData<Playlist>.CreateObject(File.ReadAllLines(FullPath).ToList());
        }

    }
}
