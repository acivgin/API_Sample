using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Common
{
    public static class CacheKeys
    {
        public static readonly string OWM_FORECAST = "OpenWeatherMap::Forecast::{0}";
        public static readonly string OWM_WEATHER = "OpenWeatherMap::Weather::{0}";

        public static readonly string DB_CITIES = "Database::Cities::{0}";
    }
}
