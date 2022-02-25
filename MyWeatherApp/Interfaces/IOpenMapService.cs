using System;
namespace MyWeatherApp.Interfaces
{
    /// <summary>
    /// this service invokes platform
    /// specific map MapKit or Google Map
    /// </summary>
    public interface IOpenMapService
    {
        void OpenPlace(double latitude, double longitude, string name);
    }
}
