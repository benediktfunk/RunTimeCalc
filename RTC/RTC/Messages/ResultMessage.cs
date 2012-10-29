using RTC.Models;

namespace RTC.Messages
{
    public class ResultMessage
    {
        public MinutePerKilometer MinutePerKilometer { get; set; }
        public KilometerPerHour KilometerPerHour { get; set; }
    }
}