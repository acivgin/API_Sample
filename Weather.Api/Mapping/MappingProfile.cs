using AutoMapper;
using System.Linq;
using Weather.Core.DTOs.Location;
using Weather.Core.DTOs.Weather;
using Weather.Core.Entities.Location;
using Weather.Core.Entities.OpenWeatherMap;

namespace Weather.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Forecast, ForecastDTO>()
                .ForMember(f => f.CityName, m => m.MapFrom(x => x.CityDetails.Name));

            CreateMap<WeatherDetails, WeatherDTO>()
                .ForMember(f => f.Date, m => m.MapFrom(x => x.Date))
                .ForMember(f => f.Temperature, m => m.MapFrom(x => x.MainDetails.Temperature))
                .ForMember(f => f.Humidity, m => m.MapFrom(x => x.MainDetails.Humidity))
                .ForMember(f => f.WindSpeed, m => m.MapFrom(x => x.Wind.Speed))
                .ForMember(f => f.WeatherName, m => m.MapFrom(x => x.WeatherDesc.FirstOrDefault().Name))
                .ForMember(f => f.WeatherIcon, m => m.MapFrom(x => x.WeatherDesc.FirstOrDefault().Icon));

            CreateMap<CurrentWeather, CurrentWeatherDTO>()
                .ForMember(f => f.Date, m => m.MapFrom(x => x.Date))
                .ForMember(f => f.Temperature, m => m.MapFrom(x => x.MainDetails.Temperature))
                .ForMember(f => f.Humidity, m => m.MapFrom(x => x.MainDetails.Humidity))
                .ForMember(f => f.WindSpeed, m => m.MapFrom(x => x.Wind.Speed))
                .ForMember(f => f.WeatherName, m => m.MapFrom(x => x.WeatherDesc.FirstOrDefault().Name))
                .ForMember(f => f.WeatherIcon, m => m.MapFrom(x => x.WeatherDesc.FirstOrDefault().Icon));

            CreateMap<City, CityDTO>();
        }
    }
}
