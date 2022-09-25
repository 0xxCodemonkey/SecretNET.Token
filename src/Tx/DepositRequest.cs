#nullable enable
namespace SecretNET.Token;

/// <summary>
/// Class DepositRequest (JSON DTO).
/// </summary>
public class DepositRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("burn")]
    public DepositRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BurnRequest"/> class.
    /// </summary>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public DepositRequest(string amount, string? padding = null)
    {
        Payload = new DepositRequest_Payload
        {
            Padding = padding
        };
    }
}

/// <summary>
/// Class DepositRequest_Payload (JSON DTO).
/// </summary>
public class DepositRequest_Payload
{
    /// <summary>
    /// Ignored string used to maintain constant-length messages.
    /// </summary>
    /// <value>The padding.</value>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}
#nullable disable