using Caliburn.Micro;
using RTC.DataSource;
using RTC.Messages;
using RTC.Models;

namespace RTC.ViewModels
{
    public class HubViewModel : Conductor<PivotItemViewModel>.Collection.OneActive
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public HubViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            var ds = new DS();
            Headline = "runTIME calculator";
            ResultItems = new BindableCollection<CalculationResultViewModel>();
            ResultItems = ds.Initialize();
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

        private IObservableCollection<CalculationResultViewModel> _resultItems;
        public IObservableCollection<CalculationResultViewModel> ResultItems
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