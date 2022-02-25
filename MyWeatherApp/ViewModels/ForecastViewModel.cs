using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWeatherApp.Extensions;
using MyWeatherApp.Models;
using MyWeatherApp.Pages;
using Xamarin.Forms;

namespace MyWeatherApp.ViewModels
{
    public class ForecastViewModel : NavigationViewModel
    {
        private MyCity _currentCity;
        private MyWeatherItem _selectedItem;
        private string _searchText;
        private IList<MyWeatherItem> _currentItems;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                if (string.IsNullOrEmpty(_searchText))
                {
                    OnSearchCommand();
                }
            }
        }

        public ObservableCollection<MyWeatherItem> Items { get; private set; }
        public ICommand SelectedItemCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand SearchTextCommand { get; private set; }
        public ICommand OrderByDateCommand { get; private set; }

        public MyWeatherItem SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public ObservableCollection<ICustomSegmentItem> SegmentItems { get; private set; }

        public ForecastViewModel(INavigation navigation) : base(navigation)
        {
            _currentItems = new List<MyWeatherItem>();

            Title = "Weather Details";
            Items = new ObservableCollection<MyWeatherItem>();
            SearchCommand = new Command(OnSearchCommand);
            OrderByDateCommand = new Command<ICustomSegmentItem>(OnOrderByDateCommand);
            SelectedItemCommand = new Command(async () => await OnSelectedItemCommand());
            SearchTextCommand = new Command<string>(OnSearchTextCommand);
            //items for segment control
            SegmentItems = new ObservableCollection<ICustomSegmentItem>();
            SegmentItems.Add(new CustomSegmentItem()
            {
                Id = 1,
                Title = "Order by Date Asc",
            });
            SegmentItems.Add(new CustomSegmentItem()
            {
                Id = 2,
                Title = "Order by Date Desc",
            });
        }

        private void OnSearchTextCommand(string text)
        {
            OnSearchCommand(text);
        }

        private void OnOrderByDateCommand(ICustomSegmentItem item)
        {
            if (item.Id == 1)
            {
                Items.Restart(Items.OrderBy(i => i.Date).ToList());
            }
            else
            {
                Items.Restart(Items.OrderByDescending(i => i.Date).ToList());
            }
        }

        private void OnSearchCommand()
        {
            OnSearchCommand(SearchText);
        }

        private void OnSearchCommand(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                Items.Restart(_currentItems);
            }
            else
            {
                var filteredItems = _currentItems.Where(i => i.Main.Contains(text))
                                                 .ToList();

                Items.Restart(filteredItems);
            }
        }

        /// <summary>
        /// restart the items from current list
        /// </summary>
        /// <param name="result"></param>
        public void UpdateResult(MyWeatherResult result)
        {
            _currentCity = result.City;
            Items.Restart(result.Items);
            _currentItems.Restart(result.Items);
        }

        private async Task OnSelectedItemCommand()
        {
            var parameter = new ForecastDetailParameter()
            {
                City = _currentCity,
                Item = SelectedItem
            };
            await Navigation.PushAsync(new ForecastDetailPage(parameter));
        }
    }
}
