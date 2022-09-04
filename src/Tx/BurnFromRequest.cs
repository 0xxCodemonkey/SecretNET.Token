#nullable enable
namespace SecretNET.SNIP20;

/// <summary>
/// Class BurnFromRequest (JSON DTO).
/// </summary>
public class BurnFromRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("burn")]
    public BurnFromRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BurnRequest" /> class.
    /// </summary>
    /// <param name="owner">Account to take tokens from.</param>
    /// <param name="amount">The amount of tokens to burn (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public BurnFromRequest(string owner, string amount, string? padding = null)
    {
        Payload = new BurnFromRequest_Payload(owner, amount, padding);
    }
}

/// <summary>
/// Class BurnFromRequest_Payload (JSON DTO).
/// </summary>
public class BurnFromRequest_Payload
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BurnFromRequest_Payload"/> class.
    /// </summary>
    /// <param name="owner">The owner.</param>
    /// <param name="amount">The amount.</param>
    /// <param name="padding">The padding.</param>
    public BurnFromRequest_Payload(string owner, string amount, string? padding)
    {
        Owner = owner;
        Amount = amount;
        Padding = padding;
    }

    /// <summary>
    /// Account to take tokens from (not optional).
    /// </summary>
    /// <value>The amount.</value>
    [JsonProperty("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// The amount of tokens to burn (Uint128) (not optional).
    /// </summary>
    /// <value>The amount.</value>
    [JsonProperty("amount")]
    public string Amount { get; set; }

    /// <summary>
    /// Ignored string used to maintain constant-length messages.
    /// </summary>
    /// <value>The padding.</value>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}
#nullable disable