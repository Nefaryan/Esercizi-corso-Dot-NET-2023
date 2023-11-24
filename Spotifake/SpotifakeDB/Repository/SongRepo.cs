using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpotifakeDB.Repository
{
    public class SongRepo
    {
        private const string FolderPath =@"C:\\Users\\giuse\\Desktop\\SpotiFake\";
        private const string SongFilePath = "Songs.csv";

        private const string FullPath= FolderPath + SongFilePath;

        public void CreateSong(int id, string name,string genre,int durationInSecond, string relaseDate)
        {
            Song song = new Song(id, name, genre, durationInSecond, relaseDate);
            WriteSongOnFile(song);
        }

        public Song SearchSongByName(string name)
        {
            List<Song> song = RaedSongFormFile();
            return song.FirstOrDefault(s => s.Name == name);
        }


        private void WriteSongOnFile(Song song)
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            if (!File.Exists(SongFilePath))
            {
                File.Create(SongFilePath);
            }
            using (StreamWriter stream = new StreamWriter(FullPath))
            {
                if (new FileInfo(SongFilePath).Length == 0)
                {
                    stream.WriteLine("Id,Name,Genre,Duration,ReleaseDate,Rating,Artists,Groups,Albums");
                }
                string artist = string.Join(",", song.Artists.Select(a => a.ArtistName));
                string group = string.Join(",", song.Group.Select(g => g.GruopName));
                string album = string.Join(",", song.Albums.Select(alb => alb.Title));
                stream.WriteLine($"{song.Id},{song.Name},{song.Genre},{song.Duration},{song.RelaseDate},{song.Rating},{artist},{group},{album}");
            }
        }

        private List<Song> RaedSongFormFile()
        {
            List<Song> list = new List<Song>();
            if (File.Exists(FullPath))
            {
                string[] lines = File.ReadAllLines(FullPath);

                foreach (string item in lines.Skip(1))//Header Skip
                {
                    string[] values = item.Split(',');
                    if (values.Length == 9)
                    {
                        int id = int.Parse(values[0]);
                        string name = values[1];
                        string genre = values[2];
                        int durationInSecond = int.Parse(values[3]);
                        string relaseDate = values[4];
                        int rating  = int.Parse(values[5]);

                        List<Artist> artists = values[5].Split(',').Select(artistName => new Artist("", "", "", artistName)).ToList();
                        List<Group> groups = values[6].Split(',').Select(groupName => new Group(groupName)).ToList();
                        List<Album> albums = values[7].Split(',').Select(albumTitle => new Album(albumTitle)).ToList();


                        Song song = new Song(id, name, genre, durationInSecond, relaseDate);
                        song.Rating = rating;
                        song.Artists = artists;
                        song.Group = groups;
                        song.Albums = albums;
                        list.Add(song);
                    }
                }
            }
            return list;
        }
    }
}
