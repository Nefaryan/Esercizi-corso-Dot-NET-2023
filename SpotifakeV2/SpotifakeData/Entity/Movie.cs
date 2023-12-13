using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Entity
{
    public class Movie
    {
        int _Id;
        string _title;
        string _regista;
        string _genre;
        int _duration;
        int raiting;
        DateTime ReleaseDate;

        public int Id { get => _Id; set => _Id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Regista { get => _regista; set => _regista = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public int Raiting { get => raiting; set => raiting = value; }
        public DateTime ReleaseDate1 { get => ReleaseDate; set => ReleaseDate = value; }
    }
}
