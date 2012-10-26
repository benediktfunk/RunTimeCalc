using Caliburn.Micro;

namespace RTC.Common
{
    public static class Constants
    {
        public static readonly BindableCollection<int> Hours = new BindableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }; 
        public static readonly BindableCollection<int> Minutes = new BindableCollection<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};
        public static readonly BindableCollection<int> Seconds = new BindableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }; 
    }
}