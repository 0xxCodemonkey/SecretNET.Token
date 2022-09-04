#nullable enable
namespace SecretNET.SNIP20;

/// <summary>
/// Class IncreaseAllowanceRequest (JSON DTO).
/// </summary>
public class IncreaseAllowanceRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("increase_allowance")]
    public IncreaseAllowanceRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="IncreaseAllowanceRequest"/> class.
    /// </summary>
    /// <param name="spender">The address of the account getting access to the funds.</param>
    /// <param name="amount">The number of tokens to increase allowance by (Uint128).</param>
    /// <param name="expiration">Time at which the allowance expires.
    /// Counts the number of seconds from epoch, 1.1.1970 encoded as uint64.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public IncreaseAllowanceRequest(string spender, string amount, int? expiration = null, string? padding = null)
    {
        Payload = new IncreaseAllowanceRequest_Payload
        {
            Spender = spender,
            Amount = amount,
            Expiration = expiration,
            Padding = padding
        };
    }
}

/// <summary>
/// Class IncreaseAllowanceRequest_Payload (JSON DTO).
/// </summary>
public class IncreaseAllowanceRequest_Payload
{
    /// <summary>
    /// The address of the account getting access to the funds (not optional).
    /// </summary>
    /// <value>The spender.</value>
    [JsonProperty("spender")]
    public string Spender { get; set; }

    /// <summary>
    /// The number of tokens to increase allowance by (Uint128) (not optional).
    /// </summary>
    /// <value>The amount.</value>
    [JsonProperty("amount")]
    public string Amount { get; set; }

    /// <summary>
    /// Time at which the allowance expires.
    /// Counts the number of seconds from epoch, 1.1.1970 encoded as uint64.
    /// </summary>
    /// <value>The expiration.</value>
    [JsonProperty("expiration")]
    public int? Expiration { get; set; }

    /// <summary>
    /// Ignored string used to maintain constant-length messages.
    /// </summary>
    /// <value>The padding.</value>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}
#nullable disable