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
        private const string LogFilePath = "ErrorLog.txt";

        private const string FullPath = FolderPath + FilePath;
        private const string LogFullPath = FolderPath + LogFilePath;

        private readonly SongRepo SongRepo;

        public PlaylistRepo()
        {
            SongRepo = new SongRepo();
        }

        public void CreatePlaylist(int id, string name)
        {
            try
            {
                Playlist playlist = new Playlist(name, id);
                WritePlaylistOnFile(playlist);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la creazione della playlist: {ex.Message}");
            }
        }

        public void AddSongToPlaylist(string playlistName, string songName)
        {
            try
            {
                Playlist playlist = GetByName(playlistName);
                Song song = SongRepo.FindSongByName(songName);

                if (song != null && playlist != null)
                {
                    playlist.AddSong(song);
                    WritePlaylistOnFile(playlist);
                }
            }
            catch (Exception ex)
            {
                LogError($"Errore durante l'aggiunta della canzone alla playlist: {ex.Message}");
            }
        }

        public Playlist GetByName(string name)
        {
            try
            {
                List<Playlist> list = ReadPlaylistFromFile();
                return list.FirstOrDefault(x => x.Name == name);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la ricerca della playlist per nome: {ex.Message}");
                return null;
            }
        }

        public List<Song> FindSongsInPlaylist(string playlistName)
        {
            try
            {
                Playlist playlist = GetByName(playlistName);

                if (playlist != null)
                {
                    return playlist.Songs;
                }
                else
                {
                    return new List<Song>(); // Playlist non trovata o vuota
                }
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la ricerca delle canzoni nella playlist: {ex.Message}");
                return new List<Song>();
            }
        }

        public void WritePlaylistOnFile(Playlist playlist)
        {
            try
            {
                List<Playlist> list = new List<Playlist>() { playlist };
                CSVData<Playlist>.WriteonFile(FullPath, list);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la scrittura della playlist su file: {ex.Message}");
            }
        }

        public List<Playlist> ReadPlaylistFromFile()
        {
            try
            {
                return CSVData<Playlist>.CreateObject(File.ReadAllLines(FullPath).ToList());
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la lettura del file delle playlist: {ex.Message}");
                return new List<Playlist>();
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
