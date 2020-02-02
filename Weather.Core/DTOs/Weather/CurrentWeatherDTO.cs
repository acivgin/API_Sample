using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.DTOs.Weather
{
    public class CurrentWeatherDTO
    {
        public DateTime Date { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public double WindSpeed { get; set; }

        public string WeatherName { get; set; }

        public string WeatherIcon { get; set; }

        public string CityName { get; set; }
    }
}
