using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Core.Clients
{
    public interface IClient
    {
        Task<T> GetSingle<T>(string urlPath, Dictionary<string, string> queryParams);
        Task<IEnumerable<T>> GetList<T>(string urlPath, Dictionary<string, string> queryParams);
    }
}
