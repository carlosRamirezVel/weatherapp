using System;
using Newtonsoft.Json;

namespace MyWeatherApp.Extenstions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object myObject)
        {
            var json = JsonConvert.SerializeObject(myObject);
            return json;
        }

        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
