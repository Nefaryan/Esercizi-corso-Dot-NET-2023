using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Playlist
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
    }
}
