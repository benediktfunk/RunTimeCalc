using System;

namespace RTC.Models
{
    public class RoundResult
    {
        public RoundResult(int kilometer, TimeSpan time)
        {
            Kilometer = kilometer;
            Time = time;
        }

        public int Kilometer { get; set; }
        public TimeSpan Time { get; set; }
    }
}
