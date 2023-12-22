using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ArtistId { get; set; }
        public int? GroupId { get; set; }
        public bool? IsLiveVersionAlbum { get; set; }
        public int? NofTrack { get; set; }
        public int? Raiting { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Group Group { get; set; }
    }
}
