namespace SecretNET.Token;

/// <summary>
/// Class SetMintersResponse (JSON DTO).
/// </summary>
public class SetMintersResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("set_minters")]
    public SimpleStatusResponse_Result Result { get; set; }
}
