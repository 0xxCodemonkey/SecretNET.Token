using Cosmos.Capability.V1Beta1;
using Ibc.Core.Channel.V1;
using SecretNET.AccessControl;
using SecretNET.Tx;

namespace SecretNET.Token;

/// <summary>
/// Client for SNIP20 reference contract (https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-20.md at 2022-07-11).
/// </summary>
public class Snip20Tx
{
    // secret Network
    private TxClient _tx;
    private Snip20TxSimulate _txSimulte;

    /// <summary>
    /// Initializes a new instance of the <see cref="Snip20Tx"/> class.
    /// </summary>
    /// <param name="tx">The TxClient.</param>
    public Snip20Tx(TxClient tx)
    {
        _tx = tx;
        _txSimulte = new Snip20TxSimulate(tx);
    }

    /// <summary>
    /// Simulate Transaction
    /// </summary>
    /// <value>The simulate.</value>
    public Snip20TxSimulate Simulate
    {
        get { return _txSimulte; }
    }

    // https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-20.md

    /// <summary>
    /// Instantiates / configures the Token contract (https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-20.md at 2022-07-11).
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<SingleSecretTx<Secret.Compute.V1Beta1.MsgInstantiateContractResponse>> Instantiate(MsgInstantiate msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.InstantiateContract(msg, txOptions);
    }

    /// <summary>
    /// Moves tokens from the account that appears in the Cosmos message sender field to the account in the recipient field.
    /// 
    /// Variation from CW-20: It is NOT required to validate that the recipient is an address and not a contract. This command will work when trying to send funds to contract accounts as well.
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<SingleSecretTx<TransferResponse>> Transfer(MsgTransfer msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<TransferResponse>(msg, txOptions);
    }

