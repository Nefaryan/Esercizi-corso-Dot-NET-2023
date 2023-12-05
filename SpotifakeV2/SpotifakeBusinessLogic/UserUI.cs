using SpotifakeService.Service;
using SpotifakeData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SpotifakeService
{
    public class UserUI
    {
        private readonly UserService _userService;
        private readonly MediaPlayer _mediaPlayer;
        private readonly MovieMediaPlayer _movieMediaPlayer;

        public UserUI(UserService userService, MediaPlayer mediaPlayer, MovieMediaPlayer movieMediaPlayer)
        {
            _userService = userService;
            _mediaPlayer = mediaPlayer;
            _movieMediaPlayer = movieMediaPlayer;
        }

        public UserUI() {}

        public void SelectLanguage (User u)
        {
            Console.Clear();
            Console.WriteLine("===== Selezione la lingua =====");
            Console.WriteLine("I. Italiano");
            Console.WriteLine("E. English");
            char check = Console.ReadKey().KeyChar;
            switch (check)
            {
                case 'I':
                    u.CultureInfo = CultureInfo.CreateSpecificCulture("it-IT");
                    break;
                case 'E':
                    u.CultureInfo = CultureInfo.CreateSpecificCulture("en-US");
                    break;
            }

        }

        public void LogIn()
        {
            
            Console.Clear();
            Console.WriteLine("=== Esegui il LogIn ===");
            Console.WriteLine("Inserisci il tuo username:");
            string username = Console.ReadLine();
            Console.WriteLine("Inserisci la password ");
            string password = Console.ReadLine();

            var user = _userService.LogIn(username, password);

            if (user != null)
            {
                Console.WriteLine("Dati corretti");
                SelectLanguage(user);
                Console.WriteLine("Inserisci S. Per selezionare la musica o M. per selezionare i film");
                string selection = Console.ReadLine();
                HandleMenuChoice(user, selection);
                
            }
            else
            {
                Console.WriteLine("LogIn Fattilto riprova");
            }
        }

        public void MusicPlayer(User user)
        {
            while (true)
            {
                Console.WriteLine("=== Music Player Menu ===");
                Console.WriteLine("0. Vedi tutti i brani");
                Console.WriteLine("1. Play Song");
                Console.WriteLine("2. Show Album");
                Console.WriteLine("3. Show Playlist");
                Console.WriteLine("4. Next Song");
                Console.WriteLine("5. Previous Song");
                Console.WriteLine("6. Pause Song");
                Console.WriteLine("7. Stop Song");
                Console.WriteLine("8. Top 5 Rating Songs");
                Console.WriteLine("9. Top 5 Rating Album");
                Console.WriteLine("X. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                HandleMenuChoice(user,choice);
            }
        }

        public void VideoPlayer(User user)
        {
            while (true)
            {
                Console.WriteLine("=== Video Player Menu ===");
                Console.WriteLine("A. Mostra tutti i film");
                Console.WriteLine("B. Mostra la Top 5 dei film più visti");
                Console.WriteLine("C. Riproduci Film");
                Console.WriteLine("P. Interrompi Riproduzione");
            }  
        }

        private void HandleMenuChoice(User user,string choice)
        {
            switch (choice.ToLower())
            {
                case "0":
                    Console.WriteLine(_mediaPlayer.SeeAllSong());
                    break;
                case "1":
                    Console.WriteLine("Enter song name:");
                    string songName = Console.ReadLine();
                    Console.WriteLine(_mediaPlayer.PlaySong(user, songName));
                    break;
                case "2":
                    Console.WriteLine(_mediaPlayer.SeeAllAlbum()); 
                    break;
                case "3":
                    Console.WriteLine(_mediaPlayer.SeeAllPlayList()); 
                    break;
                case "4":
                    Console.WriteLine(_mediaPlayer.NextSong(user));
                    break;
                case "5":
                    Console.WriteLine(_mediaPlayer.PreviousSong(user));
                    break;
                case "6":
                    Console.WriteLine(_mediaPlayer.PauseSong());
                    break;
                case "7":
                    Console.WriteLine(_mediaPlayer.PauseSong());
                    break;
                case "8":
                    Console.WriteLine(_mediaPlayer.Top5Song());
                    break;
                case "9":
                    Console.WriteLine(_mediaPlayer.Top5Album()); 
                    break;
                case "x":
                    Environment.Exit(0);
                    break;
                case "S":
                    MusicPlayer(user);
                    break;
                case "M":
                     VideoPlayer(user);
                    break;
                case "A":
                    Console.WriteLine("Ecco la lista dei movies");
                    Console.WriteLine(_movieMediaPlayer.SeeAllMovie());
                    Console.WriteLine("--------------------------------");
                    break;
                case "B":
                    Console.WriteLine("Miglior 5 movie del servizio");
                    Console.WriteLine(_movieMediaPlayer.Top5Movie());
                    Console.WriteLine("--------------------------------");
                    break;
                case "C":
                    Console.WriteLine("Inserisci il nome del movie da riprodurre");
                    int movieId = Console.Read();
                    Console.WriteLine(_movieMediaPlayer.PlayMovie(user, movieId));
                    Console.WriteLine("Inizio della riproduzione");
                    break;
                case "P":
                    Console.WriteLine("Pausa");
                    Console.WriteLine(_movieMediaPlayer.PauseMovie());
                    Console.WriteLine("--------------------------------");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}