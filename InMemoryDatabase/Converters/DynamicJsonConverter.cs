using System.Text.Json;
using System.Text.Json.Serialization;

namespace InMemoryDatabase.Converters;

internal class DynamicJsonConverter : JsonConverter<Dictionary<string, Type>>
{
    public override Dictionary<string, Type>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, Type> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}