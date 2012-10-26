using Caliburn.Micro;

namespace RTC.Models
{
    public class TimeViewModel : PropertyChangedBase 
    {
        public TimeViewModel(int title)
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