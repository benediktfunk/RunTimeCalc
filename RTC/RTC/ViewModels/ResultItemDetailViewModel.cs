using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using RTC.Messages;
using RTC.Models;
using RTC.Storage;
using Windows.ApplicationModel.DataTransfer;

namespace RTC.ViewModels
{
    public class ResultItemDetailViewModel : ViewModelBase, IHandle<ResultMessage>, ISupportSharing
    {
        private readonly ObjectStorageHelper<List<ResultViewModel>> _objectStorageHelper;
        private List<ResultViewModel> _storageResultItems;
        private ResultViewModel _currentResult;
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public ResultItemDetailViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService, eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _objectStorageHelper = new ObjectStorageHelper<List<ResultViewModel>>(StorageType.Local);
            
            loadStorageData();
            PageTitle = "Ergebnis";
        }


        private async void loadStorageData()
        {
            _storageResultItems = new List<ResultViewModel>();
            _storageResultItems = await _objectStorageHelper.LoadAsync();
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

        public async void Save()
        {
            _currentResult = new ResultViewModel(Title, "", DateTime.UtcNow.GetDateTimeFormats()[3], Distance, Time.ToString(), KilometerPerHour, MinutePerKilometer, ResultGroups.Runtime);

            if(_storageResultItems == null)
                _storageResultItems = new List<ResultViewModel>();

            _storageResultItems.Add(_currentResult);
            _storageResultItems.OrderByDescending(s => s.Date);
            await _objectStorageHelper.SaveAsync(_storageResultItems);

            _navigationService.GoBack();
        }

        public async void Handle(ResultMessage message)
        {
            if (message == null) return;
            Distance = message.Distance.GetTotalMeters();
            Time = message.Date.TimeOfDay;
            KilometerPerHour = message.KilometerPerHour.Value;
            MinutePerKilometer = string.Format("{0}:{1}", message.MinutePerKilometer.Minutes, message.MinutePerKilometer.Seconds);
            Title = String.Format("Laufen - {0} m", Distance);
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

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
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