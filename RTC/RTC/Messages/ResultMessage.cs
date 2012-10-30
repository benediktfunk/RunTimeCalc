using System;
using RTC.Models;

namespace RTC.Messages
{
    public class ResultMessage
    {
        public Distance Distance { get; set; }
        public DateTime Date { get; set; }
        public MinutePerKilometer MinutePerKilometer { get; set; }
        public KilometerPerHour KilometerPerHour { get; set; }
    }
}