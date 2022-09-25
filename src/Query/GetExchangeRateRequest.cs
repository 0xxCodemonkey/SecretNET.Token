namespace SecretNET.Token;

/// <summary>
/// Class GetExchangeRateRequest (JSON DTO).
/// </summary>
public class GetExchangeRateRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("exchange_rate")]
    public object Payload { get; set; } = new object();
}


