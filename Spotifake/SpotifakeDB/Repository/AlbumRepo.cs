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

        private const string LogFilePath = "ErrorLog.txt";

        private const string FullPath = FolderPath + SongFilePath;
        private const string LogFullPath = FolderPath + LogFilePath;

        private readonly SongRepo SongRepo;

        public void CreateNewAlbum(int id, string title, bool isLive)
        {
            try
            {
                Album album = new Album(id, title, isLive);
                WriteAlbumOnFile(album);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la creazione dell'album: {ex.Message}");
            }
        }

        public Album FindAlbumByName(string albumName)
        {
            try
            {
                List<Album> list = ReadAlbumFromFile();
                return list.FirstOrDefault(a => a.Title == albumName);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la ricerca dell'album: {ex.Message}");
                return null;
            }
        }

        public void AddSongToAlbum(string songName, string albumName)
        {
            try
            {
                Album album = FindAlbumByName(albumName);
                Song song = SongRepo.FindSongByName(songName);

                if (song != null && album != null)
                {
                    album.Song.Add(song);
                }
            }
            catch (Exception ex)
            {
                LogError($"Errore durante l'aggiunta della canzone all'album: {ex.Message}");
            }
        }

        public void WriteAlbumOnFile(Album album)
        {
            try
            {
                List<Album> list = new List<Album>() { album };
                CSVData<Album>.WriteonFile(FullPath, list);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la scrittura dell'album su file: {ex.Message}");
            }
        }

        public List<Album> ReadAlbumFromFile()
        {
            try
            {
                return CSVData<Album>.CreateObject(File.ReadAllLines(FullPath).ToList());
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la lettura del file degli album: {ex.Message}");
                return new List<Album>();
            }
        }

        private void LogError(string errorMessage)
        {
            using (StreamWriter sw = File.AppendText(LogFullPath))
            {
                sw.WriteLine($"{DateTime.Now}: {errorMessage}");
            }
        }




    }
}
