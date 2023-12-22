using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Song
    {
        public Song()
        {
            AlbumSongs = new HashSet<AlbumSong>();
            PlaylistSongs = new HashSet<PlaylistSong>();
            RadioSongs = new HashSet<RadioSong>();
            SongArtists = new HashSet<SongArtist>();
        }

        public int Id { get; set; }
        public int? Rating { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int? Duration { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public virtual ICollection<AlbumSong> AlbumSongs { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
        public virtual ICollection<RadioSong> RadioSongs { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
