using SpotifakeClasses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using SpotifakeDateAndLogic.Logic;
using SpotifakeDateAndLogic.LogicAndData;

namespace SpotifakeClasses
{
    public class Menu
    {
        public Menu() { }
        public static void StartMenu(User user,Database data) {
            Console.Clear();
            string menu = "╔═════════════════════════════════════════════╗" +
                        "\n║          Please select a language           ║" +
                        "\n║                  1.English                  ║" +
                        "\n║                  2.Italian                  ║" +
                        "\n╚═════════════════════════════════════════════╝\n";
            Console.WriteLine(menu);
            char check = Console.ReadKey().KeyChar;
            switch(check){
                case '1':
                    user.Culture = CultureInfo.CreateSpecificCulture("en-US"); Menu1(user, new MediaComponent(user), data);
                    break;
                case '2':
                    user.Culture = CultureInfo.CreateSpecificCulture("it-IT");Menu1(user, new MediaComponent(user), data);
                    break;
            }            

        }
        public static void Menu1(User user,MediaComponent media,Database data) {
            while (true)
            {
                if (user.Settings.RemainigTime == 0) 
                {
                    string menu = "╔═════════════════════════════════════════════╗" +
                                "\n║  Premi A per riprodurre una canzone casuale ║" +
                                "\n║  Premi E per uscire dal programma           ║" +
                                "\n╚═════════════════════════════════════════════╝\n";
                    Console.WriteLine(menu);

                }
                Console.WriteLine("");
                Console.WriteLine("Premi A per vedere le canzoni");
                Console.WriteLine("Premi B per vedere le playist");
                Console.WriteLine("Premi C per vedere le radio");
                Console.WriteLine("Premi E per uscire");
                string check = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                switch (check)
                {
                    case "A": data.ShowSongs(); Menu2(user, media, data); break;
                    case "B": data.ShowPlaylists(); Menu3(user, media, data); break;
                    case "C": data.ShowRadios(); Menu4(user, media, data); break;
                    case "E": Environment.Exit(0); break;
                }
            }
        }
        public static void Menu2(User user,MediaComponent media, Database datas) {
            while (true)
            {
                Console.WriteLine("Inserisci il numero della canzone da riprodurre o -1 per tornare indietro\n");
                int check = int.Parse(Console.ReadKey().KeyChar.ToString());
                if (check == -1) { Menu1(user, media, datas); }
                Song s = datas.SelectSong(check);
                media.Play(user, s);
                Menu5(user, media, datas);
            } 
        }

        public static void Menu3(User user,MediaComponent media, Database datas)
        {
            while (true)
            {
                Console.WriteLine("Inserisci il numero della Playlist da riprodurre o -1 per tornare indietro");
                int check = int.Parse(Console.ReadKey().KeyChar.ToString());
                if (check == -1) { Menu1(user, media, datas); }
                Playlist s = datas.SelectPlaylist(check);
                media.PlayPlaylist(s);
                Menu5(user, media, datas);
            }
        }

        public static void Menu4(User user,MediaComponent media, Database datas)
        {
            while (true)
            {
                Console.WriteLine("Inserisci il numero della Radio da riprodurre o  -1 per tornare indietro");
                int check = int.Parse(Console.ReadKey().KeyChar.ToString());
                if (check == -1) { Menu1(user, media, datas); }
                Radio r = datas.SelectRadio(check);
                media.PlayRadio(r,user);
                Menu5(user, media, datas);
            }
        }

        public static void Menu5(User user, MediaComponent media, Database data)
        {
            while (true)
            {
                Console.WriteLine("Inserisci F per passare alla prossima canzone");
                Console.WriteLine("Inserisci P per mettere in pausa");
                Console.WriteLine("Inserisci B per tornare alla canzone precedente");
                Console.WriteLine("Inserisci S per fermare la riproduzione");
                Console.WriteLine("Inserisci E per tornare al menu precedente");
                string check = Console.ReadKey().KeyChar.ToString();
                switch (check)
                {
                    case "F": media.Forward(); break;
                    case "P": media.Pause(); break;
                    case "B": media.Previous(); break;
                    case "S": media.Stop(); Menu1(user, media, data); break;
                    case "E": media.Stop(); return;
                }
            }
        }
    }
}
