#nullable enable
using SecretNET.Tx;
using SecretNET.AccessControl;

namespace SecretNET.Token;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Type parameter declaration must be an identifier not a type. See also error CS0081

public class MsgInstantiate : MsgInstantiateContract
{
    public MsgInstantiate(
        ulong codeId,
        string label,
        InstantiateSnip20 initOptions,
        string? codeHash = null,
        string? sender = null) : base(codeId, label, initOptions, codeHash, sender)
    {

    }
}

public class MsgTransfer : MsgExecuteContract<TransferRequest>
{
    public MsgTransfer(
        TransferRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSend : MsgExecuteContract<SendRequest>
{
    public MsgSend(
        SendRequest msg, 
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ):base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgRegisterReceive : MsgExecuteContract<RegisterReceiveRequest>
{
    public MsgRegisterReceive(
        RegisterReceiveRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgCreateViewingKey : MsgExecuteContract<CreateViewingKeyRequest>
{
    public MsgCreateViewingKey(
        CreateViewingKeyRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSetViewingKey : MsgExecuteContract<SetViewingKeyRequest>
{
    public MsgSetViewingKey(
        SetViewingKeyRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgIncreaseAllowance : MsgExecuteContract<IncreaseAllowanceRequest>
{
    public MsgIncreaseAllowance(
        IncreaseAllowanceRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgDecreaseAllowance : MsgExecuteContract<DecreaseAllowanceRequest>
{
    public MsgDecreaseAllowance(
        DecreaseAllowanceRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgTransferFrom : MsgExecuteContract<TransferFromRequest>
{
    public MsgTransferFrom(
        TransferFromRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSendFrom : MsgExecuteContract<SendFromRequest>
{
    public MsgSendFrom(
        SendFromRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgMint : MsgExecuteContract<MintRequest>
{
    public MsgMint(
        MintRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSetMinters : MsgExecuteContract<SetMintersRequest>
{
    public MsgSetMinters(
        SetMintersRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgBurn : MsgExecuteContract<BurnRequest>
{
    public MsgBurn(
        BurnRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgBurnFrom : MsgExecuteContract<BurnFromRequest>
{
    public MsgBurnFrom(
        BurnFromRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgDeposit : MsgExecuteContract<DepositRequest>
{
    public MsgDeposit(
        DepositRequest msg,
        SecretNET.Tx.Coin[] sentFunds,
        string contractAddress,
        string? codeHash = null,
        string? sender = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}


/// <summary>
/// "Redeem" execute contract message.
/// Implements the <see cref="SecretNET.Tx.MsgExecuteContract{SNIP20.RedeemRequest}" />
/// </summary>
/// <seealso cref="SecretNET.Tx.MsgExecuteContract{SNIP20.RedeemRequest}" />
public class MsgRedeem : MsgExecuteContract<RedeemRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MsgRedeem"/> class.
    /// </summary>
    /// <param name="msg">The JSON Request.</param>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="codeHash">The code hash.</param>
    /// <param name="sender">The sender.</param>
    /// <param name="sentFunds">The sent funds.</param>
    public MsgRedeem(
        RedeemRequest msg,
        string contractAddress,
        string? codeHash = null,
        string? sender = null,
        SecretNET.Tx.Coin[]? sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}
#pragma warning restore CS1658 // Type parameter declaration must be an identifier not a type. See also error CS0081
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute

#nullable disable