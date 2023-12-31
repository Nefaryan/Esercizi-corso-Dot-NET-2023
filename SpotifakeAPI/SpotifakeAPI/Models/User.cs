﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class User
    {
        public User()
        {
            Playlists = new HashSet<Playlist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CultureInfo { get; set; }

        public virtual Setting Setting { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
