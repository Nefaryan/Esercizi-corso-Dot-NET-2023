using Spotifake.Entities;
using Spotifake.Model.Music;
using System;
using System.Collections.Generic;



namespace Spotifake
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //    FakeDB db = InitFakeDb();

            //    Setting setting = new Setting(true, "rock", false, 1);

            //    User cUser = new User(1,"Gino", "Cadrino", "ddddd", "user", "pass",setting);

            //    MediaPlayer mediaPlayer = new MediaPlayer();

            //    Console.WriteLine("Benvenuto in Spotifake!!");
            //    string check;
            //    do
            //    {
            //        DisplayMenu();


            //        Console.Write("Scelta: ");
            //        check = Console.ReadKey().KeyChar.ToString();

            //        switch (check.ToUpper())
            //        {
            //            case "A":
            //                db.ShowArtists();
            //                break;
            //            case "D":
            //                db.ShowAlbums();
            //                break;
            //            case "P":
            //                db.ShowPlaylists();
            //                break;
            //            case "P1":
            //                Console.WriteLine("\nInserisci il nome della playlist");
            //                string playListName = Console.ReadLine();
            //                Playlist playlist = db.SelectPlaylist(playListName);
            //                mediaPlayer.AddPlayList(playlist);
            //                mediaPlayer.PlayPlaylist(playlist.Name);
            //                break;
            //            case "C":
            //                Console.Write("\nInserisci il nome della canzone da cercare: ");
            //                string searchQuery = Console.ReadLine();
            //                db.SearchSong(searchQuery);
            //                break;
            //            case "L":
            //                Console.Write("\nInserisci il titolo della canzone da riprodurre: ");
            //                string songTitle = Console.ReadLine();
            //                Song selectedSong = db.SelectSong(songTitle);
            //                mediaPlayer.AddToQueue(selectedSong);
            //                mediaPlayer.PlayQueue();
            //                break;
            //            case "F":
            //                mediaPlayer.PreviousSong(cUser);
            //                break;
            //            case "B":
            //                mediaPlayer.NextSong(cUser);
            //                break;
            //            case "S":
            //                mediaPlayer.StopSong();
            //                break;
            //            case "Z":
            //                mediaPlayer.PauseSong();
            //                break;
            //            case "X":
            //                Console.WriteLine();
            //                Environment.Exit(0);
            //                break;
            //            default:
            //                Console.WriteLine("Scelta non valida. Riprova.");
            //                break;
            //        }
            //    } while (check.ToUpper() != "X");

            //}

            //static void DisplayMenu()
            //{
            //    Console.WriteLine("\nMenu:");
            //    Console.WriteLine("A. Mostra tutti gli artisti");
            //    Console.WriteLine("D. Mostra tutti gli album");
            //    Console.WriteLine("P. Mostra le playlist");
            //    Console.WriteLine("P1. Riproduci playlist");
            //    Console.WriteLine("C. Cerca una canzone");
            //    Console.WriteLine("L. Riproduci una canzone");
            //    Console.WriteLine("F. Passa alla prossima canzone");
            //    Console.WriteLine("B. Riproduci la canzone precedente");
            //    Console.WriteLine("S. Ferma la riproduzione");
            //    Console.WriteLine("Z. Metti in pausa la riproduzione");
            //    Console.WriteLine("X. Chiudi L'applicazione");
            //}
        }
    }
}

