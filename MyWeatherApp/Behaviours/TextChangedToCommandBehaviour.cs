using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyWeatherApp.Behaviours
{
    public class TextChangedToCommandBehaviour : Behavior<SearchBar>
    {
        public static readonly BindableProperty TextChangedCommandProperty = BindableProperty.Create(
        propertyName: nameof(TextChangedCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(TextChangedToCommandBehaviour),
        defaultValue: default(ICommand));

        public ICommand TextChangedCommand
        {
            get => (ICommand)GetValue(TextChangedCommandProperty);
            set => SetValue(TextChangedCommandProperty, value);
        }

        protected override void OnAttachedTo(SearchBar bindable)
        {
            bindable.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangedCommand?.Execute(e.NewTextValue);
        }

        protected override void OnDetachingFrom(SearchBar bindable)
        {
            bindable.TextChanged -= OnTextChanged;
        }
    }
}
