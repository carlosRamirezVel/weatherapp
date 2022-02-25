using System;
using Android.Content;
using Android.Views;
using Google.Android.Material.Tabs;
using MyWeatherApp.CustomRenderers;
using MyWeatherApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSegmentControl), typeof(DroidSegmentControl))]
namespace MyWeatherApp.Droid.CustomRenderers
{
    public class DroidSegmentControl : ViewRenderer<Xamarin.Forms.View, TabLayout>, TabLayout.IOnTabSelectedListener
    {
        private CustomSegmentControl _customSegmentControl;

        public DroidSegmentControl(Context context) : base(context)
        {
        }

        public void OnTabReselected(TabLayout.Tab tab)
        {
        }

        public void OnTabSelected(TabLayout.Tab tab)
        {
            Console.WriteLine($"Tab Selected {tab.Text}, position [{tab.Position}]");
            var item = _customSegmentControl.Items[tab.Position];
            _customSegmentControl.ItemSelectedCommand?.Execute(item);
        }

        public void OnTabUnselected(TabLayout.Tab tab)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                Control?.RemoveOnTabSelectedListener(this);
            }

            if (e.NewElement != null)
            {
                _customSegmentControl = Element as CustomSegmentControl;
                var tabLayout = (TabLayout)LayoutInflater.From(this.Context).Inflate(Resource.Layout.segment_tabs, null, false);
                tabLayout.AddOnTabSelectedListener(this);
                _customSegmentControl = Element as CustomSegmentControl;
                if (_customSegmentControl.Items != null)
                {
                    foreach (var item in _customSegmentControl.Items)
                    {
                        var tab = tabLayout.NewTab();
                        tab.SetText(item.Title);
                        tabLayout.AddTab(tab);
                    }
                }

                SetNativeControl(tabLayout);
            }
        }
    }
}
