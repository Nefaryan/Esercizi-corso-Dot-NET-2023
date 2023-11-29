using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeDB.Repository
{
    public class ArtistRepo
    {
        private const string FolderPath = @"C:\\Users\\giuse\\Desktop\\SpotiFake\";
        private const string ArtistFilePath = "Artist.csv";
        private const string LogFilePath = "ErrorLog.txt";

        private const string FullArtistPath = FolderPath + ArtistFilePath;
        private const string LogFullPath = FolderPath + LogFilePath;

        private readonly SongRepo SongRepo;
        private readonly AlbumRepo AlbumRepo;

        public void CreateArtist(string artName, string bio)
        {
            try
            {
                Artist artist = new Artist(artName, bio);
                WriteArtistOnfile(artist);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la creazione dell'artista: {ex.Message}");
            }
        }

        public void CreateSongFromArtist(string artName, int songId, string songName, string songGenre, int songDuratio, string relaseDate)
        {
            try
            {
                Artist artist = FindArtistByName(artName);
                if (artist != null)
                {
                    Song song = new Song(songId, songName, songGenre, songDuratio, relaseDate);
                    song.Artists.Add(artist);
                    artist.AddSong(song);

                    SongRepo.WriteSongOnFile(song);
                }
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la creazione della canzone dall'artista: {ex.Message}");
            }
        }

        public void CreateAlbum(string ArtistName, int id, string title, bool isLive)
        {
            try
            {
                Artist artist = FindArtistByName(ArtistName);
                if (artist != null)
                {
                    Album album = new Album(id, title, isLive);
                    album.Artist = artist;
                    AlbumRepo.WriteAlbumOnFile(album);
                }
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la creazione dell'album: {ex.Message}");
            }
        }

        public void AddSongToAlbum(string albumName, string songName)
        {
            try
            {
                Album album = AlbumRepo.FindAlbumByName(albumName);
                Song song = SongRepo.FindSongByName(songName);
                if (album != null && song != null)
                {
                    album.Song.Add(song);
                }
            }
            catch (Exception ex)
            {
                LogError($"Errore durante l'aggiunta della canzone all'album: {ex.Message}");
            }
        }

        public Artist FindArtistByName(string artistName)
        {
            try
            {
                List<Artist> artists = ReadArtistFromFile();
                return artists.FirstOrDefault(ar => ar.ArtistName == artistName);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la ricerca dell'artista: {ex.Message}");
                return null;
            }
        }

        public void WriteArtistOnfile(Artist artist)
        {
            try
            {
                List<Artist> list = new List<Artist>() { artist };
                CSVData<Artist>.WriteonFile(FullArtistPath, list);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la scrittura dell'artista su file: {ex.Message}");
            }
        }

        public List<Artist> ReadArtistFromFile()
        {
            try
            {
                return CSVData<Artist>.CreateObject(File.ReadAllLines(FullArtistPath).ToList());
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la lettura del file degli artisti: {ex.Message}");
                return new List<Artist>();
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
