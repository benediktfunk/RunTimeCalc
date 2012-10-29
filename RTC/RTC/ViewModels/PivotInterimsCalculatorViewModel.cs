using Caliburn.Micro;

namespace RTC.ViewModels
{
    public class PivotInterimsCalculatorViewModel : PivotItemViewModel
    {
        private readonly INavigationService _navigationService;

        public PivotInterimsCalculatorViewModel(INavigationService navigationService, IEventAggregator eventAggregator, string title)
            : base(navigationService, eventAggregator, title)
        {
            _navigationService = navigationService;
        }
    }
}