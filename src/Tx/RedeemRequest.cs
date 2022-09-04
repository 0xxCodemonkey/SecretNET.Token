#nullable enable
namespace SecretNET.SNIP20;

/// <summary>
/// Class RedeemRequest (JSON DTO).
/// </summary>
public class RedeemRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("redeem")]
    public RedeemRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RedeemRequest" /> class.
    /// </summary>
    /// <param name="amount">The amount of tokens to redeem to (Uint128).</param>
    /// <param name="denom">Denom of tokens to mint. Only used if the contract supports multiple denoms.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public RedeemRequest(string amount, string? denom = null, string? padding = null)
    {
        Payload = new RedeemRequest_Payload
        {
            Amount = amount,
            Padding = padding
        };
    }
}

/// <summary>
/// Class RedeemRequest_Payload (JSON DTO).
/// </summary>
public class RedeemRequest_Payload
{
    /// <summary>
    /// The amount of tokens to redeem to (Uint128) (not optional).
    /// </summary>
    /// <value>The amount.</value>
    [JsonProperty("amount")]
    public string Amount { get; set; }

    /// <summary>
    /// Denom of tokens to mint. Only used if the contract supports multiple denoms.
    /// </summary>
    [JsonProperty("denom")]
    public string Denom { get; set; }

    /// <summary>
    /// Ignored string used to maintain constant-length messages.
    /// </summary>
    /// <value>The padding.</value>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}
#nullable disable