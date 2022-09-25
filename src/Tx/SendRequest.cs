#nullable enable
namespace SecretNET.Token;

/// <summary>
/// Class SendRequest (JSON DTO).
/// </summary>
public class SendRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("send")]
    public SendRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SendRequest"/> class.
    /// </summary>
    /// <param name="recipient">Accounts SHOULD be a valid bech32 address, but contracts may use a different naming scheme as well.</param>
    /// <param name="amount">The amount of tokens to send (Uint128).</param>
    /// <param name="msg">Base64 encoded message, which the recipient will receive.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public SendRequest(string recipient, string amount, string? msg = null, string? padding = null)
    {
        Payload = new SendRequest_Payload
        {
            Recipient = recipient,
            Amount = amount,
            Msg = msg,
            Padding = padding
        };
    }
}

/// <summary>
/// Class SendRequest_Payload (JSON DTO).
/// </summary>
public class SendRequest_Payload
{
    /// <summary>
    /// Accounts SHOULD be a valid bech32 address, but contracts may use a different naming scheme as well (not optional).
    /// </summary>
    /// <value>The recipient.</value>
    [JsonProperty("recipient")]
    public string Recipient { get; set; }

    /// <summary>
    /// The amount of tokens to send (Uint128) (not optional).
    /// </summary>
    /// <value>The amount.</value>
    [JsonProperty("amount")]
    public string Amount { get; set; }

    /// <summary>
    /// Base64 encoded message, which the recipient will receive.
    /// </summary>
    /// <value>The MSG.</value>
    [JsonProperty("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// Ignored string used to maintain constant-length messages.
    /// </summary>
    /// <value>The padding.</value>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}
#nullable disable