using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWeatherApp.CustomRenderers;
using MyWeatherApp.Exceptions;
using MyWeatherApp.Interfaces;
using MyWeatherApp.Pages;
using Xamarin.Forms;

namespace MyWeatherApp.ViewModels
{
    public class SearchViewModel : NavigationViewModel
    {
        private readonly IWeatherService _weatherService;
        private readonly IAlertMessageService _alertMessageService;
        private string _citySearched;
        private string _searchLabel;
        private bool _isSearchEnabled;

        public bool IsSearchEnabled
        {
            get => _isSearchEnabled;
            set => SetProperty(ref _isSearchEnabled, value);
        }

        public string CitySearched
        {
            get => _citySearched;
            set => SetProperty(ref _citySearched, value);
        }

        public string SearchLabel
        {
            get => _searchLabel;
            set => SetProperty(ref _searchLabel, value);
        }

        public ICommand SearchCommand { get; private set; }

        public SearchViewModel(INavigation navigation,
            IWeatherService weatherService,
            IAlertMessageService alertMessageService) : base(navigation)
        {
            _alertMessageService = alertMessageService;
            _weatherService = weatherService;
            IsSearchEnabled = true;
            Title = "Weather";
            CitySearched = "Cancun";
            SearchLabel = "Search";
            SearchCommand = new Command(async () => await OnSearchCommand());
        }

        private async Task OnSearchCommand()
        {
            try
            {
                IsSearchEnabled = false;
                SearchLabel = "Searching...";
                var result = await _weatherService.GetWeatherByCityNameAsync(CitySearched);
                await Navigation.PushAsync(new ForecastPage(result));
            }
            catch (WeatherAPIException wae)
            {
                await _alertMessageService.AlertAsync("Ops!", $"There was a problem connecting with Weather API, error code [{wae.HttpStatusCode}]", "OK");
            }
            catch (Exception)
            {
                await _alertMessageService.AlertAsync("Ops!", "There was a problem, please try again", "OK");
            }
            finally
            {
                IsSearchEnabled = true;
                SearchLabel = "Search";
            }
        }
    }
}
