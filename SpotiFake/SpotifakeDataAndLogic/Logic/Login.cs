using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeDataAndLogic.Logic
{
    public class Login
    {
        public static bool LogIn (string username, string password)
        {
            if( username == "user" && password == "user" )
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
