using System.Text.Json.Serialization;

namespace TwistedFizzBuzz.Client.Responses;

public class FizzBuzzApiResponse
{
    [JsonPropertyName("word")]
    public string Word { get; set; } = string.Empty;
    
    [JsonPropertyName("number")]
    public int Number { get; set; }
}