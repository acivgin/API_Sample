using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Weather.Core.Entities.Location
{
    public class City
    {
        public long Id { get; set; }
        
        public long OpenWeatherCityId { get; set; }

        public string Name { get; set; }

        public string CountryCode { get; set; }
    }
}
