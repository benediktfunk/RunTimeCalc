using Caliburn.Micro;
using RTC.Common;
using RTC.Models;

namespace RTC.ViewModels
{
    public class PivotRunTimeCalculatorViewModel : PivotItemViewModel
    {
        public PivotRunTimeCalculatorViewModel(string title) 
            : base(title)
        {
            Distance = "0.00";
            Hours = new BindableCollection<TimeViewModel>().CreateHours();
            Minutes = new BindableCollection<TimeViewModel>().CreateMinutes();
            Seconds = new BindableCollection<TimeViewModel>().CreateSeconds();
            Kilometers = new BindableCollection<DistanceViewModel>().CreateKilometers();
            Meters = new BindableCollection<DistanceViewModel>().CreateMeters();
            Centimeters = new BindableCollection<DistanceViewModel>().CreateCentimeters();
        }

        public async void CalculateRunTime()
        {
           
        }

        private string _distance;
        public string Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                NotifyOfPropertyChange(() => Distance);
            }
        }

        private IObservableCollection<TimeViewModel> _hours;
        public IObservableCollection<TimeViewModel> Hours
        {
            get { return _hours; }
            set
            {
                _hours = value;
                NotifyOfPropertyChange(() => Hours);
            }
        }

        private IObservableCollection<TimeViewModel> _minutes;
        public IObservableCollection<TimeViewModel> Minutes
        {
            get { return _minutes; }
            set
            {
                _minutes = value;
                NotifyOfPropertyChange(() => Minutes);
            }
        }

        private IObservableCollection<TimeViewModel> _seconds;
        public IObservableCollection<TimeViewModel> Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value;
                NotifyOfPropertyChange(() => Seconds);
            }
        }

        private IObservableCollection<DistanceViewModel> _kilometers;
        public IObservableCollection<DistanceViewModel> Kilometers
        {
            get { return _kilometers; }
            set
            {
                _kilometers = value;
                NotifyOfPropertyChange(() => Kilometers);
            }
        }

        private IObservableCollection<DistanceViewModel> _meters;
        public IObservableCollection<DistanceViewModel> Meters
        {
            get { return _meters; }
            set
            {
                _meters = value;
                NotifyOfPropertyChange(() => Meters);
            }
        }

        private IObservableCollection<DistanceViewModel> _centimeters;
        public IObservableCollection<DistanceViewModel> Centimeters
        {
            get { return _centimeters; }
            set
            {
                _centimeters = value;
                NotifyOfPropertyChange(() => Centimeters);
            }
        }
    }
}