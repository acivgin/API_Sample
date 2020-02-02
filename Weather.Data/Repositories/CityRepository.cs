using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Core.Entities.Location;
using Weather.Core.Repositories;

namespace Weather.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(LocationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Get the City by identifer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>City</returns>
        public async Task<City> GetById(long id)
        {
            return await GetByIdAsync(id);
        }

        /// <summary>
        /// Gets the list of cities which contain keyword in their name
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List of filtered cities</returns>
        public async Task<IEnumerable<City>> SearchByName(string keyword)
        {
            return await LocationDbContext.Cities.Where(c => !string.IsNullOrEmpty(c.Name) && c.Name.ToLower()
                                                    .StartsWith(keyword.ToLower()))
                                                    .Take(5)
                                                    .ToListAsync();
        }

        private LocationDbContext LocationDbContext
        {
            get { return Context as LocationDbContext; }
        }
    }
}
