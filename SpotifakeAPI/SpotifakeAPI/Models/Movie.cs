using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Regista { get; set; }
        public string Genre { get; set; }
        public int? Duration { get; set; }
        public int? Raiting { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