    /// <summary>
    /// Moves tokens from the account that appears in the Cosmos message sender field to the account in the recipient field.
    /// 
    /// Variation from CW-20: It is NOT required to validate that the recipient is an address and not a contract. This command will work when trying to send funds to contract accounts as well.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="recipient">Account to send tokens to.</param>
    /// <param name="amount">Amount of tokens to transfer (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;TransferResponse&gt;.</returns>
    public async Task<SingleSecretTx<TransferResponse>> Transfer(string contractAddress, string recipient, string amount, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgTransfer(new TransferRequest(recipient, amount, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<TransferResponse>(msg, txOptions);
    }

    /// <summary>
    /// Moves amount from the Cosmos message sender account to the recipient account. The receiver account MAY be a contract that has registered itself using a RegisterReceive message. If such a registration has been performed, a message MUST be sent to the contract's address as a callback, after completing the transfer. The format of this message is described under Receiver interface.
    ///
    /// If the callback fails due to an error in the Receiver contract, the entire transaction will be reverted.
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<SingleSecretTx<SendResponse>> Send(MsgSend msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SendResponse>(msg, txOptions);
    }

    /// <summary>
    /// Moves amount from the Cosmos message sender account to the recipient account. The receiver account MAY be a contract that has registered itself using a RegisterReceive message. If such a registration has been performed, a message MUST be sent to the contract's address as a callback, after completing the transfer. The format of this message is described under Receiver interface.
    ///
    /// If the callback fails due to an error in the Receiver contract, the entire transaction will be reverted.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="recipient">Accounts SHOULD be a valid bech32 address, but contracts may use a different naming scheme as well.</param>
    /// <param name="amount">The amount of tokens to send (Uint128).</param>
    /// <param name="message">Base64 encoded message, which the recipient will receive.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;SendResponse&gt;.</returns>
    public async Task<SingleSecretTx<SendResponse>> Send(string contractAddress, string recipient, string amount, string? message = null, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgSend(new SendRequest(recipient, amount, message, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<SendResponse>(msg, txOptions);
    }

    /// <summary>
    /// This message is used to tell the SNIP-20 contract to call the Receive function of the Cosmos message sender after a successful Send.
    /// 
    /// In Secret Network this is used to pair a code hash with the contract address that must be called. 
    /// This means that the SNIP-20 MUST store the sent code_hash and use it when calling the Receive function.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SecretTx&lt;RegisterReceiveResponse&gt;.</returns>
    public async Task<SingleSecretTx<RegisterReceiveResponse>> RegisterReceive(MsgRegisterReceive msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<RegisterReceiveResponse>(msg, txOptions);
    }

    /// <summary>
    /// This message is used to tell the SNIP-20 contract to call the Receive function of the Cosmos message sender after a successful Send.
    /// 
    /// In Secret Network this is used to pair a code hash with the contract address that must be called. 
    /// This means that the SNIP-20 MUST store the sent code_hash and use it when calling the Receive function.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="receiverCodeHash">A 32-byte hex encoded string, with the code hash of the receiver contract.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;RegisterReceiveResponse&gt;.</returns>
    public async Task<SingleSecretTx<RegisterReceiveResponse>> RegisterReceive(string contractAddress, string receiverCodeHash, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgRegisterReceive(new RegisterReceiveRequest(receiverCodeHash, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<RegisterReceiveResponse>(msg, txOptions);
    }

    /// <summary>
    /// This function generates a new viewing key for the Cosmos message sender, which is used in ALL account specific queries. This key is used to validate the identity of the caller, 
    /// since in queries in Cosmos there is no way to cryptographically authenticate the querier's identity.
    /// 
    /// The Viewing Key MUST be stored in such a way that lookup takes a significant amount to time to perform, in order to be resistant to brute-force attacks.
    /// The viewing key MUST NOT control any functions which actively affect the balance of the user.
    /// 
    /// The entropy field of the request should be a client supplied string used for entropy for generation of the viewing key.Secure implementation is left to the client, 
    /// but it is recommended to use base-64 encoded random bytes and not predictable inputs.
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<SingleSecretTx<CreateViewingKeyResponse>> CreateViewingKey(MsgCreateViewingKey msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<CreateViewingKeyResponse>(msg, txOptions);
    }

    /// <summary>
    /// This function generates a new viewing key for the Cosmos message sender, which is used in ALL account specific queries. This key is used to validate the identity of the caller, 
    /// since in queries in Cosmos there is no way to cryptographically authenticate the querier's identity.
    /// 
    /// The Viewing Key MUST be stored in such a way that lookup takes a significant amount to time to perform, in order to be resistant to brute-force attacks.
    /// The viewing key MUST NOT control any functions which actively affect the balance of the user.
    /// 
    /// The entropy field of the request should be a client supplied string used for entropy for generation of the viewing key.Secure implementation is left to the client, 
    /// but it is recommended to use base-64 encoded random bytes and not predictable inputs.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="entropy">String used as part of the entropy supplied to the rng that generates the random viewing key.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;CreateViewingKeyResponse&gt;.</returns>
    public async Task<SingleSecretTx<CreateViewingKeyResponse>> CreateViewingKey(string contractAddress, string entropy, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgCreateViewingKey(new CreateViewingKeyRequest(entropy, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<CreateViewingKeyResponse>(msg, txOptions);
    }

    /// <summary>
    /// Set a viewing key with a predefined value for Cosmos message sender, without creating it. This is useful to manage multiple SNIP-20 tokens using the same viewing key.
    /// If a viewing key is already set, the contract MUST replace the current key.If a viewing key is not set, the contract MUST set the provided key as the viewing key.
    /// It is NOT RECOMMENDED to use this function to create easy to remember passwords for users, but this is left up to implementors to enforce.
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<SingleSecretTx<SetViewingKeyResponse>> SetViewingKey(MsgSetViewingKey msg, TxOptions? txOptions = null) 
    {
        return await _tx.Compute.ExecuteContract<SetViewingKeyResponse>(msg, txOptions);
    }

    /// <summary>
    /// Set a viewing key with a predefined value for Cosmos message sender, without creating it. This is useful to manage multiple SNIP-20 tokens using the same viewing key.
    /// If a viewing key is already set, the contract MUST replace the current key.If a viewing key is not set, the contract MUST set the provided key as the viewing key.
    /// It is NOT RECOMMENDED to use this function to create easy to remember passwords for users, but this is left up to implementors to enforce.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="viewingKey">The viewing key.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SecretTx&lt;SetViewingKeyResponse&gt;.</returns>
    public async Task<SingleSecretTx<SetViewingKeyResponse>> SetViewingKey(string contractAddress, string viewingKey, string? padding = null, string? codeHash = null, TxOptions ? txOptions = null) 
    {
        var msg = new MsgSetViewingKey(new SetViewingKeyRequest(viewingKey), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<SetViewingKeyResponse>(msg, txOptions);
    }

    /// <summary>
    /// Set or increase the allowance such that spender may access up to current_allowance + amount tokens from the Cosmos message sender account. 
    /// This may optionally come with an expiration time, which if set limits when the approval can be used (by time).
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<SingleSecretTx<IncreaseAllowanceResponse>> IncreaseAllowance(MsgIncreaseAllowance msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<IncreaseAllowanceResponse>(msg, txOptions);
    }

    /// <summary>
    /// Set or increase the allowance such that spender may access up to current_allowance + amount tokens from the Cosmos message sender account. 
    /// This may optionally come with an expiration time, which if set limits when the approval can be used (by time).
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="spender">The address of the account getting access to the funds.</param>
    /// <param name="amount">The number of tokens to increase allowance by (Uint128).</param>
    /// <param name="expiration">Time at which the allowance expires.
    /// Counts the number of seconds from epoch, 1.1.1970 encoded as uint64.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;IncreaseAllowanceResponse&gt;.</returns>
    public async Task<SingleSecretTx<IncreaseAllowanceResponse>> IncreaseAllowance(string contractAddress, string spender, string amount, int? expiration = null, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgIncreaseAllowance(new IncreaseAllowanceRequest(spender, amount, expiration, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<IncreaseAllowanceResponse>(msg, txOptions);
    }

    /// <summary>
    /// Decrease or clear the allowance by a sent amount. This may optionally come with an expiration time, which if set limits when the approval can be used. 
    /// If amount is equal or greater than the current allowance, this action MUST set the allowance to zero, and return a "success" response.
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<SingleSecretTx<DecreaseAllowanceResponse>> DecreaseAllowance(MsgDecreaseAllowance msg, TxOptions? txOptions = null)
    {        
        return await _tx.Compute.ExecuteContract<DecreaseAllowanceResponse>(msg, txOptions);
    }

    /// <summary>
    /// Decrease or clear the allowance by a sent amount. This may optionally come with an expiration time, which if set limits when the approval can be used. 
    /// If amount is equal or greater than the current allowance, this action MUST set the allowance to zero, and return a "success" response.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="spender">The address of the account getting access to the funds.</param>
    /// <param name="amount">The number of tokens to decrease allowance by (Uint128).</param>
    /// <param name="expiration">Time at which the allowance expires.
    /// Counts the number of seconds from epoch, 1.1.1970 encoded as uint64.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;DecreaseAllowanceResponse&gt;.</returns>
    public async Task<SingleSecretTx<DecreaseAllowanceResponse>> DecreaseAllowance(string contractAddress, string spender, string amount, int? expiration = null, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgDecreaseAllowance(new DecreaseAllowanceRequest(spender, amount, expiration, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<DecreaseAllowanceResponse>(msg, txOptions);
    }

    /// <summary>
    /// Transfer an amount of tokens from a specified account, to another specified account. 
    /// This action MUST fail if the Cosmos message sender does not have an allowance limit that is equal or greater than the amount of tokens sent for the owner account.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SecretTx&lt;TransferFromResponse&gt;.</returns>
    public async Task<SingleSecretTx<TransferFromResponse>> TransferFrom(MsgTransferFrom msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<TransferFromResponse>(msg, txOptions);
    }

    /// <summary>
    /// Transfer an amount of tokens from a specified account, to another specified account. 
    /// This action MUST fail if the Cosmos message sender does not have an allowance limit that is equal or greater than the amount of tokens sent for the owner account.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="owner">Account to take tokens from.</param>
    /// <param name="recipient">Account to send tokens to.</param>
    /// <param name="amount">Amount of tokens to transfer (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;TransferFromResponse&gt;.</returns>
    public async Task<SingleSecretTx<TransferFromResponse>> TransferFrom(string contractAddress, string owner, string recipient, string amount, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgTransferFrom(new TransferFromRequest(owner, recipient, amount, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<TransferFromResponse>(msg, txOptions);
    }

    /// <summary>
    /// SendFrom is to Send, what TransferFrom is to Transfer. 
    /// This allows a pre-approved account to not just transfer the tokens, but to send them to another address to trigger a given action. 
    /// Note SendFrom will set the Receive{sender} to be the env.message.sender (the account that triggered the transfer) rather than the owner account (the account the money is coming from).
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SecretTx&lt;SendFromResponse&gt;.</returns>
    public async Task<SingleSecretTx<SendFromResponse>> SendFrom(MsgSendFrom msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SendFromResponse>(msg, txOptions);
    }

    /// <summary>
    /// SendFrom is to Send, what TransferFrom is to Transfer. 
    /// This allows a pre-approved account to not just transfer the tokens, but to send them to another address to trigger a given action. 
    /// Note SendFrom will set the Receive{sender} to be the env.message.sender (the account that triggered the transfer) rather than the owner account (the account the money is coming from).
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="owner">Account to take tokens from.</param>
    /// <param name="recipient">Account to send tokens to.</param>
    /// <param name="amount">Amount of tokens to transfer (Uint128).</param>
    /// <param name="message">Base64 encoded message, which the recipient will receive.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;SendFromResponse&gt;.</returns>
    public async Task<SingleSecretTx<SendFromResponse>> SendFrom(string contractAddress, string owner, string recipient, string amount, string? message = null, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgSendFrom(new SendFromRequest(owner, recipient, amount, message, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<SendFromResponse>(msg, txOptions);
    }

    /// <summary>
    /// This function MUST be allowed only for accounts on the minters list.
    /// If the Cosmos message sender is an allowed minter, this will create amount new tokens and add them to the balance of recipient.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SecretTx&lt;MintResponse&gt;.</returns>
    public async Task<SingleSecretTx<MintResponse>> Mint(MsgMint msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<MintResponse>(msg, txOptions);
    }

    /// <summary>
    /// This function MUST be allowed only for accounts on the minters list.
    /// If the Cosmos message sender is an allowed minter, this will create amount new tokens and add them to the balance of recipient.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="recipient">Account to mint tokens to.</param>
    /// <param name="amount">Amount of tokens to mint (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;MintResponse&gt;.</returns>
    public async Task<SingleSecretTx<MintResponse>> Mint(string contractAddress, string recipient, string amount, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgMint(new MintRequest(recipient, amount, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<MintResponse>(msg, txOptions);
    }

    /// <summary>
    /// This function MUST only be allowed for authorized accounts.
    /// The list of addresses in the message will be set to the list of minters in the contract. This completely overrides the previously saved list.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SecretTx&lt;SetMintersResponse&gt;.</returns>
    public async Task<SingleSecretTx<SetMintersResponse>> SetMinters(MsgSetMinters msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SetMintersResponse>(msg, txOptions);
    }

    /// <summary>
    /// This function MUST only be allowed for authorized accounts.
    /// The list of addresses in the message will be set to the list of minters in the contract. This completely overrides the previously saved list.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="minterAddress">Address to allow minting.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;SetMintersResponse&gt;.</returns>
    public async Task<SingleSecretTx<SetMintersResponse>> SetMinters(string contractAddress, string minterAddress, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgSetMinters(new SetMintersRequest(minterAddress, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<SetMintersResponse>(msg, txOptions);
    }

    /// <summary>
    /// MUST remove amount tokens from the balance of the Cosmos message sender and MUST reduce the total supply by the same amount. 
    /// MUST NOT transfer the funds to another account.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;BurnResponse&gt;.</returns>
    public async Task<SingleSecretTx<BurnResponse>> Burn(MsgBurn msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<BurnResponse>(msg, txOptions);
    }

    /// <summary>
    /// MUST remove amount tokens from the balance of the Cosmos message sender and MUST reduce the total supply by the same amount. 
    /// MUST NOT transfer the funds to another account.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="amount">The amount of tokens to burn (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;BurnResponse&gt;.</returns>
    public async Task<SingleSecretTx<BurnResponse>> Burn(string contractAddress, string amount, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgBurn(new BurnRequest(amount, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<BurnResponse>(msg, txOptions);
    }

    /// <summary>
    /// This works like TransferFrom, but burns the tokens instead of transferring them. 
    /// This will reduce the owner's balance, total_supply and the caller's allowance.
    /// 
    /// This function should be available when a contract supports both the Mintable and Allowances interfaces.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;BurnFromResponse&gt;.</returns>
    public async Task<SingleSecretTx<BurnFromResponse>> BurnFrom(MsgBurnFrom msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<BurnFromResponse>(msg, txOptions);
    }

    /// <summary>
    /// This works like TransferFrom, but burns the tokens instead of transferring them. 
    /// This will reduce the owner's balance, total_supply and the caller's allowance.
    /// 
    /// This function should be available when a contract supports both the Mintable and Allowances interfaces.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="owner">Account to take tokens from.</param>
    /// <param name="amount">The amount of tokens to burn (Uint128).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;BurnFromResponse&gt;.</returns>
    public async Task<SingleSecretTx<BurnFromResponse>> BurnFrom(string contractAddress, string owner, string amount, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgBurnFrom(new BurnFromRequest(owner, amount, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<BurnFromResponse>(msg, txOptions);
    }

    /// <summary>
    /// Deposits a native coin into the contract, which will mint an equivalent amount of tokens to be created. 
    /// The amount MUST be sent in the sent_funds field of the transaction itself, as coins must really be sent to the contract's native address. 
    /// The minted amounts MUST match the exchange rate specified by the ExchangeRate query. 
    /// The deposit MUST return an error if any coins that do not match expected denominations are sent.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;DepositResponse&gt;.</returns>
    public async Task<SingleSecretTx<DepositResponse>> Deposit(MsgDeposit msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<DepositResponse>(msg, txOptions);
    }

    /// <summary>
    /// Deposits a native coin into the contract, which will mint an equivalent amount of tokens to be created. 
    /// The amount MUST be sent in the sent_funds field of the transaction itself, as coins must really be sent to the contract's native address. 
    /// The minted amounts MUST match the exchange rate specified by the ExchangeRate query. 
    /// The deposit MUST return an error if any coins that do not match expected denominations are sent.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="sentFunds">The sent funds.</param>
    /// <param name="padding">The padding.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;DepositResponse&gt;.</returns>
    public async Task<SingleSecretTx<DepositResponse>> Deposit(string contractAddress, SecretNET.Tx.Coin[] sentFunds, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgDeposit(new DepositRequest(padding), sentFunds, contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<DepositResponse>(msg, txOptions);
    }

    /// <summary>
    /// Redeems tokens in exchange for native coins. 
    /// The redeemed tokens SHOULD be burned, and taken out of the pool.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;RedeemResponse&gt;.</returns>
    public async Task<SingleSecretTx<RedeemResponse>> Redeem(MsgRedeem msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<RedeemResponse>(msg, txOptions);
    }

    /// <summary>
    /// Redeems tokens in exchange for native coins. 
    /// The redeemed tokens SHOULD be burned, and taken out of the pool.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="amount">The amount of tokens to redeem to (Uint128).</param>
    /// <param name="denom">Denom of tokens to mint. Only used if the contract supports multiple denoms.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;RedeemResponse&gt;.</returns>
    public async Task<SingleSecretTx<RedeemResponse>> Redeem(string contractAddress, string amount, string? denom = null, string? padding = null, string? codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgRedeem(new RedeemRequest(amount, denom, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<RedeemResponse>(msg, txOptions);
    }
}
