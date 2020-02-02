using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Common
{
    public class UnixDateTimeConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long ts = serializer.Deserialize<long>(reader);
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(ts);
            return dateTimeOffset.UtcDateTime;
        }

        public override bool CanConvert(Type type)
        {
            return typeof(DateTime).IsAssignableFrom(type);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead
        {
            get { return true; }
        }
    }
}
