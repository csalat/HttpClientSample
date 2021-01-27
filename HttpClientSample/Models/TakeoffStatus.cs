using System.Text.Json.Serialization;

namespace HttpClientSample.Models
{
    public class TakeoffStatus
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
