using System;
using MyWeatherApp.Constants;
using Xamarin.Forms;

namespace MyWeatherApp.Effects
{
    public class TextShadowEffect : RoutingEffect
    {
        public TextShadowEffect() : base($"{EffectConstants.AssamblyName}.{nameof(TextShadowEffect)}")
        {
        }
    }
}
