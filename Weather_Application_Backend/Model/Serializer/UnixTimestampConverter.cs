namespace Weather_Application_Backend.Model.Serializer
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class UnixTimestampConverter : JsonConverter<DateTime>
    {
        private readonly TimeSpan _gmtPlus2Offset = TimeSpan.FromHours(2);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var unixTime = reader.GetInt64();
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime.Add(_gmtPlus2Offset);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var unixTime = ((DateTimeOffset)value).ToOffset(_gmtPlus2Offset).ToUnixTimeSeconds();
            writer.WriteNumberValue(unixTime);
        }
    }

}
