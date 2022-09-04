namespace SecretNET.SNIP20;

/// <summary>
/// Class GetMintersResponse (JSON DTO).
/// </summary>
public class GetMintersResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("minters")]
    public GetMintersResponse_Result Result { get; set; }
}

/// <summary>
/// Class GetMintersResponse_Result (JSON DTO).
/// </summary>
public class GetMintersResponse_Result
{
    /// <summary>
    /// List of addresses of minters.
    /// </summary>
    /// <value>The minters.</value>
    [JsonProperty("minters")]
    public string[] Minters { get; set; }

}
