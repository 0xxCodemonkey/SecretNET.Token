using Cosmos.Capability.V1Beta1;
using SecretNET.AccessControl;
using SecretNET.Tx;

namespace SecretNET.SNIP20;

/// <summary>
/// Class Snip20TxSimulate.
/// </summary>
public class Snip20TxSimulate
{
    // secret Network
    private TxClient _tx;

    /// <summary>
    /// Initializes a new instance of the <see cref="Snip20TxSimulate"/> class.
    /// </summary>
    /// <param name="tx">The TxClient.</param>
    public Snip20TxSimulate(TxClient tx)
    {
        _tx = tx;
    }

    // https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-20.md


    /// <summary>
    /// Generic simulates of an ExecuteContract message.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> GenericSimulate(MsgExecuteContractBase msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }


    /// <summary>
    /// Simulates "Transfer".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Transfer(MsgTransfer msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "Transfer".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="recipient">Account to send tokens to.</param>
    /// <param name="amount">Amount of tokens to transfer (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Transfer(string contractAddress, string recipient, string amount, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgTransfer(new TransferRequest(recipient, amount, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "Send".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Send(MsgSend msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }
    /// <summary>
    /// Simulates "Send".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="recipient">Accounts SHOULD be a valid bech32 address, but contracts may use a different naming scheme as well.</param>
    /// <param name="amount">The amount of tokens to send (Uint128).</param>
    /// <param name="message">Base64 encoded message, which the recipient will receive.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Send(string contractAddress, string recipient, string amount, string? message = null, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgSend(new SendRequest(recipient, amount, message, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "RegisterReceive".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> RegisterReceive(MsgRegisterReceive msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "RegisterReceive".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="receiverCodeHash">A 32-byte hex encoded string, with the code hash of the receiver contract.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">The code hash.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> RegisterReceive(string contractAddress, string receiverCodeHash, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgRegisterReceive(new RegisterReceiveRequest(receiverCodeHash, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "CreateViewingKey".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> CreateViewingKey(MsgCreateViewingKey msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "CreateViewingKey".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="entropy">String used as part of the entropy supplied to the rng that generates the random viewing key.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> CreateViewingKey(string contractAddress, string entropy, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgCreateViewingKey(new CreateViewingKeyRequest(entropy, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "SetViewingKey".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> SetViewingKey(MsgSetViewingKey msg, TxOptions? txOptions = null) 
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "SetViewingKey".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="viewingKey">The viewing key.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> SetViewingKey(string contractAddress, string viewingKey, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgSetViewingKey(new SetViewingKeyRequest(viewingKey), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "IncreaseAllowance".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> IncreaseAllowance(MsgIncreaseAllowance msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "IncreaseAllowance".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="spender">The address of the account getting access to the funds.</param>
    /// <param name="amount">The number of tokens to increase allowance by (Uint128).</param>
    /// <param name="expiration">Time at which the allowance expires.
    /// Counts the number of seconds from epoch, 1.1.1970 encoded as uint64.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> IncreaseAllowance(string contractAddress, string spender, string amount, int? expiration = null, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgIncreaseAllowance(new IncreaseAllowanceRequest(spender, amount, expiration, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "DecreaseAllowance".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> DecreaseAllowance(MsgDecreaseAllowance msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "DecreaseAllowance".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="spender">The address of the account getting access to the funds.</param>
    /// <param name="amount">The number of tokens to decrease allowance by (Uint128).</param>
    /// <param name="expiration">Time at which the allowance expires.
    /// Counts the number of seconds from epoch, 1.1.1970 encoded as uint64.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> DecreaseAllowance(string contractAddress, string spender, string amount, int? expiration = null, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgDecreaseAllowance(new DecreaseAllowanceRequest(spender, amount, expiration, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "TransferFrom".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> TransferFrom(MsgTransferFrom msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Transfers from.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="owner">Account to take tokens from.</param>
    /// <param name="recipient">Account to send tokens to.</param>
    /// <param name="amount">Amount of tokens to transfer (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> TransferFrom(string contractAddress, string owner, string recipient, string amount, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgTransferFrom(new TransferFromRequest(owner, recipient, amount, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "SendFrom".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> SendFrom(MsgSendFrom msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "SendFrom".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="owner">Account to take tokens from.</param>
    /// <param name="recipient">Account to send tokens to.</param>
    /// <param name="amount">Amount of tokens to transfer (Uint128).</param>
    /// <param name="message">Base64 encoded message, which the recipient will receive.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">The code hash.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> SendFrom(string contractAddress, string owner, string recipient, string amount, string? message = null, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgSendFrom(new SendFromRequest(owner, recipient, amount, message, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "Mint".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Mint(MsgMint msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "Mint".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="recipient">Account to mint tokens to.</param>
    /// <param name="amount">Amount of tokens to mint (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Mint(string contractAddress, string recipient, string amount, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgMint(new MintRequest(recipient, amount, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "SetMinters".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> SetMinters(MsgSetMinters msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "SetMinters".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="minterAddress">Address to allow minting.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> SetMinters(string contractAddress, string minterAddress, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgSetMinters(new SetMintersRequest(minterAddress, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "Burn".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Burn(MsgBurn msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "Burn".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="amount">The amount of tokens to burn (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Burn(string contractAddress, string amount, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgBurn(new BurnRequest(amount, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "BurnFrom".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> BurnFrom(MsgBurnFrom msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "BurnFrom".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="owner">Account to take tokens from.</param>
    /// <param name="amount">The amount of tokens to burn (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> BurnFrom(string contractAddress, string owner, string amount, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgBurnFrom(new BurnFromRequest(owner, amount, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "Deposit".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Deposit(MsgDeposit msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "Deposit".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="sentFunds">The sent funds.</param>
    /// <param name="padding">The padding.</param>
    /// <param name="codeHash">The code hash.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Deposit(string contractAddress, SecretNET.Tx.Coin[] sentFunds, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgDeposit(new DepositRequest(padding), sentFunds, contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "Redeem".
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Redeem(MsgRedeem msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

    /// <summary>
    /// Simulates "Redeem".
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="amount">The amount of tokens to redeem to (Uint128).</param>
    /// <param name="denom">Denom of tokens to mint. Only used if the contract supports multiple denoms.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Redeem(string contractAddress, string amount, string? denom = null, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgRedeem(new RedeemRequest(amount, denom, padding), contractAddress, codeHash);
        return await _tx.Simulate(msg, txOptions);
    }
}
