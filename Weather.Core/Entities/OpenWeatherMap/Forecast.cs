using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Entities.OpenWeatherMap
{
    public class Forecast
    {
        [JsonProperty("list")]
        public List<WeatherDetails> ForecastItems { get; set; }

        [JsonProperty("city")]
        public CityDetails CityDetails { get; set; }
    }
}
