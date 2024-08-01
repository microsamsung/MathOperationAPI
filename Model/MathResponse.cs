using System.Text.Json.Serialization;

namespace MathOperationAPI.Model
{
    public class MathResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public object? Data { get; set; }
        //public string Error { get; set; }
    }
}
