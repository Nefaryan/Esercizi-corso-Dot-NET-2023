using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.DTO.AlbumsDTO
{
    public class ArtistAlbumDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public bool IsLiveVersion { get; set; }
        public int NumberOfTrack { get; set; }

    }
}
