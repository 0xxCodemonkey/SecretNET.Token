namespace SecretNET.SNIP20;

/// <summary>
/// Class RegisterReceiveResponse (JSON DTO).
/// </summary>
public class RegisterReceiveResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("register_receive")]
    public SimpleStatusResponse_Result Result { get; set; }
}
