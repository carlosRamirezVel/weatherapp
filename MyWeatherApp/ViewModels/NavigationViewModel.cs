using System;
using Xamarin.Forms;

namespace MyWeatherApp.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        public readonly INavigation Navigation;

        public NavigationViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
    }
}
