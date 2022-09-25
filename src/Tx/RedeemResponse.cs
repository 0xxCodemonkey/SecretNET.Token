namespace SecretNET.Token;

/// <summary>
/// Class RedeemResponse (JSON DTO).
/// </summary>
public class RedeemResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("redeem")]
    public SimpleStatusResponse_Result Result { get; set; }
}
