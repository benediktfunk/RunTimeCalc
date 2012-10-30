using Caliburn.Micro;

namespace RTC.ViewModels
{
    public class ResultViewModel : PropertyChangedBase 
    {
        // serializable
        public ResultViewModel() { }

        public ResultViewModel(
            string title, 
            string desc, 
            string date, 
            decimal distance, 
            decimal duration)
        {
            _title = title;
            _description= desc;
            _date = date;
            _distance = distance;
            _duration = duration;
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }

        private decimal _distance;
        public decimal Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                NotifyOfPropertyChange(() => Distance);
            }
        }

        private decimal _duration;
        public decimal Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                NotifyOfPropertyChange(() => Duration);
            }
        }
    }
}