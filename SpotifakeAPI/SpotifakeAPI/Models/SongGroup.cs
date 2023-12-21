using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class SongGroup
    {
        public int GroupId { get; set; }
        public int SongId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Song Song { get; set; }
    }
}
