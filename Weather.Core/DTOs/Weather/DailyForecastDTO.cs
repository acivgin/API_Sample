using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.DTOs.Weather
{
    public class DailyForecastDTO
    {
        public DateTime Date { get; set; }

        public string DayName { get; set; }

        public double MaxTemperature { get; set; }

        public double MinTemperature { get; set; }

        public List<WeatherDTO> HourlyForecasts { get; set; }
    }
}
