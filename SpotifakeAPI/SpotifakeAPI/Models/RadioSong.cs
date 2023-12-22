using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class RadioSong
    {
        public int RadioId { get; set; }
        public int SongId { get; set; }

        public virtual Radio Radio { get; set; }
        public virtual Song Song { get; set; }
    }
}
