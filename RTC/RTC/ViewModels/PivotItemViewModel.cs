using Caliburn.Micro;

namespace RTC.ViewModels
{
    public class PivotItemViewModel : Screen
    {
        public PivotItemViewModel(string title)
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