namespace SecretNET.SNIP20;

/// <summary>
/// Class DecreaseAllowanceResponse (JSON DTO).
/// </summary>
public class DecreaseAllowanceResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("decrease_allowance")]
    public DecreaseAllowanceResponse_Result Result { get; set; }
}

/// <summary>
/// Class DecreaseAllowanceResponse_Result (JSON DTO).
/// </summary>
public class DecreaseAllowanceResponse_Result
{
    /// <summary>
    /// Gets or sets the spender.
    /// </summary>
    /// <value>The spender.</value>
    [JsonProperty("spender")]
    public string Spender { get; set; }

    /// <summary>
    /// Gets or sets the owner.
    /// </summary>
    /// <value>The owner.</value>
    [JsonProperty("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// Gets or sets the allowance.
    /// </summary>
    /// <value>The allowance.</value>
    [JsonProperty("allowance")]
    public object Allowance { get; set; }
}
