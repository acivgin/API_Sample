using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.DTOs.Weather
{
    public class ForecastDTO
    {
        public string CityName { get; set; }

        public List<DailyForecastDTO> DailyForecasts { get; set; }
    }
}
