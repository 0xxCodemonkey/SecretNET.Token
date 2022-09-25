#nullable enable
namespace SecretNET.Token;

/// <summary>
/// Class TransferRequest (JSON DTO).
/// </summary>
public class TransferRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("transfer")]
    public TransferRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TransferRequest"/> class.
    /// </summary>
    /// <param name="recipient">Account to send tokens to.</param>
    /// <param name="amount">Amount of tokens to transfer (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public TransferRequest(string recipient, string amount, string? padding = null)
    {
        Payload = new TransferRequest_Payload
        {
            Recipient = recipient,
            Amount = amount,
            Padding = padding
        };
    }
}

/// <summary>
/// Class TransferRequest_Payload (JSON DTO).
/// </summary>
public class TransferRequest_Payload
{
    /// <summary>
    /// Accounts SHOULD be a valid bech32 address, but contracts may use a different naming scheme as well (not optional).
    /// </summary>
    /// <value>The recipient.</value>
    [JsonProperty("recipient")]
    public string Recipient { get; set; }

    /// <summary>
    /// The amount of tokens to transfer (Uint128) (not optional).
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