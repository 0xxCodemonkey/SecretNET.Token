#nullable enable
namespace SecretNET.SNIP20;

/// <summary>
/// Class TransferFromRequest (JSON DTO).
/// </summary>
public class TransferFromRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("transfer_from")]
    public TransferFromRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TransferFromRequest"/> class.
    /// </summary>
    /// <param name="owner">Account to take tokens from.</param>
    /// <param name="recipient">Account to send tokens to.</param>
    /// <param name="amount">Amount of tokens to transfer (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public TransferFromRequest(string owner, string recipient, string amount, string? padding = null)
    {
        Payload = new TransferFromRequest_Payload
        {
            Owner = owner,
            Recipient = recipient,
            Amount = amount,
            Padding = padding
        };
    }
}

/// <summary>
/// Class TransferFromRequest_Payload (JSON DTO).
/// </summary>
public class TransferFromRequest_Payload
{
    /// <summary>
    /// Account to take tokens from (not optional).
    /// </summary>
    /// <value>The owner.</value>
    [JsonProperty("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// Account to send tokens to (not optional).
    /// </summary>
    /// <value>The owner.</value>
    [JsonProperty("recipient")]
    public string Recipient { get; set; }

    /// <summary>
    /// Amount of tokens to transfer (Uint128) (not optional).
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