using System;
using RTC.Models;

namespace RTC.Calculator
{
    public interface ICalculator
    {
        KilometerPerHour CalculateKilometersPerHour(Tuple<int, int, int> distance, Tuple<int, int, int> time);
        MinutePerKilometer CalculateMinutePerKilometer(KilometerPerHour kmh);
    }
}