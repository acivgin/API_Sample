using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Common
{
    public class AppConfig
    {
        public AppConfigClients Clients { get; set; }
    }

    public class AppConfigClients
    {
        public AppConfigOpenWeatherMap OpenWeatherMap { get; set; }
    }

    public class AppConfigOpenWeatherMap
    {
        public string BaseURL { get; set; }

        public string AppId { get; set; }

        public string IconURLFormat { get; set; }
    }
}
