namespace SecretNET.SNIP20;

/// <summary>
/// Client for SNIP20 reference contract (https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-20.md / https://github.com/scrtlabs/snip20-reference-impl at 2022-07-11).
/// </summary>
public class Snip20Client
{
    SecretNetworkClient _secretNetworkClient = null;

    Snip20Querier _queries = null;
    Snip20Tx _txClient = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="Snip20Client"/> class.
    /// </summary>
    /// <param name="secretNetworkClient">The secret network client.</param>
    public Snip20Client(SecretNetworkClient secretNetworkClient)
	{
        _secretNetworkClient = secretNetworkClient;
    }

    /// <summary>
    /// SNIP20 Queries.
    /// </summary>
    /// <value>The query.</value>
    public Snip20Querier Query
    {
        get
        {
            if (_queries == null)
            {
                _queries = new Snip20Querier(_secretNetworkClient);
            }
            return _queries;
        }
    }

    /// <summary>
    /// SNIP20 Transactions.
    /// </summary>
    /// <value>The tx.</value>
    public Snip20Tx Tx
    {
        get
        {
            if (_txClient == null)
            {
                _txClient = new Snip20Tx(_secretNetworkClient.Tx);
            }
            return _txClient;
        }
    }
}
