using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Entities.OpenWeatherMap
{
    public class CityDetails
    {
        [JsonProperty("id")]
        public long OWMCityIdentifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string CountryCode { get; set; }
    }
}
