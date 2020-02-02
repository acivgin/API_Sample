using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Repositories;

namespace Weather.Core
{
    public interface IUnitOfWork: IDisposable
    {
        ICityRepository Cities { get; }
        Task<int> CommitAsync();
    }
}
