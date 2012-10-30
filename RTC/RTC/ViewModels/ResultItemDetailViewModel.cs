using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using RTC.Messages;
using RTC.Storage;
using Windows.ApplicationModel.DataTransfer;

namespace RTC.ViewModels
{
    public class ResultItemDetailViewModel : ViewModelBase, IHandle<ResultMessage>, ISupportSharing
    {
        private readonly ObjectStorageHelper<List<ResultViewModel>> _objectStorageHelper;
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public ResultItemDetailViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService, eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _objectStorageHelper = new ObjectStorageHelper<List<ResultViewModel>>(StorageType.Local);
            PageTitle = "Ergebnis";
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            _eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            _eventAggregator.Unsubscribe(this);
        }

        public void Save()
        {
            var ds = new DataSource.DS();
            var items = ds.Initialize();

            var i = items.ToList();
            _objectStorageHelper.SaveAsync(i);
        }

        public async void Handle(ResultMessage message)
        {
            if (message == null) return;
            Distance = message.Distance.GetTotalMeters();
            Time = message.Date.TimeOfDay;
            KilometerPerHour = message.KilometerPerHour.Value;
            MinutePerKilometer = string.Format("{0}:{1}", message.MinutePerKilometer.Minutes, message.MinutePerKilometer.Seconds);
        }

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                NotifyOfPropertyChange(() => PageTitle);
            }
        }

        private double _distance;
        public double Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                NotifyOfPropertyChange(() => Distance);
            }
        }

        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                NotifyOfPropertyChange(() => Time);
            }
        }

        private double _kilometerPerHour;
        public double KilometerPerHour
        {
            get { return _kilometerPerHour; }
            set
            {
                _kilometerPerHour = value;
                NotifyOfPropertyChange(() => KilometerPerHour);
            }
        }

        private string _minutePerKilometer;
        public string MinutePerKilometer
        {
            get { return _minutePerKilometer; }
            set
            {
                _minutePerKilometer = value;
                NotifyOfPropertyChange(() => MinutePerKilometer);
            }
        }

        public void OnShareRequested(DataRequest dataRequest)
        {
            DataPackage requestData = dataRequest.Data;
            requestData.Properties.Title = "";
            requestData.Properties.Description = ""; 
            requestData.SetText("Hallo");
        }

        public void Share()
        {
            DataTransferManager.ShowShareUI();
        }

        public void New()
        {
            GoBack();
        }
    }
}