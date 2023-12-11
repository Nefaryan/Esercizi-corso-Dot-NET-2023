using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Entity.Music
{
    public class Radio
    {
        int _Id;
        string _Name;
        List<Song> _SongList;

        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public List<Song> SongList { get => _SongList; set => _SongList = value; }
    }
}
