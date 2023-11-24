﻿using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpotifakeDB.Repository
{
    public class SongRepo
    {
        private const string FolderPath =@"C:\\Users\\giuse\\Desktop\\SpotiFake\";
        private const string SongFilePath = "Songs.csv";

        private const string FullPath= FolderPath + SongFilePath;

        public void WriteOnFile(Song song)
        {
            List<Song> songs = new List<Song> { song };
            CSVData<Song>.WriteonFile(FullPath, songs);
        }

        public List<Song> ReadSongFromFile()
        {
            return CSVData<Song>.CreateObject(File.ReadAllLines(FullPath).ToList());
        }

        
    }
}
