using SpotifakeDataAndLogic;
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
        private int _remainigTime;
        PremiumType PremiumType;

        public Setting(bool darkTheme, string equalaizer, 
            bool isPremium, int numberOfDisp,PremiumType type)
        {
            _darkTheme = darkTheme;
            _equalaizer = equalaizer;
            _isPremium = isPremium;
            _numberOfConnectedDevice = numberOfDisp;
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
        }

        public bool DarkTheme { get => _darkTheme; set => _darkTheme = value; }
        public string Equalaizer { get => _equalaizer; set => _equalaizer = value; }
        public bool IsPremium { get => _isPremium; set => _isPremium = value; }
        public int NumberOfDisp { get => _numberOfConnectedDevice; set => _numberOfConnectedDevice = value; }
        internal User User { get => _user; set => _user = value; }
        public int RemainigTime { get => _remainigTime; set => _remainigTime = value; }
        public PremiumType PremiumType1 { get => PremiumType; set => PremiumType = value; }
    }
}
