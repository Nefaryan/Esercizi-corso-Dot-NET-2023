using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeDB.Repository
{
    public class AlbumRepo
    {
        private const string FolderPath = @"C:\\Users\\giuse\\Desktop\\SpotiFake\";
        private const string SongFilePath = "Album.csv";

        private const string FullPath = FolderPath + SongFilePath;

        private readonly SongRepo SongRepo;

        public void CreateNewAlbum(int id,string title,bool isLive)
        {
            Album album = new Album(id,title,isLive);
            WriteAlbumOnFile(album);
        }

        public Album FindAlbumByName(string albumName)
        {
            List<Album> list = ReadAlbumFromFile();
            return list.FirstOrDefault(a=> a.Title == albumName);
        }

        public void AddSongToAlbum(string songName, string albumName)
        {
            Album album = FindAlbumByName(albumName);
            Song song = SongRepo.FindSongByName(songName);

            if(song != null && album != null) 
            {
                album.Song.Add(song);   
            }
        
        }

        public void WriteAlbumOnFile(Album album)
        {
            List<Album> list = new List<Album>() { album };
            CSVData<Album>.WriteonFile(FullPath, list);
        }
        public List<Album> ReadAlbumFromFile()
        {
            return CSVData<Album>.CreateObject(File.ReadAllLines(FullPath).ToList());
        }




    }
}
