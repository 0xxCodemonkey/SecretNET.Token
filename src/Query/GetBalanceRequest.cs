#nullable enable
namespace SecretNET.SNIP20;

/// <summary>
/// Class GetBalanceRequest (JSON DTO).
/// </summary>
public class GetBalanceRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("balance")]
    public GetBalanceRequest_Payload Payload { get; set; }    

    /// <summary>
    /// Initializes a new instance of the <see cref="GetBalanceRequest"/> class.
    /// </summary>
    /// <param name="address">The address.</param>
    /// <param name="viewingKey">The viewing key.</param>
    public GetBalanceRequest(string address, string viewingKey)
    {
        Payload = new GetBalanceRequest_Payload
        {
            Address = address,
            ViewingKey = viewingKey
        };
    }
}

/// <summary>
/// Class GetBalanceRequest_Payload (JSON DTO).
/// </summary>
public class GetBalanceRequest_Payload
{
    /// <summary>
    /// Addresses SHOULD be a valid bech32 address, but contracts may use a different naming scheme as well (not optional).
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets the viewing key.
    /// </summary>
    /// <value>The viewing key.</value>
    [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewingKey { get; set; }
}
#nullable disable