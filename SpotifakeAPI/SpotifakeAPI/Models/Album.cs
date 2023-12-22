using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Album
    {
        public Album()
        {
            AlbumSongs = new HashSet<AlbumSong>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ArtistId { get; set; }
        public int? GruopId { get; set; }
        public bool? IsLiveVersionAlbum { get; set; }
        public int? NofTrack { get; set; }
        public int? Raiting { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Group Gruop { get; set; }
        public virtual ICollection<AlbumSong> AlbumSongs { get; set; }
    }
}
