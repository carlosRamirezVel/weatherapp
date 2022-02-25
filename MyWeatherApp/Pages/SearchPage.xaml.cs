using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWeatherApp.Interfaces;
using MyWeatherApp.ViewModels;
using Xamarin.Forms;

namespace MyWeatherApp.Pages
{
    public partial class SearchPage : ContentPage, IAlertMessageService
    {
        public SearchPage()
        {
            InitializeComponent();
            var weatherService = DependencyService.Resolve<IWeatherService>();
            BindingContext = new SearchViewModel(Navigation, weatherService, this);
        }

        public async Task AlertAsync(string title, string message, string cancel)
        {
            await DisplayAlert(title, message, cancel);
        }
    }
}
