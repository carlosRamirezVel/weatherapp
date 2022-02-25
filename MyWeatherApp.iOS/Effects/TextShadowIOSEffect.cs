using System;
using CoreGraphics;
using MyWeatherApp.Constants;
using MyWeatherApp.Effects;
using MyWeatherApp.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName(EffectConstants.AssamblyName)]
[assembly: ExportEffect(typeof(TextShadowIOSEffect), nameof(TextShadowEffect))]
namespace MyWeatherApp.iOS.Effects
{
    public class TextShadowIOSEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control != null && Control is UILabel)
            {
                var label = (UILabel)Control;
                label.Layer.ShadowColor = UIColor.Black.CGColor;
                label.Layer.ShadowRadius = 3.0f;
                label.Layer.ShadowOpacity = 1.0f;
                label.Layer.ShadowOffset = new CGSize(width: 4, height: 4);
                label.Layer.MasksToBounds = false;
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
