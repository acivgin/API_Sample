using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Core.Clients;
using Newtonsoft.Json;
using Weather.Core.Helpers;

namespace Weather.Clients
{
    public class Client : IClient
    {
        private readonly string BaseURL;

        public Client(string baseUrl)
        {
            this.BaseURL = baseUrl;
        }
        
        /// <summary>
        /// Gets the single T object from the URL path and query parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlPath"></param>
        /// <param name="queryParams"></param>
        /// <returns>T object</returns>
        public async Task<T> GetSingle<T>(string urlPath, Dictionary<string, string> queryParams)
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(Helper.BuildUri(urlPath, BaseURL, queryParams));
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
        
        /// <summary>
        /// Get the list of T objects from the URL path and query parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlPath"></param>
        /// <param name="queryParams"></param>
        /// <returns>List of T objects</returns>
        public async Task<IEnumerable<T>> GetList<T>(string urlPath, Dictionary<string, string> queryParams)
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(Helper.BuildUri(urlPath, BaseURL, queryParams));
                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }
        }

    }
}
