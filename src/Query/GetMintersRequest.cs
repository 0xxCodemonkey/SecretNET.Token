namespace SecretNET.Token;

/// <summary>
/// Class GetMintersRequest (JSON DTO).
/// </summary>
public class GetMintersRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("minters")]
    public object Payload { get; set; } = new object();
}


