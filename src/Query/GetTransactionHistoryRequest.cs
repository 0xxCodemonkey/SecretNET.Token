#nullable enable
namespace SecretNET.Token;

/// <summary>
/// Class GetTransferHistoryRequest (JSON DTO).
/// </summary>
public class GetTransactionHistoryRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("transaction_history")]
    public GetTransactionHistoryRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetTransferHistoryRequest"/> class.
    /// </summary>
    /// <param name="pageSize">Number of transactions to return, starting from the latest. i.e. n=1 will return only the latest transaction.</param>
    /// <param name="page">This defaults to 0. Specifying a positive number will skip page * page_size txs from the start.</param>
    /// <param name="address">Addresses SHOULD be a valid bech32 address, but contracts may use a different naming scheme as well (only necessary if queried without permit).</param>
    /// <param name="viewingKey">The viewing key (only necessary if queried without permit).</param>
    public GetTransactionHistoryRequest(string address, string viewingKey, int pageSize, int? page = null)
    {
        Payload = new GetTransactionHistoryRequest_Payload
        {
            Address = address,
            ViewingKey = viewingKey,
            PageSize = pageSize,
            Page = page
        };
    }
}

/// <summary>
/// Class GetTransferHistoryRequest_Payload (JSON DTO).
/// </summary>
public class GetTransactionHistoryRequest_Payload
{
    /// <summary>
    /// Addresses SHOULD be a valid bech32 address, but contracts may use a different naming scheme as well (not optional).
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
    public string Address { get; set; }

    /// <summary>
    /// The viewing key (not optional).
    /// </summary>
    /// <value>The key.</value>
    [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewingKey { get; set; }

    /// <summary>
    /// Number of transactions to return, starting from the latest. i.e. n=1 will return only the latest transaction (not optional).
    /// </summary>
    /// <value>The size of the page.</value>
    [JsonProperty("page_size")]
    public int PageSize { get; set; }

    /// <summary>
    /// This defaults to 0. Specifying a positive number will skip page * page_size txs from the start.
    /// </summary>
    /// <value>The page.</value>
    [JsonProperty("page")]
    public int? Page { get; set; }
    
}

#nullable disable