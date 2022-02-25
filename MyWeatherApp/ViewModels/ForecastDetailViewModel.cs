using System;
using System.Windows.Input;
using MyWeatherApp.Interfaces;
using MyWeatherApp.Models;
using Xamarin.Forms;

namespace MyWeatherApp.ViewModels
{
    public class ForecastDetailViewModel : BaseViewModel
    {
        private readonly IOpenMapService _openMapService;
        private string _cityName;
        private double _temperature;
        private double _minTemperature;
        private double _maxTemperature;
        private string _main;//rain
        private string _icon;//rain
        private ForecastDetailParameter _item;
        public string CityName
        {
            get => _cityName;
            set => SetProperty(ref _cityName, value);
        }

        public double Temperature
        {
            get => _temperature;
            set => SetProperty(ref _temperature, value);
        }

        public double MinTemperature
        {
            get => _minTemperature;
            set => SetProperty(ref _minTemperature, value);
        }

        public double MaxTemperature
        {
            get => _maxTemperature;
            set => SetProperty(ref _maxTemperature, value);
        }

        public string Main
        {
            get => _main;
            set => SetProperty(ref _main, value);
        }

        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        public ICommand OpenMapCommand { get; private set; }

        public ForecastDetailViewModel(IOpenMapService openMapService, ForecastDetailParameter item)
        {
            _openMapService = openMapService;
            _item = item;
            Title = "Details";
            CityName = $"{item.City.Name}, {item.City.Country}";
            MinTemperature = item.Item.TempMin;
            MaxTemperature = item.Item.TempMax;
            Main = item.Item.Main;
            Temperature = item.Item.Temperature;
            Icon = item.Item.Icon;
            OpenMapCommand = new Command(OnOpenMapCommand);
        }

        private void OnOpenMapCommand()
        {
            _openMapService.OpenPlace(latitude: _item.City.Latitude,
                longitude: _item.City.Longitude,
                name:_item.City.Name);
        }
    }
}
