using System;
using System.ComponentModel;
using MyWeatherApp.CustomRenderers;
using MyWeatherApp.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSegmentControl), typeof(IOSSegmentControl))]
namespace MyWeatherApp.iOS.CustomRenderers
{
    public class IOSSegmentControl : ViewRenderer<View, UISegmentedControl>
    {
        private CustomSegmentControl _customSegmentControl;
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            if (e.NewElement != null)
            {
                var segment = new UISegmentedControl();
                _customSegmentControl = Element as CustomSegmentControl;
                if (_customSegmentControl.Items != null)
                {
                    nuint position = 0;
                    foreach (var item in _customSegmentControl.Items)
                    {
                        var segmentItem = UIAction.Create(item.Title, null, null, Handler);
                        segment.InsertSegment(segmentItem, position, true);
                        position++;
                    }

                    segment.SelectedSegment = 0;
                }

                SetNativeControl(segment);
            }
        }

        private void Handler(UIAction action)
        {
            Console.WriteLine(action.Title);
            Console.WriteLine(Control.SelectedSegment);
            var position = (int)Control.SelectedSegment;
            var item = _customSegmentControl.Items[position];
            _customSegmentControl.ItemSelectedCommand?.Execute(item);
        }
    }
}
