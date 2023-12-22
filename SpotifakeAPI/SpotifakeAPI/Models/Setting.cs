using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Setting
    {
        public int UserId { get; set; }
        public string Equalizer { get; set; }
        public bool? IsPremium { get; set; }
        public int? NumberOfConnectedDevices { get; set; }
        public int? RemainingTime { get; set; }
        public int? PremiumType { get; set; }
        public TimeSpan? TotalUsageTime { get; set; }

        public virtual User User { get; set; }
    }
}
