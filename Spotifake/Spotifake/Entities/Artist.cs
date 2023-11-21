using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    internal class Artist : Person
    {
        string _artistName;
        List<Album> _album;
        List<Artist> _artists;
        string _bio;
        Group _group;

        public Artist(string name, string surname, string dateOfB, string artistName, string biog, Group group) : base(name, surname, dateOfB)
        {
            _artistName = artistName;
            _album = new List<Album>();
            _artists = new List<Artist>();
            _bio = biog;
            _group = group;
        }

        public string ArtistName { get => _artistName; set => _artistName = value; }
        public string Bio { get => _bio; set => _bio = value; }
        public Group Group { get => _group; set => _group = value; }
        internal List<Album> Album { get => _album; set => _album = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
    }
}
