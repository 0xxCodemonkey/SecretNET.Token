namespace SecretNET.SNIP20;

/// <summary>
/// Class GetTokenInfoRequest (JSON DTO).
/// </summary>
public class GetTokenInfoRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("token_info")]
    public object Payload { get; set; } = new object();
}


