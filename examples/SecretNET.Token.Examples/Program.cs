global using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text;

// SecretNET
using SecretNET;
using SecretNET.Tx;
using SecretNET.Common;
using SecretNET.Common.Storage;
using SecretNET.Token;



// See https://aka.ms/new-console-template for more information

#region *** Helper functions / Objects ***

Action<string> writeHeadline = (text) =>
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"\r\n**************** {text} ****************\r\n");
    Console.ForegroundColor = ConsoleColor.White;
};

Action<string, SecretTx> logSecretTx = (name, tx) =>
{
    Console.WriteLine($"{name} Txhash: {tx?.Txhash}");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine($"(Gas used: {tx.GasUsed} - Gas wanted {tx.GasWanted})");
    Console.ForegroundColor = ConsoleColor.White;

    //Console.WriteLine($"\r\nCodeId: {JsonConvert.SerializeObject(tx.GetResponseJson(), Formatting.Indented)}");

    if (tx is SingleSecretTx<Secret.Compute.V1Beta1.MsgStoreCodeResponse>)
    {
        Console.WriteLine($"\r\nCodeId: {((SingleSecretTx<Secret.Compute.V1Beta1.MsgStoreCodeResponse>)tx).Response.CodeId}");
    }

    if (tx is SingleSecretTx<Secret.Compute.V1Beta1.MsgInstantiateContractResponse>)
    {
        Console.WriteLine($"\r\nContractAddress: {((SingleSecretTx<Secret.Compute.V1Beta1.MsgInstantiateContractResponse>)tx)?.Response?.Address}");
    }

    if (tx != null && (tx.Code > 0 || (tx.Exceptions?.Any()).GetValueOrDefault()))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (tx.Code > 0 && !string.IsNullOrWhiteSpace(tx.Codespace))
        {
            Console.WriteLine($"\r\n!!!!!!!!!!!! Something went wrong => Code: {tx.Code}; Codespace: {tx.Codespace} !!!!!!!!!!!!");
        }
        if ((tx.Exceptions?.Any()).GetValueOrDefault())
        {
            foreach (var ex in tx.Exceptions)
            {
                Console.WriteLine($"\r\n!!!!!!!!!!!! Exception: {ex.Message} !!!!!!!!!!!!");
            }
        }
        Console.WriteLine($"\r\n{tx.RawLog}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
    }
};

// TxOptions
var txOptions = new TxOptions()
{
    GasLimit = 60_000,
    GasPriceInFeeDenom = 0.26F
};

var txOptionsExecute = new TxOptions()
{
    GasLimit = 300_000,
    GasPriceInFeeDenom = 0.26F
};

var txOptionsUpload = new TxOptions()
{
    GasLimit = 12_000_000,
    GasPriceInFeeDenom = 0.26F
};

#endregion

writeHeadline("Setup SecretNetworkClient / Wallet");

//var storageProvider = new InMemoryOnlyStorage(); // Temporary and most likely only for DEV
var storageProvider = new AesEncryptedFileStorage("","SuperSecurePassword");
var createWalletOptions = new CreateWalletOptions(storageProvider);

Wallet wallet = null;
if (await storageProvider.HasPrivateKey())
{
    var storedMnemonic = await storageProvider.GetFirstMnemonic();
    wallet = await Wallet.Create(storedMnemonic, options: createWalletOptions);
    Console.WriteLine("wallet.Address: " + wallet.Address);
}
else
{
    wallet = await Wallet.Create(options: createWalletOptions);
    Console.WriteLine("wallet.Address: " + wallet.Address);
    Console.WriteLine("Please first fund the wallet with some SCRT via https://faucet.pulsar.scrttestnet.com/ ");
    Console.ReadLine();
}

var gprcUrl = "https://grpc.testnet.secretsaturn.net"; // get from https://github.com/scrtlabs/api-registry
var chainId = "pulsar-2";

var createClientOptions = new CreateClientOptions(gprcUrl, chainId, wallet);
var secretClient = new SecretNetworkClient(createClientOptions);

// dedicated token contract / SNIP20 client
var snip20Client = new Snip20Client(secretClient);     // https://github.com/scrtlabs/snip20-reference-impl

// *** Get Subacccount for target address
var subaccountWallet = await wallet.GetSubaccount(1);
string targetAddress = subaccountWallet.Address;

Console.WriteLine($"\r\nTarget address: {targetAddress}");



// *** Upload SNIP20 Contract

writeHeadline("Upload SNIP20 Contract (snip20_reference_impl.wasm.gz)");

byte[] snip20WasmByteCode = File.ReadAllBytes(@"..\..\..\..\..\resources\snip20_reference_impl.wasm.gz");

var msgStoreCodeSnip20 = new MsgStoreCode(snip20WasmByteCode,
                        source: "https://github.com/scrtlabs/snip20-reference-impl", // Source is a valid absolute HTTPS URI to the contract's source code, optional
                        builder: "enigmampc/secret-contract-optimizer:latest"        // Builder is a valid docker image name with tag, optional
                        );

var snip20StoreCodeResponse = await secretClient.Tx.Compute.StoreCode(msgStoreCodeSnip20, txOptions: txOptionsUpload);
logSecretTx("SNIP20 StoreCode", snip20StoreCodeResponse);

// ***Init SNIP20 Contract ***

writeHeadline("Init SNIP20 Contract with CodeId " + snip20StoreCodeResponse.Response.CodeId);

