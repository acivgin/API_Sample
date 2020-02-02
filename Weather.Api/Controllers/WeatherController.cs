using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Core.Services;

namespace Weather.Api.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public readonly IWeatherService weatherService;
        public readonly IMapper mapper;

        public WeatherController(IWeatherService weatherService, IMapper mapper)
        {
            this.weatherService = weatherService;
            this.mapper = mapper;
        }

        //GET: /api/weather/forecast/{cityId}
        [HttpGet, Route("forecast/{cityId}")]
        public async Task<IActionResult> Forecast(long cityId)
        {
            var result = await weatherService.GetForecast(cityId);
            return new JsonResult(result);
        }

        //GET: /api/weather/current/{cityId}
        [HttpGet, Route("current/{cityId}")]
        public async Task<IActionResult> Weather(long cityId)
        {
            var result = await weatherService.GetCurrentWeather(cityId);
            return new JsonResult(result);
        }
    }
}