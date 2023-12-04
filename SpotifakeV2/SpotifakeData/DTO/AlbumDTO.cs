using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.DTO.AlbumsDTO
{
    public class AlbumDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Group Group { get; set; }
        public Artist Artist { get; set; }
        public bool IsLiveVersion { get; set; }
        public int NumberOfTrack { get; set; }
        public List<Song> Songs { get; set; }

        public AlbumDTO(Album album)
        {
            ID = album.ID;
            Title = album.Title;
            Group = album.Gruop;
            Artist = album.Artist;
            IsLiveVersion = album.IsLiveVersionAlbum;
            NumberOfTrack = album.NOfTrack;
            Songs = album.Song;
        }
    }
}
