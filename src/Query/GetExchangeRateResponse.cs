namespace SecretNET.SNIP20;

/// <summary>
/// Class GetExchangeRateResponse (JSON DTO).
/// </summary>
public class GetExchangeRateResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("exchange_rate")]
    public GetExchangeRateResponse_Result Result { get; set; }
}

/// <summary>
/// Class GetExchangeRateResponse_Result (JSON DTO).
/// </summary>
public class GetExchangeRateResponse_Result
{
    /// <summary>
    /// Exchange Rate (Uint128).
    /// </summary>
    /// <value>The rate.</value>
    [JsonProperty("rate")]
    public string Rate { get; set; }

    /// <summary>
    /// The denomination.
    /// </summary>
    /// <value>The denom.</value>
    [JsonProperty("denom")]
    public string Denom { get; set; }

}
