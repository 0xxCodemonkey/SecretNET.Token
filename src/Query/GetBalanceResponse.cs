namespace SecretNET.Token;

/// <summary>
/// Class GetBalanceResponse (JSON DTO).
/// </summary>
public class GetBalanceResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("balance")]
    public GetBalanceResponse_Result Result { get; set; }

    /// <summary>
    /// Error.
    /// </summary>
    [JsonProperty("viewing_key_error")]
    public GetBalanceResponse_Error Error { get; set; }
}

/// <summary>
/// Class GetBalanceResponse_Result (JSON DTO).
/// </summary>
public class GetBalanceResponse_Result
{
    /// <summary>
    /// The amount of tokens (Uint128).
    /// </summary>
    /// <value>The amount.</value>
    [JsonProperty("amount")]
    public string Amount { get; set; }
}

/// <summary>
/// Class GetBalanceResponse_Error (JSON DTO).
/// </summary>
public class GetBalanceResponse_Error
{
    /// <summary>
    /// Error message from the contract.
    /// </summary>
    /// <value>The MSG.</value>
    [JsonProperty("msg")]
    public string Msg { get; set; }
}
