﻿using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeDB.Repository
{
    public class AlbumRepo
    {
        private const string FolderPath = @"C:\\Users\\giuse\\Desktop\\SpotiFake\";
        private const string SongFilePath = "Album.csv";

        private const string FullPath = FolderPath + SongFilePath;

        public void CreateArtistAlbum() { }
        public void CreateGroupAlmun() { }

        public Album SearchAlbumByName(string name)
        {
            return null;
        
        }
        public void AddSongToAlbum(string albumName, string songName) { }
        

    }
}