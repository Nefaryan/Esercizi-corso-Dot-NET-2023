using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpotifakeDB.Repository
{
    public class SongRepo
    {
        private const string FolderPath = @"C:\\Users\\giuse\\Desktop\\SpotiFake\";
        private const string SongFilePath = "Songs.csv";
        private const string LogFilePath = "ErrorLog.txt";

        private const string FullPath = FolderPath + SongFilePath;
        private const string LogFullPath = FolderPath + LogFilePath;

        public Song FindSongByName(string name)
        {
            try
            {
                List<Song> list = ReadSongFromFile();
                return list.FirstOrDefault(s => s.Name == name);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la ricerca della canzone per nome: {ex.Message}");
                return null;
            }
        }

        public void WriteSongOnFile(Song song)
        {
            try
            {
                List<Song> songs = new List<Song> { song };
                CSVData<Song>.WriteonFile(FullPath, songs);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la scrittura della canzone su file: {ex.Message}");
            }
        }

        public List<Song> ReadSongFromFile()
        {
            try
            {
                return CSVData<Song>.CreateObject(File.ReadAllLines(FullPath).ToList());
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la lettura del file delle canzoni: {ex.Message}");
                return new List<Song>();
            }
        }

        public List<Song> FindSongsInAlbum(string albumName)
        {
            try
            {
                List<Song> allSongs = ReadSongFromFile();
                List<Song> songsInAlbum = allSongs.Where(song => song.Albums.Any(album => album.Title == albumName)).ToList();
                return songsInAlbum;
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la ricerca delle canzoni nell'album: {ex.Message}");
                return new List<Song>();
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
