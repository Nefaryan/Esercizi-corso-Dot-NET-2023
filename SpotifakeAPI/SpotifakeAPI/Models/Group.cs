using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Group
    {
        public Group()
        {
            Albums = new HashSet<Album>();
            SongGroups = new HashSet<SongGroup>();
        }

        public int Id { get; set; }
        public string GruopName { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<SongGroup> SongGroups { get; set; }
    }
}
