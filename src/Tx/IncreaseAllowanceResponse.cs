namespace SecretNET.SNIP20;

/// <summary>
/// Class IncreaseAllowanceResponse (JSON DTO).
/// </summary>
public class IncreaseAllowanceResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("increase_allowance")]
    public IncreaseAllowanceResponse_Result Result { get; set; }
}

/// <summary>
/// Class IncreaseAllowanceResponse_Result (JSON DTO).
/// </summary>
public class IncreaseAllowanceResponse_Result
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
