using Caliburn.Micro;

namespace RTC.ViewModels
{
    public class HubViewModel : Conductor<PivotItemViewModel>.Collection.OneActive
    {
        private INavigationService _navigationService;

        public HubViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Headline = "runTIMEcalculator";
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
    }
}