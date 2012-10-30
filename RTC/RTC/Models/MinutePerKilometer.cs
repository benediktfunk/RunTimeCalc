namespace RTC.Models
{
    public class MinutePerKilometer
    {
        public MinutePerKilometer() { }

        public MinutePerKilometer(int minutes, int seconds)
        {
            Minutes = minutes;
            Seconds = seconds;
        }

        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }
}