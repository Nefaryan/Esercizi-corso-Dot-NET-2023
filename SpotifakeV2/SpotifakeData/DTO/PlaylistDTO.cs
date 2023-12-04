using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.DTO
{
    public class PlaylistDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Song> Songs { get; set; }

        public PlaylistDTO(Playlist playlist)
        {
            ID = playlist.Id;
            Name = playlist.Name;
            Songs = playlist.Songs;       
        }
    }
}
