namespace RTC.Models
{
    public class KilometerPerHour
    {
        public KilometerPerHour() { }

        public KilometerPerHour(double kmh)
        {
            Value = kmh;
        }

        public double Value { get; set; }
    }
}