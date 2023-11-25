using Spotifake.Model.Music;
using SpotifakeDB.Repository;
using System;

namespace SpotifakeLogic.Logic
{
    public class GroupLogic
    {

        private readonly GroupRepo groupRepo;
        private readonly ArtistRepo artistRepo;

        public GroupLogic(GroupRepo groupRepo, ArtistRepo artistRepo)
        {
            this.groupRepo = groupRepo;
            this.artistRepo = artistRepo;
        }

        public void CreateGroup(string groupName)
        {
            Group group = new Group(groupName);
            groupRepo.WriteGroupOnFile(group);

            // Puoi aggiungere ulteriore logica qui se necessario
        }

        public void AddArtistToGroup(string groupName, string artistName)
        {
            Group group = groupRepo.FindGroupByName(groupName);
            Artist artist = artistRepo.FindArtistByName(artistName);

            if (group != null && artist != null)
            {
                group.Artists.Add(artist);
                // Potresti voler aggiornare le informazioni sul gruppo nel repository qui
            }
        }

        public void CreateArtistInGroup(string groupName, string artistName, string bio)
        {
            Artist artist = artistRepo.FindArtistByName(artistName);
            if (artist == null)
            {
                artistRepo.CreateArtist(artistName, bio);
                artist = artistRepo.FindArtistByName(artistName);
            }

            AddArtistToGroup(groupName, artistName);
        }

        public void CreateSongFromGroup(string groupName, int songId, string songName, string songGenre, int songDuration, string releaseDate)
        {
            Artist artist = GetFirstArtistInGroup(groupName);

            if (artist != null)
            {
                artistRepo.CreateSongFromArtist(artist.ArtistName, songId, songName, songGenre, songDuration, releaseDate);
            }
        }

        public void CreateAlbumForGroup(string groupName, int albumId, string albumTitle, bool isLive)
        {
            Artist artist = GetFirstArtistInGroup(groupName);

            if (artist != null)
            {
                artistRepo.CreateAlbum(artist.ArtistName, albumId, albumTitle, isLive);
            }
        }

        public void AddSongToGroupAlbum(string groupName, string albumName, string songName)
        {
            Artist artist = GetFirstArtistInGroup(groupName);

            if (artist != null)
            {
                artistRepo.AddSongToAlbum(albumName, songName);
            }
        }

        private Artist GetFirstArtistInGroup(string groupName)
        {
            Group group = groupRepo.FindGroupByName(groupName);

            if (group != null && group.Artists.Count > 0)
            {
                return group.Artists[0];
            }

            return null;
        }

    }
}
