using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.DTO.AlbumsDTO
{
    public class GroupAlbumDTOcs
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Group Group { get; set; }
        public bool IsLiveVersion { get; set; }
        public int NumberOfTrack { get; set; }
    }
}
