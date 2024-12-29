using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovidTracker.Infrastructure.Converters
{
    internal class DateConverter : JsonConverter<DateTime>
    {
        //public override bool CanConvert(Type typeToConvert)
        //{
        //    return base.CanConvert(typeToConvert) || Type.GetTypeCode(typeToConvert) == TypeCode.Int32;
        //}
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string date = reader.GetInt32().ToString();

            if (date == null) return DateTime.MinValue;

            return DateTime.ParseExact(date, "yyyyMMdd", null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
