﻿using System.Collections.Generic;
using Caliburn.Micro;
using RTC.Storage;
using Windows.UI.Xaml.Data;

namespace RTC.ViewModels
{
    public class HubViewModel : Conductor<PivotItemViewModel>.Collection.OneActive
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        private ObjectStorageHelper<List<ResultViewModel>> _objectStorageHelper; 

        public HubViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            Headline = "runTIME calculator";
            ResultItems = new BindableCollection<ResultViewModel>();
            initialize();
        }

        private async void initialize()
        {
            _objectStorageHelper = new ObjectStorageHelper<List<ResultViewModel>>(StorageType.Local);
            var storage = await _objectStorageHelper.LoadAsync();
            if (storage == null)
                return;

            foreach (var item in storage)
                ResultItems.Add(item);
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            Items.Add(new PivotRunTimeCalculatorViewModel(_navigationService, _eventAggregator, "Laufzeit"));
            Items.Add(new PivotInterimsCalculatorViewModel(_navigationService, _eventAggregator, "Zwischenzeit"));
            ActivateItem(Items[0]);
        }

        

        private string _headline;
        public string Headline
        {
            get { return _headline; }
            set
            {
                _headline = value;
                NotifyOfPropertyChange();
            }
        }

        private string _helloText;
        public string HelloText
        {
            get { return _helloText; }
            set 
            { 
                _helloText = value;
                NotifyOfPropertyChange();
            }
        }

        private IObservableCollection<ResultViewModel> _resultItems;
        public IObservableCollection<ResultViewModel> ResultItems
        {
            get { return _resultItems; }
            set
            {
                _resultItems = value;
                NotifyOfPropertyChange(() => ResultItems);
            }
        }
    }
}