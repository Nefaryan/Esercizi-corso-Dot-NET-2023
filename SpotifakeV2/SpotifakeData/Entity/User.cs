using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SpotifakeData.Entity
{
    public class User : Person
    {
        int _Id;
        string _username;
        string _password;
        List<Playlist> _playlist;
        Setting _setting;
        CultureInfo _cultureInfo;
        
        public int Id { get => _Id; set => _Id = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public List<Playlist> Playlist { get => _playlist; set => _playlist = value; }
        public Setting Setting { get => _setting; set => _setting = value; }
        public CultureInfo CultureInfo { get => _cultureInfo; set => _cultureInfo = value; }
    }
}
