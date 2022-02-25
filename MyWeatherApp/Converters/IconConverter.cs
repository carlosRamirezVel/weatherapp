using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyWeatherApp.Converters
{
    /// <summary>
    /// https://openweathermap.org/weather-conditions#Weather-Condition-Codes-2
    /// </summary>
    public class IconConverter : IValueConverter
    {
        const string Source = "https://openweathermap.org/img/wn/";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var url = $"{Source}{value}@2x.png";
            return ImageSource.FromUri(new Uri(url));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
