namespace SecretNET.Token;

/// <summary>
/// Class GetTokenInfoResponse (JSON DTO).
/// </summary>
public class GetTokenInfoResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("token_info")]
    public GetTokenInfoResponse_Result Result { get; set; }
}

/// <summary>
/// Class GetTokenInfoResponse_Result (JSON DTO).
/// </summary>
public class GetTokenInfoResponse_Result
{
    /// <summary>
    /// The token name.
    /// </summary>
    /// <value>The name.</value>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// The symbol of the token.
    /// </summary>
    /// <value>The symbol.</value>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// The decimals of the token.
    /// </summary>
    /// <value>The decimals.</value>
    [JsonProperty("decimals")]
    public ulong Decimals { get; set; }

    /// <summary>
    /// The total supply of the token.
    /// </summary>
    /// <value>The total supply.</value>
    [JsonProperty("total_supply")]
    public string TotalSupply { get; set; }
}
