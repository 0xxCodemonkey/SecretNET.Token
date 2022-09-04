#nullable enable
namespace SecretNET.SNIP20;

/// <summary>
/// Class InstantiateSnip20 see => https://github.com/scrtlabs/snip20-reference-impl (JSON DTO).
/// </summary>
public class InstantiateSnip20
{
    /// <summary>
    /// The token name.
    /// </summary>
    /// <value>The name.</value>
    [JsonProperty("name")] 
    public string Name { get; set; }

    /// <summary>
    /// The token symbol.
    /// </summary>
    /// <value>The symbol.</value>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Number of decimals.
    /// </summary>
    /// <value>The decimals.</value>
    [JsonProperty("decimals")]
    public byte Decimals { get; set; }

    /// <summary>
    /// Seed as base64 encoded string.
    /// </summary>
    /// <value>The PRNG seed.</value>
    [JsonProperty("prng_seed")]
    public string PrngSeed { get; set; }

    /// <summary>
    /// Gets or sets the admin address.
    /// DEFAULT: Wallet / Sender address
    /// </summary>
    /// <value>The admin.</value>
    [JsonProperty("admin", NullValueHandling = NullValueHandling.Ignore)]
    public string Admin { get; set; }

    /// <summary>
    /// Gets or sets the initial balances.
    /// </summary>
    /// <value>The initial balances.</value>
    [JsonProperty("initial_balances", NullValueHandling = NullValueHandling.Ignore)]
    public List<InitBalance> InitialBalances { get; set; }

    /// <summary>
    /// Gets or sets the configuration.
    /// </summary>
    /// <value>The configuration.</value>
    [JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
    public ConfigSettings Config { get; set; }

 }

/// <summary>
/// Class InitBalance (JSON DTO).
/// </summary>
public class InitBalance
{
    /// <summary>
    /// Accounts SHOULD be a valid bech32 address, but contracts may use a different naming scheme as well.
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("address")]
    public string Address { get; set; }

    /// <summary>
    /// The amount of tokens to init (Uint128).
    /// </summary>
    /// <value>The amount.</value>
    [JsonProperty("amount")]
    public string Amount { get; set; }
}

/// <summary>
/// Class ConfigSettings (JSON DTO).
/// </summary>
public class ConfigSettings
{
    /// <summary>
    /// If you enable this, the token's total supply will be displayed whenever a TokenInfo query is performed. 
    /// DEFAULT: false
    /// </summary>
    /// <value><c>null</c> if [public total supply] contains no value, <c>true</c> if [public total supply]; otherwise, <c>false</c>.</value>
    [JsonProperty("public_total_supply", NullValueHandling = NullValueHandling.Ignore)]
    public bool? PublicTotalSupply { get; set; }

    /// <summary>
    /// If you enable this, you will be able to convert from SCRT to the token. 
    /// DEFAULT: false
    /// </summary>
    /// <value><c>true</c> if [enable deposit]; otherwise, <c>false</c>.</value>
    [JsonProperty("enable_deposit")]
    public bool EnableDeposit { get; set; }

    /// <summary>
    /// If you enable this, you will be able to redeem your token for SCRT.
    /// It should be noted that if you have redeem enabled, but deposit disabled, all redeem attempts will fail unless someone has sent SCRT to the token contract. 
    /// DEFAULT: false
    /// </summary>
    /// <value><c>true</c> if [enable redeem]; otherwise, <c>false</c>.</value>
    [JsonProperty("enable_redeem")]
    public bool EnableRedeem { get; set; }

    /// <summary>
    /// If you enable this, any address in the list of minters will be able to mint new tokens. 
    /// The admin address is the default minter, but can use the set/add/remove_minters functions to change the list of approved minting addresses. 
    /// DEFAULT: false
    /// </summary>
    /// <value><c>true</c> if [enable mint]; otherwise, <c>false</c>.</value>
    [JsonProperty("enable_mint")]
    public bool EnableMint { get; set; }

    /// <summary>
    /// If you enable this, addresses will be able to burn tokens. 
    /// DEFAULT: false
    /// </summary>
    /// <value><c>true</c> if [enable burn]; otherwise, <c>false</c>.</value>
    [JsonProperty("enable_burn")]
    public bool EnableBurn { get; set; }
}
