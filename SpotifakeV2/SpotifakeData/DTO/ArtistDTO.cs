using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.DTO
{
    public class ArtistDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ArtistName { get; set; }
        public List<Song> Songs { get; set; }
        public ArtistDTO(Artist artist)
        {
            Name = artist.Name;
            Surname = artist.Surname;
            ArtistName = artist.ArtistName;   
            Songs = artist.Songs;
        }
    }
}
