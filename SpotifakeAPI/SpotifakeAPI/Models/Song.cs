using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Song
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int? Duration { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
