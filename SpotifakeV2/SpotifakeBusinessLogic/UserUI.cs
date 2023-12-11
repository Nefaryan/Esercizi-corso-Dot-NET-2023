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

        // Costante per il comando di uscita dal menu
        private const string MenuExitCommand = "X";

        
        public UserUI(UserService userService, MediaPlayer mediaPlayer, MovieMediaPlayer movieMediaPlayer)
        {
            
            _userService = userService;
            _mediaPlayer = mediaPlayer;
            _movieMediaPlayer = movieMediaPlayer;
        }

        // Metodo principale per eseguire l'applicazione
        public void Run()
        {
            Console.WriteLine("Benvenuto!");

            while (true)
            {
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");
              
                string mainMenuChoice = Console.ReadLine();

                switch (mainMenuChoice)
                {
                    case "1":
                        LogIn();
                        break;
                    case "2":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
 
        private void LogIn()
        {
            Console.Clear();
            Console.WriteLine("=== Esegui il LogIn ===");
            Console.WriteLine("Inserisci il tuo username:");
            string username = Console.ReadLine();
            Console.WriteLine("Inserisci la password ");
            string password = Console.ReadLine();

            try
            {
                var user = _userService.LogIn(username, password);

                if (user != null)
                {
                    Console.WriteLine("Dati corretti");
                    SelectLanguage(user);
                    MainMenu(user);
                }
                else
                {
                    Console.WriteLine("LogIn Fattilto riprova");
                }
            }
            catch (Exception ex)
            {
                // Gestione delle eccezioni durante il login
                Console.WriteLine($"Errore durante il login: {ex.Message}");
            }
        }
     
        private void SelectLanguage(User user)
        {
            Console.Clear();
            Console.WriteLine("===== Selezione la lingua =====");
            Console.WriteLine("I. Italiano");
            Console.WriteLine("E. English");
            char check = Console.ReadKey().KeyChar;
            switch (check)
            {
                case 'I':
                    user.CultureInfo = CultureInfo.CreateSpecificCulture("it-IT");
                    break;
                case 'E':
                    user.CultureInfo = CultureInfo.CreateSpecificCulture("en-US");
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    SelectLanguage(user);
                    break;
            }
            Console.WriteLine("");
        }

        private void MainMenu(User user)
        {
            while (true)
            {
                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("1. Music Player");
                Console.WriteLine("2. Video Player");
                Console.WriteLine($"{MenuExitCommand}. Exit");
                Console.Write("Enter your choice: ");

                string mainMenuChoice = Console.ReadLine();


                switch (mainMenuChoice)
                {
                    case "1":
                        MusicPlayer(user);
                        break;
                    case "2":
                        VideoPlayer(user);
                        break;
                    case MenuExitCommand:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void MusicPlayer(User user)
        {
            while (true)
            {
                Console.WriteLine("=== Music Player Menu ===");
                Console.WriteLine("0. See All Songs");
                Console.WriteLine("1. Play Song");
                Console.WriteLine("2. Show Albums");
                Console.WriteLine("3. Show Playlists");
                Console.WriteLine("4. Next Song");
                Console.WriteLine("5. Previous Song");
                Console.WriteLine("6. Pause Song");
                Console.WriteLine("7. Play playlist");
                Console.WriteLine("8. Top 5 Rated Songs");
                Console.WriteLine("9. Top 5 Rated Albums");
                Console.WriteLine($"{MenuExitCommand}. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                // Verifica se l'utente ha selezionato l'opzione di uscita
                if (choice.Equals(MenuExitCommand, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                HandleMusicPlayerChoice(user, choice);
            }
        }

        private void HandleMusicPlayerChoice(User user, string choice)
        {
            switch (choice)
            {
                case "0":
                    Console.WriteLine(_mediaPlayer.SeeAllSong());
                    break;
                case "1":
                    Console.WriteLine("Enter song number:");
                    if (int.TryParse(Console.ReadLine(), out int songId))
                    {
                        Console.WriteLine(_mediaPlayer.PlaySongById(user, songId));
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid song number.");
                    }
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
                    Console.WriteLine("Enter playlist number: ");
                    if (int.TryParse(Console.ReadLine(), out int playlistId))
                    {
                        Console.WriteLine(_mediaPlayer.PlayPlaylist(user, playlistId));
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid song number.");
                    } 
                    break;
                case "8":
                    Console.WriteLine(_mediaPlayer.Top5Song());
                    break;
                case "9":
                    Console.WriteLine(_mediaPlayer.Top5Album());
                    break;
                case MenuExitCommand:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void VideoPlayer(User user)
        {
            while (true)
            {
                Console.WriteLine("=== Video Player Menu ===");
                Console.WriteLine("A. See All Movies");
                Console.WriteLine("B. Top 5 Most Viewed Movies");
                Console.WriteLine("C. Play Movie");
                Console.WriteLine("P. Pause Playback");
                Console.WriteLine($"{MenuExitCommand}. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice.Equals(MenuExitCommand, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                HandleVideoPlayerChoice(user, choice);
            }
        }

        private void HandleVideoPlayerChoice(User user, string choice)
        {
          
            switch (choice)
            {
                case "A":
                    Console.WriteLine("Here is the list of movies:");
                    Console.WriteLine(_movieMediaPlayer.SeeAllMovie());
                    Console.WriteLine("--------------------------------");
                    break;
                case "B":
                    Console.WriteLine("Top 5 movies of the service:");
                    Console.WriteLine(_movieMediaPlayer.Top5Movie());
                    Console.WriteLine("--------------------------------");
                    break;
                case "C":
                    Console.WriteLine("Enter the name of the movie to play:");
                    int movieId = Console.Read();
                    Console.WriteLine(_movieMediaPlayer.PlayMovie(user, movieId));
                    Console.WriteLine("Playback started");
                    break;
                case "P":
                    Console.WriteLine("Pause");
                    Console.WriteLine(_movieMediaPlayer.PauseMovie());
                    break;
                case MenuExitCommand:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void Exit()
        {
            Console.WriteLine("Thank you for using the application. Goodbye!");
            Environment.Exit(0);
        }
    }

}