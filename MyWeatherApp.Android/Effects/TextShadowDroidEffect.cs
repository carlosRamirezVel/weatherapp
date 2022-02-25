using System;
using Android.Widget;
using MyWeatherApp.Constants;
using MyWeatherApp.Droid.Effects;
using MyWeatherApp.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName(EffectConstants.AssamblyName)]
[assembly: ExportEffect(typeof(TextShadowDroidEffect), nameof(TextShadowEffect))]
namespace MyWeatherApp.Droid.Effects
{
    public class TextShadowDroidEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control != null && Control is TextView)
            {
                var textView = (TextView)Control;
                textView.SetShadowLayer(10, 0, 0, Color.Black.ToAndroid());
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
