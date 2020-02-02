using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Clients;
using Weather.Core.Common;
using Weather.Core.Entities;
using Weather.Core.Entities.OpenWeatherMap;

namespace Weather.Clients
{
    public class OpenWeatherClient: Client, IOpenWeatherClient
    {
        private readonly AppConfig appConfig;

        public OpenWeatherClient(AppConfig appConfig) : base(appConfig.Clients.OpenWeatherMap.BaseURL)
        {
            this.appConfig = appConfig;
        }

        /// <summary>
        /// Gets the forecast object by city identifier
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns>Forecast object</returns>
        public async Task<Forecast> GetForecast(long cityId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", cityId.ToString());
            parameters.Add("units", "metric");
            parameters.Add("appid", appConfig.Clients.OpenWeatherMap.AppId);

            return await GetSingle<Forecast>(GlobalConstants.OWM_PATH_FORECAST, parameters);
        }

        /// <summary>
        /// Get the current weather by city identifier
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns>Current Weather object</returns>
        public async Task<CurrentWeather> GetCurrentWeather(long cityId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", cityId.ToString());
            parameters.Add("units", "metric");
            parameters.Add("appid", appConfig.Clients.OpenWeatherMap.AppId);

            return await GetSingle<CurrentWeather>(GlobalConstants.OWM_PATH_WEATHER, parameters);
        }
    }
}
