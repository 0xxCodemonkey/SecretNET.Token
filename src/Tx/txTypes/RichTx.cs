namespace SecretNET.Token;

/// <summary>
/// Class RichTx (JSON DTO).
/// </summary>
public class RichTx
{
    /// <summary>
    /// Optional ID
    /// </summary>
    [JsonProperty("id")]
    public int Id;

    /// <summary>
    /// export type TxAction =
    /// | RedeemType
    /// | DepositType
    /// | MintType
    /// | BurnType
    /// | TransferType;
    /// </summary>
    [JsonProperty("action")]
    public object Action;

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

/// <summary>
/// Class TransferType (JSON DTO).
/// </summary>
public class TransferType
{
    /// <summary>
    /// Gets or sets the transfer.
    /// </summary>
    /// <value>The transfer.</value>
    [JsonProperty("transfer")]
    public TransferType_Transfer Transfer { get; set; }
}

/// <summary>
/// Class TransferType_Transfer (JSON DTO).
/// </summary>
public class TransferType_Transfer
{
    /// <summary>
    /// From
    /// </summary>
    [JsonProperty("from")]
    public string From;

    /// <summary>
    /// The sender
    /// </summary>
    [JsonProperty("sender")]
    public string Sender;

    /// <summary>
    /// The recipient
    /// </summary>
    [JsonProperty("recipient")]
    public string Recipient;
}

/// <summary>
/// Class MintType (JSON DTO).
/// </summary>
public class MintType
{
    /// <summary>
    /// Gets or sets the mint.
    /// </summary>
    /// <value>The mint.</value>
    [JsonProperty("mint")]
    public MintType_Mint Mint { get; set; }
}

/// <summary>
/// Class MintType_Mint (JSON DTO).
/// </summary>
public class MintType_Mint
{
    /// <summary>
    /// The minter
    /// </summary>
    [JsonProperty("minter")]
    public string Minter;

    /// <summary>
    /// The recipient
    /// </summary>
    [JsonProperty("recipient")]
    public string Recipient;
}

/// <summary>
/// Class BurnType (JSON DTO).
/// </summary>
public class BurnType
{
    /// <summary>
    /// Gets or sets the burn.
    /// </summary>
    /// <value>The burn.</value>
    [JsonProperty("burn")]
    public BurnType_Burn Burn { get; set; }
}

/// <summary>
/// Class BurnType_Burn (JSON DTO).
/// </summary>
public class BurnType_Burn
{
    /// <summary>
    /// The burner
    /// </summary>
    [JsonProperty("burner")]
    public string Burner;

    /// <summary>
    /// The owner
    /// </summary>
    [JsonProperty("owner")]
    public string Owner;
}

/// <summary>
/// Class DepositType (JSON DTO).
/// </summary>
public class DepositType
{
    /// <summary>
    /// Gets or sets the deposit.
    /// </summary>
    /// <value>The deposit.</value>
    [JsonProperty("deposit")]
    public object Deposit { get; set; }
}

/// <summary>
/// Class RedeemType (JSON DTO).
/// </summary>
public class RedeemType
{
    /// <summary>
    /// Gets or sets the redeem.
    /// </summary>
    /// <value>The redeem.</value>
    [JsonProperty("redeem")]
    public object Redeem { get; set; }
}