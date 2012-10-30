namespace RTC.Models
{
    public class Distance
    {
        public Distance(int kilometers, int meters, int centimeters)
        {
            Kilometers = kilometers;
            Meters = meters;
            Centimeters = centimeters;
        }

        public int Kilometers { get; set; }
        public int Meters { get; set; }
        public int Centimeters { get; set; }

        public double GetTotalMeters()
        {
            return Kilometers*1000 + Meters + Centimeters*0.01;
        }
    }
}