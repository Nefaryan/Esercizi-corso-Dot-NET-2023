﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Model.Music
{
    public class Song
    {
        int _Id;
        int _rating;
        string _name;
        string _genre;
        int _duration;
        string _relaseDate;
        List<Album> _albums;
        List<Group> _group;
        List<Artist> _artists;

        public Song() { }

        public Song(int id, string name, string genre, int duration, string relaseDate)
        {
            _Id = id;
            _name = name;
            _genre = genre;
            _duration = duration;
            _relaseDate = relaseDate;
            _albums = new List<Album>();
            _group = new List<Group>();
            _artists = new List<Artist>();
            _rating = 0;
        }
        public string Name { get => _name; set => _name = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public string RelaseDate { get => _relaseDate; set => _relaseDate = value; }
        public int Rating { get => _rating; set => _rating = value; }
        public int Id { get => _Id; set => _Id = value; }
        public List<Album> Albums { get => _albums; set => _albums = value; }
        public List<Group> Group { get => _group; set => _group = value; }
        public List<Artist> Artists { get => _artists; set => _artists = value; }
    }
}
