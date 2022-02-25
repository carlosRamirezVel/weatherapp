using System;
namespace MyWeatherApp.Exceptions
{
    public class WeatherAPIException : Exception
    {
        public int HttpStatusCode { get; private set; }

        public WeatherAPIException(int httpStatus)
        {
            HttpStatusCode = httpStatus;
        }
    }
}
