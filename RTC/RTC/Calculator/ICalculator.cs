using System;
using RTC.Models;

namespace RTC.Calculator
{
    public interface ICalculator
    {
        KilometerPerHour CalculateKilometersPerHour(Distance distance, DateTime time);
        MinutePerKilometer CalculateMinutePerKilometer(KilometerPerHour kmh);
    }
}