using System;
using RTC.Models;

namespace RTC.Calculator
{
    public class Calculator : ICalculator
    {
        public KilometerPerHour CalculateKilometersPerHour(Distance distance, DateTime time)
        {
            if (distance == null) return new KilometerPerHour(0.0);
            
            var timeForCalculation = time.TimeOfDay.TotalSeconds;
            var distanceForCalculation = distance.GetTotalMeters();

            var sum =  Math.Round((distanceForCalculation/timeForCalculation)*3.6, 2);
            return sum <= 0 ? new KilometerPerHour(0.0) : new KilometerPerHour(sum);
        }

        public MinutePerKilometer CalculateMinutePerKilometer(KilometerPerHour kmh)
        {
            if (kmh.Value <= 0.0) return new MinutePerKilometer(0, 0);
           
            var minkm = Math.Round((3600/kmh.Value)/60, 2);
            if (minkm <= 0) return new MinutePerKilometer(0, 0);

            var a = minkm.ToString().Split('.');
            if (a.Length <= 0) return new MinutePerKilometer(0, 0);

            var minutes = Convert.ToInt32(a[0]);
            var seconds = 0.0;
            if(a.Length > 1)
                seconds = Math.Round(Convert.ToDouble(a[1]) * 0.6);
            return new MinutePerKilometer(minutes, Convert.ToInt32(seconds));
        }
    }
}