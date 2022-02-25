using System;
using System.Collections.Generic;
using System.Linq;
using MyWeatherApp.Models;

namespace MyWeatherApp.Extenstions
{
    public static class APIModelExtensions
    {
        public static MyWeatherResult ToMyWeatherResult(this WeatherAPIResponse apiObject)
        {
            var response = new MyWeatherResult();
            response.City = new MyCity()
            {
                Name = apiObject.City.Name,
                Latitude = apiObject.City.Coord.Lat,
                Longitude = apiObject.City.Coord.Lon,
                Country = apiObject.City.Country,
                Population = apiObject.City.Population
            };

            response.Items = new List<MyWeatherItem>();

            foreach (var item in apiObject.List)
            {
                var weather = item.Weather.FirstOrDefault();
                response.Items.Add(new MyWeatherItem()
                {
                    Main = weather.Main,
                    Description = weather.Description,
                    Icon = weather.Icon,
                    Temperature = item.Main.Temp,
                    FeelsLike = item.Main.FeelsLike,
                    TempMin = item.Main.TempMin,
                    TempMax = item.Main.TempMax,
                    Pressure = item.Main.Pressure,
                    Humidity = item.Main.Humidity,
                    Date = item.DtTxt
                });
            }

            return response;
        }
    }
}
