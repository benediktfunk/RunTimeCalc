using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using RTC.Messages;
using RTC.Models;
using RTC.Storage;
using Windows.UI.Popups;

namespace RTC.ViewModels
{
    public class ResultViewModel : ViewModelBase, IHandle<ResultMessage>
    {
        private readonly ObjectStorageHelper<List<CalculationResultViewModel>> _objectStorageHelper;
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public ResultViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService, eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _objectStorageHelper = new ObjectStorageHelper<List<CalculationResultViewModel>>(StorageType.Local);
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
            var dialog = new MessageDialog(string.Format("{0} KM/H --- {1} min/KM", message.KilometerPerHour.KmH, message.MinutePerKilometer.Kilometers));
            await dialog.ShowAsync();
        }
    }
}