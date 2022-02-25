using System;
using MyWeatherApp.Interfaces;
using MyWeatherApp.Pages;
using MyWeatherApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //register services
            DependencyService.RegisterSingleton<IWeatherService>(new WeatherAPIService());
            MainPage = new NavigationPage(new SearchPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
