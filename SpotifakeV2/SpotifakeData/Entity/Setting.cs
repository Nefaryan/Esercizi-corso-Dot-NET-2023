
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.Entity
{
    public class Setting
    {
        
        string? _equalaizer;
        bool _isPremium;
        int _numberOfConnectedDevice;
        User? _user;
        private int _remainigTime;
        PremiumTypeEnum _premiumType;
        TimeSpan _totalUsageTime;

        public Setting(bool darkTheme, string equalaizer,
            bool isPremium, int numberOfDisp, PremiumTypeEnum type)
        {
            
            _equalaizer = equalaizer;
            _isPremium = isPremium;
            _numberOfConnectedDevice = numberOfDisp;
            switch (type)
            {
                case PremiumTypeEnum.FREE:
                    RemainigTime = 360000;//100 ore
                    break;
                case PremiumTypeEnum.PREMIUM:
                    RemainigTime = (int)3.6e+6;//1000 ore
                    break;
                case PremiumTypeEnum.GOLD:
                    RemainigTime = -1;//unlimited
                    break;
                default:
                    RemainigTime = 360000;
                    break;
            }
        }


        public string Equalaizer { get => _equalaizer; set => _equalaizer = value; }
        public bool IsPremium { get => _isPremium; set => _isPremium = value; }
        public int NumberOfConnectedDevice { get => _numberOfConnectedDevice; set => _numberOfConnectedDevice = value; }
        public User User { get => _user; set => _user = value; }
        public int RemainigTime { get => _remainigTime; set => _remainigTime = value; }
        public PremiumTypeEnum PremiumType { get => _premiumType; set => _premiumType = value; }
        public TimeSpan TotalUsageTime { get => _totalUsageTime; set => _totalUsageTime = value; }
    }
}
