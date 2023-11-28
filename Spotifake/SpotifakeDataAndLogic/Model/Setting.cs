using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    public class Setting
    {
        bool _darkTheme;
        string _equalaizer;
        bool _isPremium;
        int _numberOfConnectedDevice;
        User _user;

        public Setting(bool darkTheme, string equalaizer, 
            bool isPremium, int numberOfDisp)
        {
            _darkTheme = darkTheme;
            _equalaizer = equalaizer;
            _isPremium = isPremium;
            _numberOfConnectedDevice = numberOfDisp;
        }

        public bool DarkTheme { get => _darkTheme; set => _darkTheme = value; }
        public string Equalaizer { get => _equalaizer; set => _equalaizer = value; }
        public bool IsPremium { get => _isPremium; set => _isPremium = value; }
        public int NumberOfDisp { get => _numberOfConnectedDevice; set => _numberOfConnectedDevice = value; }
        internal User User { get => _user; set => _user = value; }
    }
}
