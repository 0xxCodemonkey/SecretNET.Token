#nullable enable
namespace SecretNET.Token;

/// <summary>
/// Class RegisterReceiveRequest (JSON DTO).
/// </summary>
public class RegisterReceiveRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("register_receive")]
    public RegisterReceiveRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterReceiveRequest"/> class.
    /// </summary>
    /// <param name="codeHash">A 32-byte hex encoded string, with the code hash of the receiver contract.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public RegisterReceiveRequest(string codeHash, string? padding = null)
    {
        Payload = new RegisterReceiveRequest_Payload
        {
            CodeHash = codeHash,
            Padding = padding
        };
    }
}

/// <summary>
/// Class RegisterReceiveRequest_Payload (JSON DTO).
/// </summary>
public class RegisterReceiveRequest_Payload
{
    /// <summary>
    /// A 32-byte hex encoded string, with the code hash of the receiver contract (not optional). 
    /// </summary>
    /// <value>The code hash.</value>
    [JsonProperty("code_hash")]
    public string CodeHash { get; set; }

    /// <summary>
    /// Ignored string used to maintain constant-length messages.
    /// </summary>
    /// <value>The padding.</value>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}
#nullable disable