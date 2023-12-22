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
            GroupArtists = new HashSet<GroupArtist>();
            SongArtists = new HashSet<SongArtist>();
        }

        public int Id { get; set; }
        public string ArtistName { get; set; }
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<GroupArtist> GroupArtists { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
