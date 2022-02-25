using System;
using System.Threading.Tasks;

namespace MyWeatherApp.Interfaces
{
    public interface IAlertMessageService
    {
        Task AlertAsync(string title, string message, string cancel);
    }
}
