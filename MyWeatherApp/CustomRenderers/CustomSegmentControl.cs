using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyWeatherApp.Models;
using Xamarin.Forms;

namespace MyWeatherApp.CustomRenderers
{
    public class CustomSegmentControl : View
    {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
        propertyName: nameof(Items),
        returnType: typeof(ObservableCollection<ICustomSegmentItem>),
        declaringType: typeof(CustomSegmentControl),
        defaultValue: default(ObservableCollection<ICustomSegmentItem>));

        public ObservableCollection<ICustomSegmentItem> Items
        {
            get => (ObservableCollection<ICustomSegmentItem>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public static readonly BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
        propertyName: nameof(ItemSelectedCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(CustomSegmentControl),
        defaultValue: default(ICommand));

        public ICommand ItemSelectedCommand
        {
            get => (ICommand)GetValue(ItemSelectedCommandProperty);
            set => SetValue(ItemSelectedCommandProperty, value);
        }
    }
}
