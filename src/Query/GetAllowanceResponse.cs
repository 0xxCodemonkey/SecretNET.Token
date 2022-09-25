namespace SecretNET.Token;

/// <summary>
/// Class GetAllowanceResponse (JSON DTO).
/// </summary>
public class GetAllowanceResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("with_permit")]
    public GetAllowanceResponse_Result Result { get; set; }
}

/// <summary>
/// Class GetAllowanceResponse_Result (JSON DTO).
/// </summary>
public class GetAllowanceResponse_Result
{
    /// <summary>
    /// Account from which tokens are allowed to be taken.
    /// </summary>
    /// <value>The owner.</value>
    [JsonProperty("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// Account which is allowed to spend tokens on behalf of the owner.
    /// </summary>
    /// <value>The spender.</value>
    [JsonProperty("spender")]
    public string Spender { get; set; }

    /// <summary>
    /// The current allowance (Uint128).
    /// </summary>
    /// <value>The allowance.</value>
    [JsonProperty("allowance")]
    public string Allowance { get; set; }

    /// <summary>
    /// Time at which the allowance expires.
    /// Counts the number of seconds from epoch, 1.1.1970 encoded as uint64.
    /// </summary>
    /// <value>The expiration.</value>
    [JsonProperty("expiration")]
    public int? Expiration { get; set; }
}
