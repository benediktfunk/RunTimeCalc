using Caliburn.Micro;
using RTC.Models;

namespace RTC.Common
{
    public static class BindableCollectionExtensions
    {
        public static IObservableCollection<TimeViewModel> CreateHours(this IObservableCollection<TimeViewModel> items)
        {
            return createTicks(24);
        }

        public static IObservableCollection<TimeViewModel> CreateMinutes(this IObservableCollection<TimeViewModel> items)
        {
            return createTicks(60);
        }

        public static IObservableCollection<TimeViewModel> CreateSeconds(this IObservableCollection<TimeViewModel> items)
        {
            return createTicks(60);
        }

        public static IObservableCollection<DistanceViewModel> CreateKilometers(this IObservableCollection<DistanceViewModel> items)
        {
            return createPoints(1, 100, 1);
        }

        public static IObservableCollection<DistanceViewModel> CreateMeters(this IObservableCollection<DistanceViewModel> items)
        {
            return createPoints(100, 1000, 100);
        }

        public static IObservableCollection<DistanceViewModel> CreateCentimeters(this IObservableCollection<DistanceViewModel> items)
        {
            return createPoints(10, 100, 10);
        }

        private static IObservableCollection<TimeViewModel> createTicks(int count)
        {
            if (count <= 0) return null;
            var collection = new BindableCollection<TimeViewModel>();
            for (var i = 0; i < count; i++)
                collection.Add(new TimeViewModel(i));
            return collection.Count > 0 ? collection : null;
        }

        private static IObservableCollection<DistanceViewModel> createPoints(int begin, int end, int step)
        {
            if (end <= 0) return null;
            var collection = new BindableCollection<DistanceViewModel>();
            for (var i = begin; i < end; i = i + step)
                collection.Add(new DistanceViewModel(i));
            return collection.Count > 0 ? collection : null;
        }
    }
}