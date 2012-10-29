using Caliburn.Micro;

namespace RTC.ViewModels
{
    public class PivotItemViewModel : ViewModelBase
    {
        public PivotItemViewModel(INavigationService navigationService, IEventAggregator eventAggregator, string title) 
            : base(navigationService, eventAggregator)
        {
            _title = title;
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
    }
}