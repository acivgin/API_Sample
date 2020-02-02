using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Core;
using Weather.Core.Clients;
using Weather.Core.Common;
using Weather.Core.DTOs.Weather;
using Weather.Core.Entities.OpenWeatherMap;
using Weather.Core.Services;

namespace Weather.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly AppConfig appConfig;
        private readonly IOpenWeatherClient openWeatherClient;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;

        public WeatherService(AppConfig appConfig, IOpenWeatherClient openWeatherClient, IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            this.appConfig = appConfig;
            this.openWeatherClient = openWeatherClient;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.cache = cache;
        }

        /// <summary>
        /// Gets the forecast by city identifier
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns>Forecast Dto</returns>
        public async Task<ForecastDTO> GetForecast(long cityId)
        {
            var forecast = await cache.GetOrCreateAsync<Forecast>(string.Format(CacheKeys.OWM_FORECAST, cityId), async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);
                var city = await unitOfWork.Cities.GetById(cityId);
                var forecastResponse = await openWeatherClient.GetForecast(city.OpenWeatherCityId);
                forecastResponse.ForecastItems.ForEach(a => DefineIconUrls(a.WeatherDesc));
                return forecastResponse;
            });

            var forecastDto = mapper.Map<Forecast, ForecastDTO>(forecast);
            forecastDto.DailyForecasts = forecast.ForecastItems.GroupBy(a => a.Date.Date).Select(s => new DailyForecastDTO
            {
                Date = s.Key,
                DayName = s.Key.ToString("dddd"),
                HourlyForecasts = mapper.Map<List<WeatherDTO>>(s),
                MaxTemperature = s.Max(m => m.MainDetails.Temperature),
                MinTemperature = s.Min(m => m.MainDetails.Temperature)
            }).ToList();

            return forecastDto;
        }

        /// <summary>
        /// Gets the current weather by city identifier
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns>Current Weather DTO</returns>
        public async Task<CurrentWeatherDTO> GetCurrentWeather(long cityId)
        {
            var weather = await cache.GetOrCreateAsync<CurrentWeather>(string.Format(CacheKeys.OWM_WEATHER, cityId), async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);
                var city = await unitOfWork.Cities.GetById(cityId);
                var weatherResponse = await openWeatherClient.GetCurrentWeather(city.OpenWeatherCityId);
                this.DefineIconUrls(weatherResponse.WeatherDesc);
                return weatherResponse;
            });

            var weatherDto = mapper.Map<CurrentWeather, CurrentWeatherDTO>(weather);
            return weatherDto;
        }

        /// <summary>
        /// Creates correct URL for weather icon
        /// </summary>
        /// <param name="weatherDescriptions"></param>
        private void DefineIconUrls(List<WeatherDescription> weatherDescriptions)
        {
            if (weatherDescriptions.Any())
            {
                weatherDescriptions.ForEach(a => a.Icon = string.Format(appConfig.Clients.OpenWeatherMap.IconURLFormat, a.Icon));
            }
        }
    }
}
