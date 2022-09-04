namespace SecretNET.SNIP20;

/// <summary>
/// Class Tx (JSON DTO).
/// </summary>
public class Tx
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

}

