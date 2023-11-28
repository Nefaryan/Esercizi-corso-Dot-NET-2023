using SpotifakeClasses;
using SpotifakeClasses.Entities;
using SpotifakeDateAndLogic.Logic;
using SpotifakeDateAndLogic.LogicAndData;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Spotifake
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
            Setting s = new Setting(false, "defauly", SpotifakeDateAndLogic.PremiumType.GOLD, 1);
            User u1 = new User("Giuseppe", "Roberti", "26-11-1995", "Nef", "Nefpass",s);
            Database database = new Database();

            MediaComponent media = new MediaComponent();
            Menu.StartMenu(u1, database);
        }
    }
}
