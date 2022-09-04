namespace SecretNET.SNIP20;

/// <summary>
/// Class SendFromResponse (JSON DTO).
/// </summary>
public class SendFromResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("send_from")]
    public SimpleStatusResponse_Result Result { get; set; }
}
