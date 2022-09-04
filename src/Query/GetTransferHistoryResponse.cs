namespace SecretNET.SNIP20;

/// <summary>
/// Class GetTransferHistoryResponse (JSON DTO).
/// </summary>
public class GetTransferHistoryResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("transfer_history")]
    public GetTransferHistoryResponse_Result Result { get; set; }
}

/// <summary>
/// Class GetTransferHistoryResponse_Result (JSON DTO).
/// </summary>
public class GetTransferHistoryResponse_Result
{
    /// <summary>
    /// Gets or sets the TXS.
    /// </summary>
    /// <value>The TXS.</value>
    [JsonProperty("txs")]
    public Tx[] Txs { get; set; }

    /// <summary>
    /// Gets or sets the total.
    /// </summary>
    /// <value>The total.</value>
    [JsonProperty("total")]
    public long? Total { get; set; }

}
