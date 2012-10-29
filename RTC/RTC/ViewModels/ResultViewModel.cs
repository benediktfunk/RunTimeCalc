using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using RTC.Messages;
using RTC.Models;
using RTC.Storage;

namespace RTC.ViewModels
{
    public class ResultViewModel : ViewModelBase, IHandle<ResultMessage>
    {
        private ObjectStorageHelper<List<CalculationResultViewModel>> _objectStorageHelper;
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public ResultViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService, eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _objectStorageHelper = new ObjectStorageHelper<List<CalculationResultViewModel>>(StorageType.Local);
        }

        public void Save()
        {
            var ds = new DataSource.DS();
            var items = ds.Initialize();

            var i = items.ToList();
            _objectStorageHelper.SaveAsync(i);
        }

        public void Handle(ResultMessage message)
        {
            
        }
    }
}