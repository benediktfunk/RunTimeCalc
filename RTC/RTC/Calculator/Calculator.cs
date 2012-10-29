using System;
using RTC.Models;

namespace RTC.Calculator
{
    public class Calculator : ICalculator
    {
        public KilometerPerHour CalculateKilometersPerHour(Tuple<int, int, int> distance, Tuple<int, int, int> time)
        {
            if (distance == null) return null;
            if (time == null) return null;

            var hoursInSeconds = time.Item1 * 3600;
            var minutesInSeconds = time.Item2 * 60;
            var seconds = time.Item3;

            var timesum = hoursInSeconds + minutesInSeconds + seconds;

            var kilometersInMeters = distance.Item1 * 1000;
            var meters = distance.Item2;
            var centimetersInMeters = distance.Item3 * 0.01;

            var distancesum = kilometersInMeters + meters + centimetersInMeters;
            var sum = Math.Round((distancesum/timesum)*3.6, 2);

            return new KilometerPerHour(sum);
        }

        public MinutePerKilometer CalculateMinutePerKilometer(KilometerPerHour kmh)
        {
            if (kmh == null) return null;
            var minkm = Math.Round((3600/kmh.KmH)/60, 2);

            var a = minkm.ToString().Split('.');
            if (a.Length <= 0) return null;

            var minutes = Convert.ToInt32(a[0]);
            var seconds = Math.Round(Convert.ToDouble(a[1])*0.6);

            return new MinutePerKilometer(minutes, Convert.ToInt32(seconds));
        }
    }
}