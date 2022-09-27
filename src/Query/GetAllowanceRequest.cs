#nullable enable
namespace SecretNET.Token;

/// <summary>
/// Class GetAllowanceRequest (JSON DTO).
/// </summary>
public class GetAllowanceRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("allowance")]
    public GetAllowanceRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllowanceRequest"/> class.
    /// </summary>
    /// <param name="owner">Account from which tokens are allowed to be taken.</param>
    /// <param name="spender">Account which is allowed to spend tokens on behalf of the owner.</param>
    /// <param name="viewingKey">The viewing key.</param>
    public GetAllowanceRequest(string owner, string spender, string? viewingKey)
    {
        Payload = new GetAllowanceRequest_Payload
        {
            Owner = owner,
            Spender = spender,
            ViewingKey = viewingKey
        };
    }
}

/// <summary>
/// Class GetAllowanceRequest_Payload (JSON DTO).
/// </summary>
public class GetAllowanceRequest_Payload
{
    /// <summary>
    /// Account from which tokens are allowed to be taken (not optional).
    /// </summary>
    /// <value>The owner.</value>
    [JsonProperty("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// Account which is allowed to spend tokens on behalf of the owner (not optional).
    /// </summary>
    /// <value>The spender.</value>
    [JsonProperty("spender")]
    public string Spender { get; set; }

    /// <summary>
    /// The viewing key (not optional).
    /// </summary>
    /// <value>The key.</value>
    [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
    public string? ViewingKey { get; set; }
}
#nullable disable