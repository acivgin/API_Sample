using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Weather.Core.Common;

namespace Weather.Core.Entities.OpenWeatherMap
{
    public class WeatherDetails
    {
        [JsonProperty("main")]
        public WeatherMainInfo MainDetails { get; set; }

        [JsonProperty("weather")]
        public List<WeatherDescription> WeatherDesc { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Date { get; set; }
    }
}
