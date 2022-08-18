# SecretNET.SNIP20 / Token
**SecretNET.SNIP20** is a layer on top of the [**SecretNET client**](https://github.com/0xxCodemonkey/SecretNET) which supports all methods of the reference implementation of the SNIP20 contract:
- Implementation => [GitHub - scrtlabs/snip20-reference-impl](https://github.com/scrtlabs/snip20-reference-impl)
- Implementation of a [SNIP-20](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-20.md), [SNIP-21](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-21.md), [SNIP-22](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-22.md), [SNIP-23](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-23.md) and [SNIP-24](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-24.md) compliant token contract.

:white_check_mark: **This repository is explicitly intended to serve as a template for custom SNIP20 token contracts.** 
This makes it easy to create your own customized clients for your own customized contracts.
Of course, the concept can be used for any kind of smart contracts in general.

# Table of Contents
- [Table of Contents](#table-of-contents)
- [Implementation](#implementation)
  - [Instantiating a SNIP20 Client](#instantiating-a-snip20-client)
  - [Usage](#usage)
- [Implemented methods](#implemented-methods)
  - [Queries](#queries)
  - [Transactions](#transactions)

# Implementation
The structure of SecretNET.SNIP20 is the same as the SecretNET client and transactions are accessible via ```Tx``` property and queries via ```Query``` property.

All transactions can also be simulated via ```Tx.Simulate```.

## Instantiating a SNIP20 Client
To instantiate a SecretNET.SNIP20 client you just have to pass it a SecretNET client instance:

```  csharp
var snip20Client =  new SecretNET.SNIP20.Snip20Client(secretNetworkClient);
```
## Usage
All Methods can be easily called with the payload message like this:

```  csharp
var payloadSendMsg = new SecretNET.SNIP20.SendRequest(recipientAddress, "1");
var sendMsg = new SecretNET.SNIP20.MsgSend(
              payloadSendMsg, 
              snip20ContractAddress, 
              snip20CodeHash);
              
var sendResult = await snip20Client.Tx.Send(sendMsg, txOptions: txOptionsExecute);
```
Many methods also have an overload to make them even easier to call, like this

```  csharp
var sendResult = await snip20Client.Tx.Send(
              snip20ContractAddress, 
              recipientAddress, 
              "1", 
              codeHash: snip20CodeHash, 
              txOptions: txOptionsExecute);
```
# Implemented methods
## Queries
- GetAllowance
- GetBalance
- GetExchangeRate
- GetMinters
- GetTokenInfo
- GetTransferHistory

## Transactions
- Burn
- BurnFrom
- CreateViewingKey
- DecreaseAllowance
- Deposit
- IncreaseAllowance
- Instantiate (token contract)
- Mint
- Redeem
- RegisterReceive
- Send
- SendFrom
- SetMinters
- SetViewingKey
- Transfer
- TransferFrom
