namespace RTC.Models
{
    public class MinutePerKilometer
    {
        public MinutePerKilometer() { }

        public MinutePerKilometer(int minutes, int kilometers)
        {
            Minutes = minutes;
            Kilometers = kilometers;
        }

        public int Minutes { get; set; }
        public int Kilometers { get; set; }
    }
}