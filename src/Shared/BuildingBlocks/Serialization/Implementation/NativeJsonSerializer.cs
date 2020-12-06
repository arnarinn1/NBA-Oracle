using System.Text.Encodings.Web;
using System.Text.Json;

namespace BuildingBlocks.Serialization.Implementation
{
    public class NativeJsonSerializer : ISerializer
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public string Serialize<T>(T data) 
        {
            return JsonSerializer.Serialize(data, Options);
        }

        public T Deserialize<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data);
        }
    }
}