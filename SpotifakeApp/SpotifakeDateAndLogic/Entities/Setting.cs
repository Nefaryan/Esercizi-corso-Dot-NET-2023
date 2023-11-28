using System;

namespace SpotifakeClasses.Entities
{
    public class Setting
    {
        private User _user;
        private bool _darkTheme;
        private string _equalizer;
        private bool _isPremium;
        private bool _isGold;
        private int _nOfDevices;

        public Setting()
        {
                _user = new User();
        }
        public Setting(User user) {
            _user = user;
            _darkTheme= false;
            _equalizer = "default";
            _isPremium= false;
            _isGold= false;
            _nOfDevices=0;
        }
        public Setting(User user, bool darkTheme, string equalizer, bool isPremium, int nOfDevices)
        {
            _user = user;
            _darkTheme = darkTheme;
            _equalizer = equalizer;
            _isPremium = isPremium;
            _nOfDevices = nOfDevices;
        }

        public bool DarkTheme { get => _darkTheme; set => _darkTheme = value; }
        public string Equalizer { get => _equalizer; private set => _equalizer = value; }
        public bool IsPremium { get => _isPremium; private set => _isPremium = value; }
        public int NOfDevices { get => _nOfDevices; private set => _nOfDevices = value; }
        public bool IsGold { get => _isGold; set => _isGold = value; }

        public void AddDevice() {
            _nOfDevices++;
        }
        public void RemoveDevice() { 
            _nOfDevices--;
        }
        public void BuyPremium()
        {
            Console.WriteLine("Paga");
            _isPremium = true;
        }
    }
}