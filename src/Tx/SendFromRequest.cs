#nullable enable
namespace SecretNET.SNIP20;

/// <summary>
/// Class SendFromRequest (JSON DTO).
/// </summary>
public class SendFromRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("send_from")]
    public SendFromRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SendFromRequest"/> class.
    /// </summary>
    /// <param name="owner">Account to take tokens from.</param>
    /// <param name="recipient">Account to send tokens to.</param>
    /// <param name="amount">Amount of tokens to transfer (Uint128).</param>
    /// <param name="message">Base64 encoded message, which the recipient will receive.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public SendFromRequest(string owner, string recipient, string amount, string? message = null, string? padding = null)
    {
        Payload = new SendFromRequest_Payload
        {
            Owner = owner,
            Recipient = recipient,
            Amount = amount,
            Msg = message,
            Padding = padding
        };
    }
}

/// <summary>
/// Class SendFromRequest_Payload (JSON DTO).
/// </summary>
public class SendFromRequest_Payload
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