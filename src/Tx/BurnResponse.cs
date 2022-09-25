namespace SecretNET.Token;

/// <summary>
/// Class BurnResponse (JSON DTO).
/// </summary>
public class BurnResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("burn")]
    public SimpleStatusResponse_Result Result { get; set; }
}
