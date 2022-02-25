using System;
namespace MyWeatherApp.Models
{
    public interface ICustomSegmentItem
    {
        int Id { get; set; }
        string Title { get; set; }
    }

    public class CustomSegmentItem : ICustomSegmentItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
