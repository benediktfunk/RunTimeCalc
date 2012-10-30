using System;
using Caliburn.Micro;
using RTC.Models;

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
            double distance, 
            string duration,
            double kmh,
            string minkm)
        {
            _title = title;
            _description= desc;
            _date = date;
            _distance = distance;
            _duration = duration;
            _kilometerPerHour = kmh;
            _minutePerKilometer = minkm;
        }

        public ResultViewModel(
            string title,
            string desc,
            string date,
            double distance,
            string duration,
            double kmh,
            string minkm,
            ResultGroups group)
        {
            _title = title;
            _description = desc;
            _date = date;
            _distance = distance;
            _duration = duration;
            _kilometerPerHour = kmh;
            _minutePerKilometer = minkm;
            _groups = group;
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

        private double _distance;
        public double Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                NotifyOfPropertyChange(() => Distance);
            }
        }

        private string _duration;
        public string Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                NotifyOfPropertyChange(() => Duration);
            }
        }

        private double _kilometerPerHour;
        public double KilometerPerHour
        {
            get { return _kilometerPerHour; }
            set
            {
                _kilometerPerHour = value;
                NotifyOfPropertyChange(() => KilometerPerHour);
            }
        }

        private string _minutePerKilometer;
        public string MinutePerKilometer
        {
            get { return _minutePerKilometer; }
            set
            {
                _minutePerKilometer = value;
                NotifyOfPropertyChange(() => MinutePerKilometer);
            }
        }

        private ResultGroups _groups;
        public ResultGroups Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                NotifyOfPropertyChange(() => Groups);
            }
        }
    }
}