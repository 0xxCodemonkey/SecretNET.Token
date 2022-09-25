#nullable enable
namespace SecretNET.Token;

/// <summary>
/// Class MintRequest (JSON DTO).
/// </summary>
public class MintRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("mint")]
    public MintRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MintRequest"/> class.
    /// </summary>
    /// <param name="recipient">Account to mint tokens to.</param>
    /// <param name="amount">Amount of tokens to mint (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public MintRequest(string recipient, string amount, string? padding = null)
    {
        Payload = new MintRequest_Payload
        {
            Recipient = recipient,
            Amount = amount,
            Padding = padding
        };
    }
}

/// <summary>
/// Class MintRequest_Payload (JSON DTO).
/// </summary>
public class MintRequest_Payload
{
    /// <summary>
    /// Account to mint tokens to (not optional).
    /// </summary>
    /// <value>The recipient.</value>
    [JsonProperty("recipient")]
    public string Recipient { get; set; }

    /// <summary>
    /// Amount of tokens to mint (Uint128) (not optional).
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