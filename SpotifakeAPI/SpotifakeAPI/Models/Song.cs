using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Song
    {
        public Song()
        {
            SongAlbums = new HashSet<SongAlbum>();
            SongArtists = new HashSet<SongArtist>();
            SongGroups = new HashSet<SongGroup>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<SongAlbum> SongAlbums { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
        public virtual ICollection<SongGroup> SongGroups { get; set; }
    }
}
