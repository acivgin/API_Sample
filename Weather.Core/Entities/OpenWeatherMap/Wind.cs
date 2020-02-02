using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Entities.OpenWeatherMap
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}
