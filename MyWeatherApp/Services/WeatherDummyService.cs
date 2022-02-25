using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWeatherApp.Interfaces;
using MyWeatherApp.Models;

namespace MyWeatherApp.Services
{
    public class WeatherDummyService : IWeatherService
    {
        public async Task<MyWeatherResult> GetWeatherByCityNameAsync(string cityName)
        {
            var items = new List<MyWeatherItem>();
            for (var i = 0; i<10; i++)
            {
                items.Add(new MyWeatherItem()
                {
                    //Title = $"MyWeatherItem {i}",
                    //Detail = $"MyWeatherItem Detail {i}"
                });
            }
            await Task.Delay(TimeSpan.FromSeconds(1.2));
            return new MyWeatherResult() { Items = new List<MyWeatherItem>() };
        }
    }
}
