<!--  ![Nuget](https://img.shields.io/nuget/v/SecretNET.Token?label=stable) ![GitHub](https://img.shields.io/github/license/0xxCodemonkey/SecretNET.Token) ![GitHub Workflow Status](https://img.shields.io/github/workflow/status/0xxCodemonkey/SecretNET.Token/Publish%20Packages?label=checks) -->
![GitHub](https://img.shields.io/github/license/0xxCodemonkey/SecretNET.Token) ![Nuget](https://img.shields.io/nuget/dt/SecretNET.Token?color=%239100ff) [![NuGet version (SecretNET.Token)](https://img.shields.io/nuget/v/SecretNET.Token.svg?style=flat-square)](https://www.nuget.org/packages/SecretNET.Token/)

*Status: (Project is in active development)*
<br/><br/>

# Secret.NET Token (SNIP20) / Secret Token
**Secret.NET Token** is a layer on top of the [**Secret.NET client**](https://github.com/0xxCodemonkey/SecretNET) which supports all methods of the reference implementation of the SNIP20 contract.

**The [Secret Network blockchain](https://scrt.network/) (L1 / Cosmos), is the first privacy smart contract blockchain that processes and stores data on-chain in encrypted form (via Intel SGX).** 
This allows [unique use cases](https://docs.scrt.network/secret-network-documentation/secret-network-overview/use-cases) like **Secret Token** where you e.g., can hide balances and ownership of the token (optional).

![ ](https://raw.githubusercontent.com/0xxCodemonkey/SecretNET/main/resources/Secret.NET_banner.png)

**SecretNET.Token** provides typed and documented objects and methods that simplify interaction with a SNIP20 smart contract.  

- Implementation => [GitHub - scrtlabs/snip20-reference-impl](https://github.com/scrtlabs/snip20-reference-impl)
- Implementation of a [SNIP-20](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-20.md), [SNIP-21](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-21.md), [SNIP-22](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-22.md), [SNIP-23](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-23.md) and [SNIP-24](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-24.md) compliant token contract.
- See also the [SNIP20 documentation on Secret Network](https://docs.scrt.network/secret-network-documentation/development/snips/snip-20-spec-private-fungible-tokens).

:white_check_mark: **This repository is explicitly intended to serve as a template for custom SNIP20 token contracts.** 
This makes it easy to create your own customized clients for your own customized contracts.
Of course, the concept can be used for any kind of smart contracts in general.

## Links
- [GitHub](https://github.com/0xxCodemonkey/SecretNET.Token)
- [Secret Network - Secret Network is the first blockchain with customizable privacy](https://scrt.network/).
- [Secret Network - Documentation](https://docs.scrt.network/secret-network-documentation/)