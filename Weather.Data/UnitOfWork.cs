using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core;
using Weather.Core.Repositories;
using Weather.Data.Repositories;

namespace Weather.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly LocationDbContext locationDbContext;
        private CityRepository cityRepository;

        public UnitOfWork(LocationDbContext locationDbContext)
        {
            this.locationDbContext = locationDbContext;
        }

        public ICityRepository Cities => cityRepository = cityRepository ?? new CityRepository(locationDbContext);

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            return await locationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            locationDbContext.Dispose();
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        Task<int> IUnitOfWork.CommitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
