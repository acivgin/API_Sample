using System.Collections.Generic;
using System.Linq;

namespace Weather.Core.Helpers
{
    public class Helper
    {
        public static string BuildUri(string urlPath, string baseURL, Dictionary<string, string> queryParams = null)
        {
            string url = $"{baseURL}{urlPath}";
            if (queryParams != null && queryParams.Count > 0)
            {
                url += "?";
                url += string.Join("&", queryParams.Select(a => $"{a.Key}={a.Value}").ToArray());
            }
            return url;
        }
    }
}
