namespace RTC.Models
{
    public class NavigationParameter
    {
        public NavigationParameter(string title)
        {
            Value = title;
        }

        public string Value { get; set; } 
    }
}