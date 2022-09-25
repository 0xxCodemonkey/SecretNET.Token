namespace SecretNET.Token;

/// <summary>
/// Class DepositResponse (JSON DTO).
/// </summary>
public class DepositResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("deposit")]
    public SimpleStatusResponse_Result Result { get; set; }
}
