namespace SecretNET.Token;

/// <summary>
/// Class TransferResponse (JSON DTO).
/// </summary>
public class TransferResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("transfer")]
    public SimpleStatusResponse_Result Result { get; set; }
}
