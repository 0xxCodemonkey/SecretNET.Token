namespace SecretNET.Token;

/// <summary>
/// Class TransferFromResponse (JSON DTO).
/// </summary>
public class TransferFromResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("transfer_from")]
    public SimpleStatusResponse_Result Result { get; set; }
}