string snip20Address = null;
string snip20CodeHash = null;
var snip20_code_id = snip20StoreCodeResponse.Response.CodeId;
if (snip20_code_id > 0)
{

    var snip20InstantiateOptions = new InstantiateSnip20()
    {
        Name = "MAUI Token " + snip20_code_id,
        Symbol = "MAUI",
        Decimals = 6,
        //Admin = "secret14v8xnymdezm0nnatu7dtj98cy7nmz4fu6c245e",
        PrngSeed = Convert.ToBase64String(Encoding.UTF8.GetBytes("Super secret seed")),
        InitialBalances = new List<InitBalance>()
        {
            new InitBalance()
            {
                Address = wallet.Address,
                Amount = "1000000000"
            },
            new InitBalance()
            {
                Address = targetAddress,
                Amount = "1000000000"
            }
        },
        Config = new ConfigSettings()
        {
            PublicTotalSupply = true,
            EnableBurn = true,
            EnableMint = true
        }
    };

    Console.WriteLine("Snip20InstantiateOptions:\r\n" + JsonConvert.SerializeObject(snip20InstantiateOptions, Formatting.Indented) + "\r\n");

    var msgInstantiateContract = new MsgInstantiate(snip20_code_id, $"MyFirstToken {snip20_code_id}", snip20InstantiateOptions);

    var instantiateSnip20ContractResponse = await snip20Client.Tx.Instantiate(msgInstantiateContract, txOptionsUpload);
    logSecretTx("InstantiateTokenContract", instantiateSnip20ContractResponse);

    snip20Address = instantiateSnip20ContractResponse.Response.Address;
    if (!string.IsNullOrEmpty(snip20Address))
    {
        Console.WriteLine("SNIP20 Address: " + snip20Address + "\r\n");
        snip20CodeHash = await secretClient.Query.Compute.GetCodeHash(snip20Address);
        Console.WriteLine("SNIP20 CodeHash: " + snip20CodeHash);
    }
}

// *** TokenInfo SNIP20 Token ***

//string? tokenAddress = "secret143pspy62qdu7042mjq4p9ahs20suz92wnw8z7e";
//string tokenCodeHash = "338574ceb3062ffdefa28417e310d018bf045c9a5527a2e9901654a1e344e3c2";

writeHeadline("TokenInfo for " + snip20Address);

var tokenInfoResult = (await snip20Client.Query.GetTokenInfo(snip20Address, snip20CodeHash));
Console.WriteLine("TokenInfoResult:\r\n " + JsonConvert.SerializeObject(tokenInfoResult.Response.Result, Formatting.Indented));

// *** Get minters ***
writeHeadline("Minters for " + snip20Address);

var mintersResult = await snip20Client.Query.GetMinters(snip20Address, snip20CodeHash);
Console.WriteLine("MintersResult:\r\n " + JsonConvert.SerializeObject(mintersResult.Response.Result, Formatting.Indented));


// *** Get ExchangeRate ***
writeHeadline("ExchangeRate for " + snip20Address);

var exchangeRateResult = await snip20Client.Query.GetExchangeRate(snip20Address, snip20CodeHash);
Console.WriteLine("ExchangeRate Result:\r\n " + JsonConvert.SerializeObject(exchangeRateResult.Response.Result, Formatting.Indented));

// *** Send Token

writeHeadline($"Send Token from {wallet.Address} => {targetAddress}");
var sendResult = await snip20Client.Tx.Send(snip20Address, targetAddress, "1", codeHash: snip20CodeHash, txOptions: txOptionsExecute);
Console.WriteLine("Send Result:\r\n " + JsonConvert.SerializeObject(sendResult.Response, Formatting.Indented));

// *** Set ViewingKey and get balance

writeHeadline("Set ViewingKey");

var viewingKey = "SuperSecretViewingKey";
var setViewingKeyMsg = await snip20Client.Tx.SetViewingKey(snip20Address, viewingKey, snip20CodeHash, txOptions: txOptionsExecute);
Console.WriteLine("SetViewingKey Result:\r\n " + JsonConvert.SerializeObject(setViewingKeyMsg.Response, Formatting.Indented));

writeHeadline("Get Balance for " + wallet.Address);
var getBalanceResult = await snip20Client.Query.GetBalance(snip20Address, viewingKey: viewingKey, codeHash: snip20CodeHash);
Console.WriteLine("Get token balance:\r\n " + JsonConvert.SerializeObject(getBalanceResult.Response, Formatting.Indented));

writeHeadline("Get TransferHistory for " + wallet.Address);
var getTransferHistoryResult = await snip20Client.Query.GetTransferHistory(snip20Address, 10, viewingKey: viewingKey, codeHash: snip20CodeHash);
Console.WriteLine("GetTransferHistory Result:\r\n " + JsonConvert.SerializeObject(getTransferHistoryResult.Response.Result, Formatting.Indented));


// *** Mint Token ***

writeHeadline("Mint Token 1_000 to address " + secretClient.WalletAddress);

var mintMsg = new
{
    mint = new
    {
        recipient = secretClient.WalletAddress,
        amount = "1000000000"
    }
};

Console.WriteLine("MintMsg:\r\n " + JsonConvert.SerializeObject(mintMsg, Formatting.Indented) + "\r\n");

var msgExecuteMint = new SecretNET.Tx.MsgExecuteContract(snip20Address, mintMsg, snip20CodeHash);

var mintResponse = await secretClient.Tx.Compute.ExecuteContract(msgExecuteMint, txOptionsUpload);
logSecretTx("mintResponse", mintResponse);

var getBalanceResult2 = await snip20Client.Query.GetBalance(snip20Address, viewingKey: viewingKey, codeHash: snip20CodeHash);
Console.WriteLine("\r\nGet token balance (again):\r\n " + JsonConvert.SerializeObject(getBalanceResult2.Response, Formatting.Indented));

Console.ReadLine();

