using System;
using Android.Content;
using MyWeatherApp.Interfaces;

namespace MyWeatherApp.Droid.Services
{
    /// <summary>
    /// https://developers.google.com/maps/documentation/urls/android-intents
    /// </summary>
    public class OpenMapService : IOpenMapService
    {
        private Context _context;

        public OpenMapService(Context context)
        {
            _context = context;
        }

        public void OpenPlace(double latitude, double longitude, string name)
        {
            //TODO: we need to check if google play services are installed
            //otherwise we can get exceptions
            var url = $"geo:0,0?q={latitude},{longitude}({name})";
            var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(url));
            intent.SetPackage("com.google.android.apps.maps");
            _context.StartActivity(intent);
        }
    }
}
