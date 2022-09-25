#nullable enable
namespace SecretNET.Token;

/// <summary>
/// Class SetMintersRequest (JSON DTO).
/// </summary>
public class SetMintersRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("set_minters")]
    public SetMintersRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetMintersRequest"/> class.
    /// </summary>
    /// <param name="minterAddress">Address to allow minting.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public SetMintersRequest(string minterAddress, string? padding = null)
    {
        Payload = new SetMintersRequest_Payload
        {
            Minters = new string[] { minterAddress },
            Padding = padding
        };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetMintersRequest"/> class.
    /// </summary>
    /// <param name="minterAddresses">Addresses to allow minting.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public SetMintersRequest(string[] minterAddresses, string? padding = null)
    {
        Payload = new SetMintersRequest_Payload
        {
            Minters = minterAddresses,
            Padding = padding
        };
    }
}

/// <summary>
/// Class SetMintersRequest_Payload (JSON DTO).
/// </summary>
public class SetMintersRequest_Payload
{
    /// <summary>
    /// List of addresses to set to the list of minters (not optional).
    /// </summary>
    /// <value>The recipient.</value>
    [JsonProperty("minters")]
    public string[] Minters { get; set; }

    /// <summary>
    /// Ignored string used to maintain constant-length messages.
    /// </summary>
    /// <value>The padding.</value>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}
#nullable disable