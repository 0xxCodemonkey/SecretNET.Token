namespace SecretNET.SNIP20;

/// <summary>
/// Class MintResponse (JSON DTO).
/// </summary>
public class MintResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("mint")]
    public SimpleStatusResponse_Result Result { get; set; }
}
