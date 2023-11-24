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

        private const string FullGroupPath = FolderPath + FilePath;

        private readonly SongRepo SongRepo;
        private readonly AlbumRepo AlbumRepo;

        public void CreateGroup(int id,string name,string bio)
        {
            Group group = new Group(id,name,bio);
            WriteGroupOnFile(group);
        }

        public void CreateSongFromGroup(string groupName,
            int songId, string songName, string songGenre, int songDuratio, string relaseDate)
        {
            Group group = FindGroupByName(groupName);
            if(group != null)
            {
                Song song = new Song(songId,songName,songGenre,songDuratio,relaseDate);
                song.Group.Add(group);
                group.AddSong(song);

                SongRepo.WriteSongOnFile(song);
                
            }

        }

        public void CreateAlbum(string GroupName, int id, string title, bool isLive)
        {
            Group group = FindGroupByName(GroupName);
            if (group != null)
            {
                Album album = new Album(id, title, isLive);
                album.Gruop = group;
                AlbumRepo.WriteAlbumOnFile(album);
            }

        }

        public void AddSongToAlbum(string albumName,string songName) 
        {
            Album album = AlbumRepo.FindAlbumByName(albumName);
            Song song = SongRepo.FindSongByName(songName);
            if (album != null && song != null)
            {
                album.Song.Add(song);
            }
        
        
        }

        public List<Group> GetGroups()
        {
            return ReadGroupFromFile();
        }

        public Group FindGroupByName(string groupName)
        {
            List<Group> groups = ReadGroupFromFile();
            return groups.FirstOrDefault(g => g.GruopName == groupName);
        }

        public void WriteGroupOnFile(Group group)
        {
            List<Group> groups = new List<Group>() { group};
            CSVData<Group>.WriteonFile(FullGroupPath, groups);
        }

        public List<Group> ReadGroupFromFile() 
        { 
            return CSVData<Group>.CreateObject(File.ReadAllLines(FullGroupPath).ToList());
        
        }
    }
}
