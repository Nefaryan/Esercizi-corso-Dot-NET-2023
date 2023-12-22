using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class Setting
    {
        public int UserId { get; set; }
        public string Equalaizer { get; set; }
        public bool? IsPremium { get; set; }
        public int? NumberOfConnectedDevice { get; set; }
        public int? RemainigTime { get; set; }
        public int? PremiumType { get; set; }
        public TimeSpan? TotalUsageTime { get; set; }

        public virtual User User { get; set; }
    }
}
