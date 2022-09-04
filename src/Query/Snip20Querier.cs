#nullable enable
using SecretNET.AccessControl;
using SecretNET.Query;

namespace SecretNET.SNIP20;

/// <summary>
/// Class Snip20Querier.
/// </summary>
public class Snip20Querier
{
    private SecretNetworkClient _secretNetworkClient;
    private ComputeQueryClient _computeQuery;

    /// <summary>
    /// Initializes a new instance of the <see cref="Snip20Querier"/> class.
    /// </summary>
    /// <param name="secretNetworkClient">The secret network client.</param>
    public Snip20Querier(SecretNetworkClient secretNetworkClient)
    {
        _secretNetworkClient = secretNetworkClient;
        _computeQuery = secretNetworkClient.Query.Compute;
    }

    /// <summary>
    /// Gets the token information (This query need not be authenticated).
    /// Returns the token info of the contract. The response MUST contain: token name, token symbol, and the number of decimals the token uses. 
    /// The response MAY additionally contain the total-supply of tokens. 
    /// This is to enable Layer-2 tokens which want to hide the amounts converted as well.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetTokenInfoResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetTokenInfoResponse>> GetTokenInfo(string contractAddress, string? codeHash = null) 
    {
        var request = new GetTokenInfoRequest();

        var result = await _computeQuery.QueryContract<GetTokenInfoResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// Gets the balance (This query MUST be authenticated).
    /// Returns the balance of the given address. Returns "0" if the address is unknown to the contract.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="walletAddress">The wallet address.</param>
    /// <param name="viewingKey">Authenticate with viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetBalanceResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetBalanceResponse>> GetBalance(string contractAddress, string? walletAddress = null, string? viewingKey = null, Permit? permit = null, string? codeHash = null)
    {
        var request = new GetBalanceRequest(walletAddress ?? _secretNetworkClient.WalletAddress, viewingKey);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.Address = null;     // extracted from permit
            request.Payload.ViewingKey = null;  // not necessary / possible when using permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetBalanceResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// Gets the transfer history (This query MUST be authenticated).
    /// This query SHOULD return a list of json objects describing the transactions made by the querying address, in newest-first order.
    /// The user may optionally specify a limit on the amount of information returned by paging the available items.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="pageSize">Number of transactions to return, starting from the latest. i.e. n=1 will return only the latest transaction..</param>
    /// <param name="page">This defaults to 0. Specifying a positive number will skip page * page_size txs from the start.</param>
    /// <param name="walletAddress">The wallet address.</param>
    /// <param name="viewingKey">Authenticate with viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetTransferHistoryResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetTransferHistoryResponse>> GetTransferHistory(string contractAddress, int pageSize, int? page = null, string? walletAddress = null, string? viewingKey = null, Permit? permit = null, string? codeHash = null)
    {
        var request = new GetTransferHistoryRequest(pageSize, page, walletAddress ?? _secretNetworkClient.WalletAddress, viewingKey);

        object queryMsg = null;
        if (permit == null)
        {            
            queryMsg = request;
        }
        else
        {
            request.Payload.Address = null;     // extracted from permit
            request.Payload.ViewingKey = null;  // not necessary / possible when using permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetTransferHistoryResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// Gets the allowance (This query MUST be authenticated).
    /// This returns the available allowance that spender can access from the owner's account, along with the expiration info.
    /// 
    /// Every account's viewing key MUST be given permissions to query the allowance of any pair of owner and spender, as long as that account is either the owner or the spender in the query. 
    /// In other words, every account's viewing key can be used to find out how much allowance the account has given other accounts, and how much it has been given by other accounts.
    /// The expiration field of the response may be either null or unset if no expiration has been set.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="ownerAddress">Account from which tokens are allowed to be taken.</param>
    /// <param name="spenderAddress">Account which is allowed to spend tokens on behalf of the owner.</param>
    /// <param name="viewingKey">Authenticate with viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetAllowanceResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetAllowanceResponse>> GetAllowance(string contractAddress, string ownerAddress, string spenderAddress, string? viewingKey = null, Permit? permit = null, string? codeHash = null)
    {
        var request = new GetAllowanceRequest(ownerAddress, spenderAddress, viewingKey);

        object queryMsg = null;
        if (permit == null)
        {            
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewingKey = null;  // not necessary / possible when using permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetAllowanceResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// Returns the list of minters that have been configured in the contract (This query need not be authenticated).
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetMintersResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetMintersResponse>> GetMinters(string contractAddress, string? codeHash = null)
    {
        var request = new GetMintersRequest();

        var result = await _computeQuery.QueryContract<GetMintersResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// Gets information about the token exchange rate functionality that the contract provides (This query need not be authenticated).
    /// This query MUST return.
    /// - exchange rate, as an integer string. The amount of native coins that equal one token.
    /// - Denomination of native tokens which are acceptable, as a string OR a comma separated value.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetExchangeRateResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetExchangeRateResponse>> GetExchangeRate(string contractAddress, string? codeHash = null)
    {
        var request = new GetExchangeRateRequest();

        var result = await _computeQuery.QueryContract<GetExchangeRateResponse>(contractAddress, request, codeHash);
        return result;
    }

}
#nullable disable