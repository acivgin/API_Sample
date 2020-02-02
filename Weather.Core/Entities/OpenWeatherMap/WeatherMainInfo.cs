using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Entities.OpenWeatherMap
{
    public class WeatherMainInfo
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }
    }
}
