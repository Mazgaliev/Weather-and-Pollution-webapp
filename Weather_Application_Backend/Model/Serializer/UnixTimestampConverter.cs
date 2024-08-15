namespace Weather_Application_Backend.Model.Serializer
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class UnixTimestampConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var unixTime = reader.GetInt64();
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var unixTime = ((DateTimeOffset)value).ToUnixTimeSeconds();
            writer.WriteNumberValue(unixTime);
        }
    }

}
