using System;
using Caliburn.Micro;
using RTC.Calculator;
using RTC.Common;
using RTC.Messages;
using System.Linq;
using RTC.Models;

namespace RTC.ViewModels
{
    public class PivotRunTimeCalculatorViewModel : PivotItemViewModel
    {
        private ICalculator _calculator;
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public PivotRunTimeCalculatorViewModel(INavigationService navigationService, IEventAggregator eventAggregator, string title) 
            : base(navigationService, eventAggregator, title)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            initializePivotRunTimeCalculatorViewModel();
        }

        public void CalculateRunTime()
        {
            _calculator = new Calculator.Calculator();

            var distance = new Distance(SelectedKilometer.Title, SelectedMeter.Title, SelectedCentimeter.Title);
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, SelectedHour.Title,
                                    SelectedMinute.Title, SelectedSecond.Title);
            
            var kmh = _calculator.CalculateKilometersPerHour(distance, date);
            var minKm = _calculator.CalculateMinutePerKilometer(kmh);
            if (kmh.Value <= 0.0 || minKm.Minutes <= 0) return;

            // Navigate to result page --- publish result message
            _navigationService.NavigateToViewModel<ResultItemDetailViewModel>();
            _eventAggregator.Publish(new ResultMessage {Distance = distance, Date = date, KilometerPerHour = kmh, MinutePerKilometer = minKm});
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

        private DistanceViewModel _selectedKilometer;
        public DistanceViewModel SelectedKilometer
        {
            get { return _selectedKilometer; }
            set
            {
                _selectedKilometer = value;
                NotifyOfPropertyChange(() => SelectedKilometer);
            }
        }

        private DistanceViewModel _selectedMeter;
        public DistanceViewModel SelectedMeter
        {
            get { return _selectedMeter; }
            set
            {
                _selectedMeter = value;
                NotifyOfPropertyChange(() => SelectedMeter);
            }
        }

        private DistanceViewModel _selectedCentimeter;
        public DistanceViewModel SelectedCentimeter
        {
            get { return _selectedCentimeter; }
            set
            {
                _selectedCentimeter = value;
                NotifyOfPropertyChange(() => SelectedCentimeter);
            }
        }

        private TimeViewModel _selectedHour;
        public TimeViewModel SelectedHour
        {
            get { return _selectedHour; }
            set
            {
                _selectedHour = value;
                NotifyOfPropertyChange(() => SelectedHour);
            }
        }

        private TimeViewModel _selectedMinute;
        public TimeViewModel SelectedMinute
        {
            get { return _selectedMinute; }
            set
            {
                _selectedMinute = value;
                NotifyOfPropertyChange(() => SelectedMinute);
            }
        }

        private TimeViewModel _selectedSecond;
        public TimeViewModel SelectedSecond
        {
            get { return _selectedSecond; }
            set
            {
                _selectedSecond = value;
                NotifyOfPropertyChange(() => SelectedSecond);
            }
        }

        private void initializePivotRunTimeCalculatorViewModel()
        {
            Hours = new BindableCollection<TimeViewModel>().CreateHours();
            Minutes = new BindableCollection<TimeViewModel>().CreateMinutes();
            Seconds = new BindableCollection<TimeViewModel>().CreateSeconds();
            Kilometers = new BindableCollection<DistanceViewModel>().CreateKilometers();
            Meters = new BindableCollection<DistanceViewModel>().CreateMeters();
            Centimeters = new BindableCollection<DistanceViewModel>().CreateCentimeters();

            SelectedKilometer = Kilometers.Single(s => s.Title == 0);
            SelectedMeter = Meters.Single(s => s.Title == 0);
            SelectedCentimeter = Centimeters.Single(s => s.Title == 0);
            SelectedHour = Hours.Single(s => s.Title == 0);
            SelectedMinute = Minutes.Single(s => s.Title == 0);
            SelectedSecond = Seconds.Single(s => s.Title == 0);
        }
    }
}