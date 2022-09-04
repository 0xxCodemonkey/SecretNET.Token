namespace SecretNET.SNIP20;

/// <summary>
/// Class SendResponse (JSON DTO).
/// </summary>
public class SendResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("send")]
    public SimpleStatusResponse_Result Result { get; set; }
}
