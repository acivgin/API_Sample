using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core;
using Weather.Core.Common;
using Weather.Core.DTOs.Location;
using Weather.Core.Entities.Location;
using Weather.Core.Services;

namespace Weather.Services
{
    public class LocationService: ILocationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.cache = cache;
        }

        /// <summary>
        /// Gets the cities by keyword parameters; filter by name
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List of City DTOs</returns>
        public async Task<IEnumerable<CityDTO>> SearchCities(string keyword)
        {
            var cities = await cache.GetOrCreateAsync<IEnumerable<City>>(string.Format(CacheKeys.DB_CITIES, keyword), async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);
                return await unitOfWork.Cities.SearchByName(keyword);
            });
            return mapper.Map<IEnumerable<CityDTO>>(cities);
        }
    }
}
