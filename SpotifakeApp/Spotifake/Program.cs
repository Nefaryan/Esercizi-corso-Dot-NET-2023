using SpotifakeClasses;
using SpotifakeClasses.Entities;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Spotifake
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
            Setting s = new Setting(false, "defauly", SpotifakeDateAndLogic.PremiumType.GOLD, 1);
            User u1 = new User("Giuseppe", "Roberti", "26-11-1995", "Nef", "Nefpass",s); 

            Menu.StartMenu(u1);
        }
    }
}
