using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.DTOs.Location;

namespace Weather.Core.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<CityDTO>> SearchCities(string keyword);
    }
}
