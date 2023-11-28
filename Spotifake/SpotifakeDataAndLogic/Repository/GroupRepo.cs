using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeDB.Repository
{
    public class GroupRepo
    {

        private const string FolderPath = @"C:\\Users\\giuse\\Desktop\\SpotiFake\";
        private const string FilePath = "Group.csv";
        private const string LogFilePath = "ErrorLog.txt";

        private const string FullGroupPath = FolderPath + FilePath;
        private const string LogFullPath = FolderPath + LogFilePath;

        private readonly SongRepo SongRepo;
        private readonly AlbumRepo AlbumRepo;

        public void CreateGroup(int id, string name, string bio)
        {
            try
            {
                Group group = new Group(id, name, bio);
                WriteGroupOnFile(group);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la creazione del gruppo: {ex.Message}");
            }
        }

        public void CreateSongFromGroup(string groupName, int songId, string songName, string songGenre, int songDuratio, string relaseDate)
        {
            try
            {
                Group group = FindGroupByName(groupName);
                if (group != null)
                {
                    Song song = new Song(songId, songName, songGenre, songDuratio, relaseDate);
                    song.Group.Add(group);
                    group.AddSong(song);

                    SongRepo.WriteSongOnFile(song);
                }
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la creazione della canzone dal gruppo: {ex.Message}");
            }
        }

        public void CreateAlbum(string GroupName, int id, string title, bool isLive)
        {
            try
            {
                Group group = FindGroupByName(GroupName);
                if (group != null)
                {
                    Album album = new Album(id, title, isLive);
                    album.Gruop = group;
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

        public List<Group> GetGroups()
        {
            try
            {
                return ReadGroupFromFile();
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la lettura dei gruppi: {ex.Message}");
                return new List<Group>();
            }
        }

        public Group FindGroupByName(string groupName)
        {
            try
            {
                List<Group> groups = ReadGroupFromFile();
                return groups.FirstOrDefault(g => g.GruopName == groupName);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la ricerca del gruppo: {ex.Message}");
                return null;
            }
        }

        public void WriteGroupOnFile(Group group)
        {
            try
            {
                List<Group> groups = new List<Group>() { group };
                CSVData<Group>.WriteonFile(FullGroupPath, groups);
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la scrittura del gruppo su file: {ex.Message}");
            }
        }

        public List<Group> ReadGroupFromFile()
        {
            try
            {
                return CSVData<Group>.CreateObject(File.ReadAllLines(FullGroupPath).ToList());
            }
            catch (Exception ex)
            {
                LogError($"Errore durante la lettura del file dei gruppi: {ex.Message}");
                return new List<Group>();
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
