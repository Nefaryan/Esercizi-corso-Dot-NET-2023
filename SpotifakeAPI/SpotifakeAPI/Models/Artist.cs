using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
            SongArtists = new HashSet<SongArtist>();
        }

        public int Id { get; set; }
        public string ArtistName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
