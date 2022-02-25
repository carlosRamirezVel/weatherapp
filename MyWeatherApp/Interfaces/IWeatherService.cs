using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWeatherApp.Models;

namespace MyWeatherApp.Interfaces
{
    public interface IWeatherService
    {
        Task<MyWeatherResult> GetWeatherByCityNameAsync(string cityName);
    }
}
