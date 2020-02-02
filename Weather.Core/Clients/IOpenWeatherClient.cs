using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Entities;
using Weather.Core.Entities.OpenWeatherMap;

namespace Weather.Core.Clients
{
    public interface IOpenWeatherClient
    {
        Task<Forecast> GetForecast(long cityId);
        Task<CurrentWeather> GetCurrentWeather(long cityId);
    }
}
