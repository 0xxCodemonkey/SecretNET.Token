# Secret.NET Token (SNIP20) / Secret Token
**Secret.NET Token** is a layer on top of the [**Secret.NET client**](https://github.com/0xxCodemonkey/SecretNET) which supports all methods of the reference implementation of the SNIP20 contract.

**SecretNET.Token** provides typed and documented objects and methods that simplify interaction with a SNIP20 smart contract.  

- Implementation => [GitHub - scrtlabs/snip20-reference-impl](https://github.com/scrtlabs/snip20-reference-impl)
- Implementation of a [SNIP-20](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-20.md), [SNIP-21](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-21.md), [SNIP-22](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-22.md), [SNIP-23](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-23.md) and [SNIP-24](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-24.md) compliant token contract.
- See also the [SNIP20 documentation on Secret Network](https://docs.scrt.network/secret-network-documentation/development/snips/snip-20-spec-private-fungible-tokens).

**The [Secret Network blockchain](https://scrt.network/) (L1 / Cosmos), is the first privacy smart contract blockchain that processes and stores data on-chain in encrypted form (via Intel SGX).** 
This allows [unique use cases](https://docs.scrt.network/secret-network-documentation/secret-network-overview/use-cases) like Secret Token where you e.g., can hide balances and ownership of the token (optional).

:white_check_mark: **This repository is explicitly intended to serve as a template for custom SNIP20 token contracts.** 
This makes it easy to create your own customized clients for your own customized contracts.
**Of course, the concept can be used for any kind of smart contracts in general**.

## Full API-documentation
You can find the **full API-documentation** here => https://0xxcodemonkey.github.io/SecretNET.Token

# Table of Contents
- [Table of Contents](#table-of-contents)
- [Implementation](#implementation)
  - [Instantiating a SNIP20 Client](#instantiating-a-snip20-client)
  - [Usage](#usage)
- [Implemented methods](#implemented-methods)
  - [Queries](#queries)
  - [Transactions](#transactions)



# Implementation
The structure of **SecretNET.Token** is the same as the **SecretNET** client and transactions are accessible via ```Tx``` property and queries via ```Query``` property.

All transactions can also be simulated via ```Tx.Simulate```.

**All types and methods are documented and eases programming:**

![](resources/VS_IntelliSense.png)

## Instantiating a SNIP20 Client
To instantiate a **SecretNET.Token** client you just have to pass it a [SecretNET client instance](https://github.com/0xxCodemonkey/SecretNET#usage-examples):

```  csharp
var snip20Client =  new SecretNET.Token.Snip20Client(secretNetworkClient);
```
## Usage
All Methods can be easily called with the payload message like this:

```  csharp
var payloadSendMsg = new SecretNET.Token.SendRequest(recipientAddress, "1");
var sendMsg = new SecretNET.Token.MsgSend(
              payloadSendMsg, 
              snip20ContractAddress, 
              snip20CodeHash);
              
var sendResult = await snip20Client.Tx.Send(sendMsg, txOptions: txOptionsExecute);
```
Many methods also have an overload to make them even easier to call, like this

``` csharp
var sendResult = await snip20Client.Tx.Send(
              snip20ContractAddress, 
              recipientAddress, 
              "1", 
              codeHash: snip20CodeHash, 
              txOptions: txOptionsExecute);
```
# Implemented methods
- [Queries](#queries)
  - [GetAllowance](#getallowance)
  - [GetBalance](#getbalance)

## Queries
### GetAllowance
``` csharp
GetAllowance(
        string contractAddress, 
        string ownerAddress, 
        string spenderAddress, 
        Nullable<string> viewingKey,
        Nullable<Permit> permit,
        Nullable<string> codeHash
        );
```
Gets the allowance (This query MUST be authenticated). This returns the available allowance that spender can access from the owner's account, along with the expiration info. Every account's viewing key MUST be given permissions to query the allowance of any pair of owner and spender, as long as that account is either the owner or the spender in the query. In other words, every account's viewing key can be used to find out how much allowance the account has given other accounts, and how much it has been given by other accounts. The expiration field of the response may be either null or unset if no expiration has been set.

### GetBalance
``` csharp

```
### GetExchangeRate
``` csharp

```
### GetMinters
``` csharp

```
### GetTokenInfo
``` csharp

```
### GetTransferHistory
``` csharp

```

## Transactions
### Burn
``` csharp

```
### BurnFrom
``` csharp

```
### CreateViewingKey
``` csharp

```
### DecreaseAllowance
``` csharp

```
### Deposit
``` csharp

```
### IncreaseAllowance
``` csharp

```
### Instantiate (token contract)
``` csharp

```
### Mint
``` csharp

```
### Redeem
``` csharp

```
### RegisterReceive
``` csharp

```
### Send
``` csharp

```
### SendFrom
``` csharp

```
### SetMinters
``` csharp

```
### SetViewingKey
``` csharp

```
### Transfer
``` csharp

```
### TransferFrom
``` csharp

```
