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

        public UserUI(UserService userService, MediaPlayer mediaPlayer)
        {
            _userService = userService;
            _mediaPlayer = mediaPlayer;
        }

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
                ShowMenu(user);
                ShowMenu(user);
            }
            else
            {
                Console.WriteLine("LogIn Fattilto riprova");
            }
        }

        public void ShowMenu(User user)
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
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}