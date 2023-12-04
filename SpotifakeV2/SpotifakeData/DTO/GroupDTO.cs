using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.DTO
{
    public class GroupDTO
    {
        public string GroupName { get; set; }
        public string Bio { get; set; }
        public List<Song> Songs { get; set; }

        public GroupDTO(Group group)
        {
            GroupName = group.GruopName;
            Bio = group.Bio;
            Songs = group.Song;
        }
    }
}
