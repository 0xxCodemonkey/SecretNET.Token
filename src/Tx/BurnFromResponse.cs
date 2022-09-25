namespace SecretNET.Token;

/// <summary>
/// Class BurnFromResponse (JSON DTO).
/// </summary>
public class BurnFromResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("burn_from")]
    public SimpleStatusResponse_Result Result { get; set; }
}
