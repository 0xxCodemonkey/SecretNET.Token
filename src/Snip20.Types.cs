namespace SecretNET.Token;

/// <summary>
/// Class SimpleStatusResponse_Result (JSON DTO).
/// </summary>
public class SimpleStatusResponse_Result
{
    /// <summary>
    /// Response status e.g. "success"
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
}

