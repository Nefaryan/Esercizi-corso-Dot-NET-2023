using Spotifake.Entities;
using Spotifake.Model.Music;
using System;

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

        //static FakeDB InitFakeDb() 
        //{
        //    FakeDB fakeDB = new FakeDB();

        //    Song song = new Song(1,"Song1","Rock",180,"2023-02-01");
        //    Song song1 = new Song(2,"Song2", "Rock", 180, "2023-02-01");
        //    Song song2 = new Song(3,"Song3", "Rock", 180, "2023-02-01");
        //    Song song3 = new Song(4,"Song4", "Rock", 180, "2023-02-01");

        //    fakeDB.AddSong(song);
        //    fakeDB.AddSong(song1);
        //    fakeDB.AddSong(song2);
        //    fakeDB.AddSong(song3);

        //    Album album1 = new Album(1,"Album1", false);
        //    Album album2 = new Album(2,"Album2", false);

        //    album1.Song.Add(song);
        //    album2.Song.Add(song1);
        //    album2.Song.Add(song2);
        //    album1.Song.Add(song3);

        //    fakeDB.addAlbum(album1);
        //    fakeDB.addAlbum(album2);

        //    Playlist playlist = new Playlist("Ciccio");

        //    playlist.AddSong(song);
        //    playlist.AddSong(song1);

        //    fakeDB.addPlaylist(playlist);

        //    return fakeDB;
            
        }
    }

}
