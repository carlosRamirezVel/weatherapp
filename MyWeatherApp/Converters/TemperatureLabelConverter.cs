using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyWeatherApp.Converters
{
    public class TemperatureLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            var label = $"{parameter}{value}°C";
            return label;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
