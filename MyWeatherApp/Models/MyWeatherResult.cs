using System;
using System.Collections.Generic;

namespace MyWeatherApp.Models
{
    public class MyWeatherResult
    {
        public MyCity City { get; set; }
        public IList<MyWeatherItem> Items { get; set; }
    }
}
