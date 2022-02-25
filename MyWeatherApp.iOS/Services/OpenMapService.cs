using System;
using CoreLocation;
using MapKit;
using MyWeatherApp.Interfaces;
using MyWeatherApp.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenMapService))]
namespace MyWeatherApp.iOS.Services
{
    /// <summary>
    /// https://developer.apple.com/documentation/mapkit/mkmapitem/1452207-openmaps
    /// </summary>
    public class OpenMapService : IOpenMapService
    {
        public void OpenPlace(double latitude, double longitude, string name)
        {
            var coordinates = new CLLocationCoordinate2D(latitude, longitude);
            var placeMark = new MKPlacemark(coordinates);
            var mapItem = new MKMapItem(placeMark);
            mapItem.Name = name;
            var map = new MKMapItem[] { mapItem };
            MKMapItem.OpenMaps(map);
        }
    }
}
