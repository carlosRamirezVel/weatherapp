using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MyWeatherApp.Exceptions;
using MyWeatherApp.Extenstions;
using MyWeatherApp.Interfaces;
using MyWeatherApp.Models;
using Newtonsoft.Json;

namespace MyWeatherApp.Services
{
    public class WeatherAPIService : IWeatherService
    {
        const string APIKey = "282a87092dcc6b3851ce3116dbe58cd2";
        const string Endpoint = "https://api.openweathermap.org/data/2.5/forecast";
        private HttpClient _httpClient;

        public WeatherAPIService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<MyWeatherResult> GetWeatherByCityNameAsync(string cityName)
        {
            var url = $"{Endpoint}?q={cityName}&units=metric&appid={APIKey}";
            var apiResponse = await _httpClient.GetAsync(url);
            var response = new MyWeatherResult();

            if (apiResponse.IsSuccessStatusCode)
            {
                var jsonApi = await apiResponse.Content.ReadAsStringAsync();
                var apiObject = jsonApi.FromJson<WeatherAPIResponse>();
                response = apiObject.ToMyWeatherResult();
            }
            else
            {
                throw new WeatherAPIException((int)apiResponse.StatusCode);
            }

            return response;
        }
    }
}
