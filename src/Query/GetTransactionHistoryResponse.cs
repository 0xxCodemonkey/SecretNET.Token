namespace SecretNET.Token;

/// <summary>
/// Class GetTransferHistoryResponse (JSON DTO).
/// </summary>
public class GetTransactionHistoryResponse
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
public class GetTransactionHistoryResponse_Result
{
    /// <summary>
    /// Gets or sets the TXS.
    /// </summary>
    /// <value>The TXS.</value>
    [JsonProperty("txs")]
    public TransactionTx[] Txs { get; set; }

    /// <summary>
    /// Gets or sets the total.
    /// </summary>
    /// <value>The total.</value>
    [JsonProperty("total")]
    public long? Total { get; set; }

}

/// <summary>
/// Class TransactionTx.
/// </summary>
public class TransactionTx
{
    /// <summary>
    /// The identifier
    /// </summary>
    [JsonProperty("id")]
    public int Id;

    /// <summary>
    /// Address of the owner of the funds
    /// </summary>
    [JsonProperty("from")]
    public string From;

    /// <summary>
    /// The sender
    /// </summary>
    [JsonProperty("sender")]
    public string Sender;

    /// <summary>
    /// The receiver
    /// </summary>
    [JsonProperty("receiver")]
    public string Receiver;

    /// <summary>
    /// The coins
    /// </summary>
    [JsonProperty("coins")]
    public Coin Coins;

    /// <summary>
    /// The memo
    /// </summary>
    [JsonProperty("memo")]
    public string Memo;

    /// <summary>
    /// The block time
    /// </summary>
    [JsonProperty("block_time")]
    public int BlockTime;

    /// <summary>
    /// The block height
    /// </summary>
    [JsonProperty("block_height")]
    public int BlockHeight;

    /// <summary>
    /// TxAction has the following variants:
    /// Transfer - represents transactions triggered by Transfer, TransferFrom, Send, and SendFrom. The fields in this object correspond to the fields described in TransferHistory.
    /// see https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-21.md#Transaction-History
    /// </summary>
    [JsonProperty("action")]
    public object Action;

}