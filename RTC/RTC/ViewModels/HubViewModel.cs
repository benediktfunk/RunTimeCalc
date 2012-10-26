using Caliburn.Micro;
using RTC.DataSource;
using RTC.Models;

namespace RTC.ViewModels
{
    public class HubViewModel : Conductor<PivotItemViewModel>.Collection.OneActive
    {
        private INavigationService _navigationService;

        public HubViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            var ds = new DS();
            Headline = "runTIME calculator";
            ResultItems = new BindableCollection<ResultViewModel>();
            ResultItems = ds.Initialize();
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            Items.Add(new PivotRunTimeCalculatorViewModel("Laufzeit"));
            Items.Add(new PivotInterimsCalculatorViewModel("Zwischenzeit"));

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