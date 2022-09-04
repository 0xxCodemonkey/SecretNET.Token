#nullable enable
namespace SecretNET.SNIP20;

/// <summary>
/// Class BurnRequest (JSON DTO).
/// </summary>
public class BurnRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("burn")]
    public BurnRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BurnRequest"/> class.
    /// </summary>
    /// <param name="amount">The amount of tokens to burn (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public BurnRequest(string amount, string? padding = null)
    {
        Payload = new BurnRequest_Payload
        {
            Amount = amount,
            Padding = padding
        };
    }
}

/// <summary>
/// Class BurnRequest_Payload (JSON DTO).
/// </summary>
public class BurnRequest_Payload
{
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