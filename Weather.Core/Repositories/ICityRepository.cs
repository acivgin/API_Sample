using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Entities.Location;

namespace Weather.Core.Repositories
{
    public interface ICityRepository
    {
        Task<City> GetById(long id);
        Task<IEnumerable<City>> SearchByName(string keyword);
    }
}
