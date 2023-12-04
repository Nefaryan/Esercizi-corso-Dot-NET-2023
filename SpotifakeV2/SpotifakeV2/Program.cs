using SpotifakeService.Service;
using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using SpotifakeData.Entity;
using SpotifakeService;

namespace SpotifakePresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            User user = new User();
            user.Username = "username";
            user.Password = "password";

            UserUI ui = new UserUI();
            ui.LogIn();
          
        }
    }
 }

