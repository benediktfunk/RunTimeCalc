using System;
using Caliburn.Micro;
using RTC.Models;

namespace RTC.DataSource
{
    public class DS
    {
        public IObservableCollection<ResultViewModel> Initialize()
        {
            var result = new BindableCollection<ResultViewModel>();
            for (var i = 0; i < 20; i++)
            {
                var item = new ResultViewModel("Result" + i, "Result Description " + i, DateTime.UtcNow.GetDateTimeFormats()[3], (decimal) 10.0, (decimal) 1.05);
                result.Add(item);
            }
            return result;
        }
    }
}