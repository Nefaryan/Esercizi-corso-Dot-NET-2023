using Spotifake.Entities;
using Spotifake.Model.Music;
using SpotifakeDB.Repository;
using SpotifakeLogic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spotifake
{
    public class UIClass
    {
        private readonly MediaPlayer _mediaPlayer;

        public UIClass(MediaPlayer mediaPlayer)
        {
            _mediaPlayer = mediaPlayer;
        }

        public void Run(User user)
        {
            char userInput;
            do
            {
                ShowMenu();
                userInput = GetValidInput();

                // Gestisci l'input dell'utente
                HandleInput(userInput,user);

            } while (userInput != 'E');
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Music Player Menu ===");
            Console.WriteLine("1. Play Song");
            Console.WriteLine("2. Play Album");
            Console.WriteLine("3. Play Playlist");
            Console.WriteLine("4. Next Song");
            Console.WriteLine("5. Previous Song");
            Console.WriteLine("6. Pause Song");
            Console.WriteLine("7. Stop Song");
            Console.WriteLine("8. Top Rating Songs");
            Console.WriteLine("E. Exit");
            Console.Write("Enter your choice: ");
        }

        private char GetValidInput()
        {
            char userInput;
            do
            {
                userInput = char.ToUpper(Console.ReadKey().KeyChar);
            } while (!IsValidInput(userInput));

            return userInput;
        }

        private bool IsValidInput(char input)
        {
            return input == '1' || input == '2' || input == '3' || input == '4' ||
                   input == '5' || input == '6' || input == '7' || input == '8' ||
                   input == 'E';
        }

        private void HandleInput(char userInput,User user)
        {
            switch (userInput)
            {
                case '1':
                    Console.Write("Enter song name: ");
                    string songName = Console.ReadLine();
                    Console.WriteLine(_mediaPlayer.PlaySong(songName));
                    break;

                case '2':
                    Console.Write("Enter album name: ");
                    string albumName = Console.ReadLine();
                    Console.WriteLine(_mediaPlayer.PlayAlbum(albumName));
                    break;

                case '3':
                    Console.Write("Enter playlist name: ");
                    string playlistName = Console.ReadLine();
                    Console.WriteLine(_mediaPlayer.PlayPlaylist(playlistName));
                    break;

                case '4':
                    Console.WriteLine(_mediaPlayer.NextSong(user));
                    break;

                case '5':
                    Console.WriteLine(_mediaPlayer.PreviousSong(user));
                    break;

                case '6':
                    Console.WriteLine(_mediaPlayer.PauseSong());
                    break;

                case '7':
                    Console.WriteLine(_mediaPlayer.StopSong());
                    break;

                case '8':
                    Console.WriteLine(_mediaPlayer.TopRatingSongs());
                    break;

                case 'E':
                    Console.WriteLine("Exiting the music player.");
                    break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}

