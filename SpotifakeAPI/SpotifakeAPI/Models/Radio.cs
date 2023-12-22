using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Radio
    {
        public Radio()
        {
            RadioSongs = new HashSet<RadioSong>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RadioSong> RadioSongs { get; set; }
    }
}
