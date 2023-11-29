using Spotifake.Entities;
using Spotifake.Model.Music;
using SpotifakeDB.Repository;
using SpotifakeLogic.Logic;
using System;
using System.Collections.Generic;



namespace Spotifake
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataCreation();

            MediaPlayer mediaPlayer = new MediaPlayer();

            Setting setting = new Setting(true,"Rock",true,1,SpotifakeDataAndLogic.PremiumType.FREE);
            User u = new User(1, "Gino", "Srorbillo", "DATE", "Ginuccio","void", setting);

            UIClass UI = new UIClass(mediaPlayer);
            UI.Run(u);
        }


        static void DataCreation()
        {
            SongRepo repo = new SongRepo();
            SongLogic sl = new SongLogic(repo);

            Song song1 = new Song(1, "song-1","Rock",180,"date");
            Song song2 = new Song(2, "song-2", "Rock", 180, "date");
            Song song3 = new Song(3, "song-3", "Rock", 180, "date");
            Song song4 = new Song(4, "song-4", "Rock", 180, "date");
            Song song5 = new Song(5, "song-5", "Rock", 180, "date");
            Song song6 = new Song(6, "song-6", "Rock", 180, "date");

            sl.WriteSongOnFile(song1);
            sl.WriteSongOnFile(song2);
            sl.WriteSongOnFile(song3);
            sl.WriteSongOnFile(song4);
            sl.WriteSongOnFile(song5);
            sl.WriteSongOnFile(song6);
            sl.WriteSongOnFile(song1);
        }

        
    }
}

