using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.DTOs.Weather;

namespace Weather.Core.Services
{
    public interface IWeatherService
    {
        Task<ForecastDTO> GetForecast(long cityId);
        Task<CurrentWeatherDTO> GetCurrentWeather(long cityId);
    }
}
