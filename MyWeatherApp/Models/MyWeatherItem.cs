using System;
namespace MyWeatherApp.Models
{
    public class MyWeatherItem
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
