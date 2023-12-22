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
            Artists = new HashSet<Artist>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
