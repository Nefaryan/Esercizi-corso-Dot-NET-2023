using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeBusinessLogic
{
    public class UserUI
    {

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("===== Selezione la lingua =====");
            Console.WriteLine("I. Italiano");
            Console.WriteLine("E. Inglese");
        }

        public void LogIn()
        {
            Console.Clear();
            Console.WriteLine("=== Esegui il LogIn ===");
            Console.WriteLine("Inserisci il tuo username: ");
            Console.WriteLine("Inserisci la password ");

        }

        private void ShowMenu()
        {
            Console.WriteLine("=== Music Player Menu ===");
            Console.WriteLine("0. Vedi tutti i brani");
            Console.WriteLine("1. Play Song");
            Console.WriteLine("2. Play Album");
            Console.WriteLine("3. Play Playlist");
            Console.WriteLine("4. Next Song");
            Console.WriteLine("5. Previous Song");
            Console.WriteLine("6. Pause Song");
            Console.WriteLine("7. Stop Song");
            Console.WriteLine("8. Top 5 Rating Songs");
            Console.WriteLine("9. Top 5 Rating Album");
            Console.WriteLine("X. Exit");
            Console.Write("Enter your choice: ");
        }
    }
}
