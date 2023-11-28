using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Model.Music
{
    public class Radio
    {

        List<Song> _songs;
        string _name;
        int _id;

        public Radio (string name, int id)
        {
            _id = id;
            _songs = new List<Song> ();
            _name = name;
        }

        public List<Song> Songs { get => _songs; set => _songs = value; }
        public string Name { get => _name; set => _name = value; }
        public int Id { get => _id; set => _id = value; }
    }
}
