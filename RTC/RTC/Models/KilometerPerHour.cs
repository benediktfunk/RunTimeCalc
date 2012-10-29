namespace RTC.Models
{
    public class KilometerPerHour
    {
        public KilometerPerHour() { }

        public KilometerPerHour(double kmh)
        {
            KmH = kmh;
        }

        public KilometerPerHour(int kilometers, int hours)
        {
            Kilometer = kilometers;
            Hours = hours;
        }

        public double KmH { get; set; }
        public int Kilometer { get; set; }
        public int Hours { get; set; }
    }
}