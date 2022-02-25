using System;
using System.Collections.Generic;
using MyWeatherApp.Behaviours;
using MyWeatherApp.Interfaces;
using MyWeatherApp.Models;
using MyWeatherApp.ViewModels;
using Xamarin.Forms;

namespace MyWeatherApp.Pages
{
    public partial class ForecastPage : ContentPage
    {
        public ForecastPage(MyWeatherResult result)
        {
            InitializeComponent();
            var viewModel = new ForecastViewModel(Navigation);
            viewModel.UpdateResult(result);
            BindingContext = viewModel;

            //there is aproblem doing it through XAML
            var behaviour = new TextChangedToCommandBehaviour();
            behaviour.TextChangedCommand = viewModel.SearchTextCommand;
            searchbar.Behaviors.Add(behaviour);
        }
    }
}
