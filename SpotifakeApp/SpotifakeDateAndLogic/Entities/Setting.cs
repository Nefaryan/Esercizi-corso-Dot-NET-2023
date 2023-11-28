using SpotifakeDateAndLogic;
using System;

namespace SpotifakeClasses.Entities
{
    public class Setting
    {
        private User _user;
        private bool _darkTheme;
        private string _equalizer;
        public PremiumType PremiumType { get; set; }
        private int _nOfDevices;
        private int _remainigTime;

        public Setting()
        {
                _user = new User();
        }
        public Setting(User user) {
            _user = user;
            _darkTheme= false;
            _equalizer = "default";
            _nOfDevices=0;
        }
        public Setting(bool darkTheme, string equalizer, PremiumType type, int nOfDevices)
        {
           
            _darkTheme = darkTheme;
            _equalizer = equalizer;
            switch (type)
            {
                case PremiumType.FREE:
                    RemainigTime = 360000;//100 ore
                    break;
                case PremiumType.PREMIUM:
                    RemainigTime = (int)3.6e+6;//1000 ore
                    break;
                case PremiumType.GOLD:
                    RemainigTime = -1;//unlimited
                    break;
                default:
                    RemainigTime = 360000;
                    break;
            }
            _nOfDevices = nOfDevices;
        }

        public bool DarkTheme { get => _darkTheme; set => _darkTheme = value; }
        public string Equalizer { get => _equalizer; private set => _equalizer = value; }
    
        public int NOfDevices { get => _nOfDevices; private set => _nOfDevices = value; }
        public int RemainigTime { get => _remainigTime; set => _remainigTime = value; }

        public void AddDevice() {
            _nOfDevices++;
        }
        public void RemoveDevice() { 
            _nOfDevices--;
        }

    }
}