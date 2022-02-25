using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyWeatherApp.Converters
{
    public class DateFormatConverter : IValueConverter
    {
        const string DefaultDateFormat = "MM/dd/yy";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTimeOffset)value;
            string dateFormat = string.Empty;

            if (parameter != null)
            {
                var format = (string)parameter;
                dateFormat = date.ToString(format);
            }
            else
            {
                dateFormat = date.ToString(DefaultDateFormat);
            }

            return dateFormat;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
