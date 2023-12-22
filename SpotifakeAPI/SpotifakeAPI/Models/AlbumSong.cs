using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class AlbumSong
    {
        public int AlbumId { get; set; }
        public int SongId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Song Song { get; set; }
    }
}
