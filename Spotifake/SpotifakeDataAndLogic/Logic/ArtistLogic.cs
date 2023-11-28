using Spotifake.Model.Music;
using SpotifakeDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeLogic.Logic
{
    public class ArtistLogic
    {
        private readonly ArtistRepo repo;

        public ArtistLogic(ArtistRepo artistRepo)
        {
            repo = artistRepo;
        }

        public void CreateArtist(string artName, string bio)
        {
            repo.CreateArtist(artName, bio);
        }

        public void CreateSong(string artName, int songId, string songName, string songGenre, int songDuration, string releaseDate)
        {
            repo.CreateSongFromArtist(artName, songId, songName, songGenre, songDuration, releaseDate);
        }

        public void CreateAlbum(string artistName, int id, string title, bool isLive)
        {
            repo.CreateAlbum(artistName, id, title, isLive);
        }

        public void AddSongToAlbum(string albumName, string songName)
        {
            repo.AddSongToAlbum(albumName, songName);
        }

        public Artist FindArtistByName(string artistName)
        {
            return repo.FindArtistByName(artistName);
        }

        public List<Artist> ReadArtistsFromFile()
        {
            return repo.ReadArtistFromFile();
        }



    }
}
