using System;
using System.Collections.Generic;
using MyWeatherApp.Interfaces;
using MyWeatherApp.Models;
using MyWeatherApp.ViewModels;
using Xamarin.Forms;

namespace MyWeatherApp.Pages
{
    public partial class ForecastDetailPage : ContentPage
    {
        public ForecastDetailPage(ForecastDetailParameter item)
        {
            InitializeComponent();
            var openMapService = DependencyService.Resolve<IOpenMapService>();
            BindingContext = new ForecastDetailViewModel(openMapService, item);
        }
    }
}
