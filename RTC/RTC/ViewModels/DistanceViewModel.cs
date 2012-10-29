using Caliburn.Micro;

namespace RTC.ViewModels
{
    public class DistanceViewModel : PropertyChangedBase
    {
        public DistanceViewModel(int title)
        {
            _title = title;
        }

        private int _title;
        public int Title
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