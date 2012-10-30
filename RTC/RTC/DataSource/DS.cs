using System;
using Caliburn.Micro;
using RTC.ViewModels;

namespace RTC.DataSource
{
    public class DS
    {
        public IObservableCollection<ResultViewModel> Initialize()
        {
            var result = new BindableCollection<ResultViewModel>();
            for (var i = 0; i < 20; i++)
            {
                var item = new ResultViewModel("Laufen " + i, "Laufen war anstrengend " + i, DateTime.UtcNow.GetDateTimeFormats()[3], (decimal)10.0, (decimal)1.05);
                result.Add(item);
            }
            return result;
        }
    }
}