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
        }

        public int Id { get; set; }
        public string ArtistName { get; set; }
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
