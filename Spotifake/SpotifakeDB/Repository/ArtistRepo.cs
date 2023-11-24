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

        private const string FullArtistPath = FolderPath + ArtistFilePath;

        private readonly SongRepo SongRepo;

        public void CreateArtist(string artName,string bio)
        {
            Artist artist = new Artist(artName,bio);
            WriteArtistOnfile(artist);
        }

        public void CreateSongFromArtist(string artName,
           int songId,string songName,string songGenre,int songDuratio,string relaseDate)
        {
            Artist artist = FindArtistByName(artName);
            if(artist != null) 
            {
                Song song = new Song(songId,songName,songGenre,songDuratio,relaseDate);
                song.Artists.Add(artist);
                artist.AddSong(song);

                SongRepo.WriteSongOnFile(song); 
            }
        }
        public Artist FindArtistByName(string artistName) 
        {
            List<Artist> artists = ReadArtistFromFile();
            return artists.FirstOrDefault(ar => ar.ArtistName == artistName);
        
        }
        public void WriteArtistOnfile(Artist artist)
        {
            List<Artist> list = new List<Artist>() {artist};
            CSVData<Artist>.WriteonFile(FullArtistPath, list);
        }
        public List<Artist> ReadArtistFromFile()
        {
            return CSVData<Artist>.CreateObject(File.ReadAllLines(FullArtistPath).ToList());
        }

    }
}
