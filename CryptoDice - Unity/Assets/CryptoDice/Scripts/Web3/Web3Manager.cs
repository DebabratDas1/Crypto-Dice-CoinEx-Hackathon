using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System;

public class Web3Manager : MonoBehaviour
{
   
    public static Web3Manager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }


    //private string userWalletAddress;

    public bool isConnected = false;

    #region Set Network
    // abi in json format
    string abi = "[{\"inputs\":[],\"name\":\"AddBalanceToContract\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amt\",\"type\":\"uint256\"}],\"name\":\"bet\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Bought\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"buyTokens\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenAmount\",\"type\":\"uint256\"}],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"buyer\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOfETH\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOfTokens\",\"type\":\"uint256\"}],\"name\":\"BuyTokens\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"subtractedValue\",\"type\":\"uint256\"}],\"name\":\"decreaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amt\",\"type\":\"uint256\"}],\"name\":\"getPrize\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"addedValue\",\"type\":\"uint256\"}],\"name\":\"increaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"previousOwner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"OwnershipTransferred\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"renounceOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenAmountToSell\",\"type\":\"uint256\"}],\"name\":\"sellTokens\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_price\",\"type\":\"uint256\"}],\"name\":\"SetChipsPrice\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Sold\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transfer\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"transferOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"}],\"name\":\"allowance\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"chipsValue\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"decimals\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getChipsPrice\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"ownerAdd\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
    // address of contract
    string contract = "0x5A8629b3C5ec374566272366F970e71832E7045D";
    // set chain
    string chain = "coinex";
    // set network
    string network = "testnet-rpc";
    string chainId = "53";
    string rpc = "https://testnet-rpc.coinex.net/";
    #endregion


    public void OnConnectedWalletAsync()
    {
        GetSetWalletAddress();
        StartCoroutine(RefreshMarketWithDelay());
        isConnected = true;
    }

    public void OnDisConnectedWalletAsync()
    {
        GetSetWalletAddress();
        MarketUI.Instance.ClearMarketPlace();
        isConnected = false;
    }

    private void Start()
    {
        GetSetWalletAddress();
        RefreshMarketPlace();
        isConnected = true;
    }


    public void RefreshMarketPlace()
    {
        if (PlayerPrefs.GetString("Account")!=null)
        {
            GetSetWalletAddress();
            GetChipsPrice();
            GetNativeBalanceAsync();
            GetTokenBalance();
        }
        else
        {
            UIManager.Instance.ShowLogPanel("You are not signed in.");
        }

    }
    public IEnumerator RefreshMarketWithDelay()
    {
        yield return new WaitForSeconds(6f);
        RefreshMarketPlace();
    }

    private void GetSetWalletAddress()
    {
        string user = PlayerPrefs.GetString("Account");
        if (user != null)
        {
            
            MarketUI.Instance.walletAddressText.text = user;
        }
        else
        {
            GameManager.Instance.AvailableChips = 0;
            GameManager.Instance.BetAmt = 0;
            GameManager.Instance.RewardAmount = 0;
            RewardCalculator.Instance.betReader.ClearBet();
        }
        
    }

    private async void GetNativeBalanceAsync()
    {
        string account = PlayerPrefs.GetString("Account");
        Debug.Log("account " + account);

        string balance = await EVM.BalanceOf(chain, network, account, rpc);
        //balText.text = balance;
        print(balance);


        //NativeBalance balance = await Moralis.Web3Api.Account.GetNativeBalance(userWalletAddress.ToLower(), chainList);
        //Debug.Log($"GetNativeBalance Balance: {balance.Balance}");
        BigInteger.TryParse(balance, out BigInteger tCET);
        BigInteger unit = BigInteger.Pow(10, 18);
        float nativeBal = (float)tCET / (float )unit;
        decimal d = Decimal.Parse(nativeBal.ToString(), System.Globalization.NumberStyles.Float);
        //string formattedBal = string.Format("{ 0:00.00}", nativeBal.ToString());
        MarketUI.Instance.nativeBalanceText.text = d.ToString();
        //String.Format("{0:0.00000}", d);
    }


    // Get chips value + Y
    // Buy chips(Chips amount) need to convert to native balance value + Y
    // Sell Buy(Chips amount) +
    // Confirm Bid(chips amount) + Y
    // Get Reward(chips amount) + Y
    // Get Native Balance + Y
    // Get Token Balance + Y


    

    public float chipPriceInToken = 0;
    private BigInteger chipPrice;
    public BigInteger ChipPrice
    {
        get
        {
            return chipPrice;
        }
        set
        {
            chipPrice = value;
            //int chipPriceInWei = chipPrice;
            chipPriceInToken = (float)chipPrice * Mathf.Pow(10, -18);
            Debug.Log("chipPriceInToken " + chipPriceInToken);
            MarketUI.Instance.chipPriceText.text = "1 chp = " + chipPriceInToken.ToString() + " TCET";// + chipPriceInToken.ToString() + " TCRO";
        }
    }
    public async void GetChipsPrice()
    {
        // array of arguments for contract
        string args = "[]";
        // method you want to write to
        string method = "getChipsPrice";

        // connects to user's browser wallet to call a transaction
        string resp = await EVM.Call(chain, network, contract, abi, method, args, rpc);
        // display response in game
        //print(resp);
        Debug.Log(resp);
        BigInteger.TryParse(resp, out BigInteger _chipPrice);
        ChipPrice = _chipPrice;
        Debug.Log(ChipPrice);

    }


    









    public async void GetTokenBalance()
    {

        string account = PlayerPrefs.GetString("Account");

        BigInteger chipBalance = await ERC20.BalanceOf(chain, network, contract, account, rpc);
        
        GameManager.Instance.AvailableChips = chipBalance;

        MarketUI.Instance.chipsBalanceText.text = chipBalance.ToString();

    }



    


    public async void Bet()
    {

        //string resp = await Bet(GameManager.Instance.BetAmt);
        
        //USER ADDRESS CHECKING
        /*MoralisUser user = await Moralis.GetUserAsync();
        Debug.Log(user);
        string fromAddress = user.authData["moralisEth"]["id"].ToString();
        Debug.Log(fromAddress + "  FromAddress");

        if (fromAddress == null)
        {
            return null;
        }*/

        // Calculate Prize Amount

        BigInteger prizeAmt = new BigInteger(GameManager.Instance.BetAmt);

        string betAmt = prizeAmt.ToString();

        // method you want to write to
        string method = "bet";
        // amount you want to change, in this case we are adding 1 to "addTotal"
        string amount = betAmt;
        // array of arguments for contract
        string[] obj = { amount };
        string args = JsonConvert.SerializeObject(obj);
        // create data for contract interaction
        string data = await EVM.CreateContractData(abi, method, args);
        string resp = null ;
        try
        {
            // send transaction
#if UNITY_WEBGL

        resp = await Web3GL.SendContract(method, abi, contract, args, "0", "", "");
#else
            resp = await Web3Wallet.SendTransaction(chainId, contract, "0", data, "", "");
#endif
            StartCoroutine(RefreshMarketWithDelay());
            UIManager.Instance.WillShowDiceRollUI(true);
        }
        catch (Exception e)
        {
            UIManager.Instance.ShowLogPanel("Can't confirm your Bet : " + e);
        }
    }
    public async void GetReward()
    {
        /*
        //USER ADDRESS CHECKING
        MoralisUser user = await Moralis.GetUserAsync();
        Debug.Log(user);
        string fromAddress = user.authData["moralisEth"]["id"].ToString();
        Debug.Log(fromAddress + "  FromAddress");

        if (fromAddress == null)
        {
            return null;
        }*/

        // Calculate Prize Amount

        BigInteger prizeAmt = new BigInteger(GameManager.Instance.RewardAmount);
        string rewardAmt = prizeAmt.ToString();

        // method you want to write to
        string method = "getPrize";
        // amount you want to change, in this case we are adding 1 to "addTotal"
        string amount = rewardAmt;
        // array of arguments for contract
        string[] obj = { amount };
        string args = JsonConvert.SerializeObject(obj);
        // create data for contract interaction
        string data = await EVM.CreateContractData(abi, method, args);
        string resp = null;
        try
        {
            // send transaction
#if UNITY_WEBGL

        resp = await Web3GL.SendContract(method, abi, contract, args, "0", "", "");
#else
            resp = await Web3Wallet.SendTransaction(chainId, contract, "0", data, "", "");
#endif
            StartCoroutine(RefreshMarketWithDelay());
            UIManager.Instance.ShowRewardInfoUI();
        }
        catch (Exception e)
        {
            UIManager.Instance.ShowLogPanel("Error while claiming reward : " + e);
        }
    }


    



    



    public async void BuyChips()
    {
        BigInteger.TryParse(MarketUI.Instance.buyBalanceText.text, out BigInteger requiredChip);
        Debug.Log(requiredChip);
        if (requiredChip <= 0)
        {
            MarketUI.Instance.buyLogText.text = "Error : You need to buy at least 1 Chip";
            UIManager.Instance.ShowLogPanel("Error : You need to buy at least 1 Chip");
            return;
        }
        //string betAmt = MarketUI.Instance.buyBalanceText.text;

        BigInteger amt = requiredChip * ChipPrice;

        string value = amt.ToString();
        // method you want to write to
        string method = "buyTokens";
        // amount you want to change, in this case we are adding 1 to "addTotal"
        //string amount = betAmt;
        // array of arguments for contract
        string[] obj = { };
        string args = JsonConvert.SerializeObject(obj);
        // create data for contract interaction
        string data = await EVM.CreateContractData(abi, method, args);
        string resp = null;
        try
        {
            // send transaction
#if UNITY_WEBGL

        resp = await Web3GL.SendContract(method, abi, contract, args, value, "", "");
#else
            resp = await Web3Wallet.SendTransaction(chainId, contract, value, data, "", "");
#endif
            StartCoroutine(RefreshMarketWithDelay());
        }
        catch(Exception e)
        {
            UIManager.Instance.ShowLogPanel("Error to buy chip : "+ e);
        }
    }
    public async void SellChips()
    {
        BigInteger.TryParse(MarketUI.Instance.sellBalanceText.text, out BigInteger requiredChip);
        Debug.Log(requiredChip);
        if (requiredChip <= 0)
        {
            MarketUI.Instance.sellLogText.text = "Error : You need to sell at least 1 Chip";
            return ;
        }
        // method you want to write to
        string method = "sellTokens";
        // amount you want to change, in this case we are adding 1 to "addTotal"
        string amount = MarketUI.Instance.sellBalanceText.text;
        // array of arguments for contract
        string[] obj = { amount };
        string args = JsonConvert.SerializeObject(obj);
        // create data for contract interaction
        string data = await EVM.CreateContractData(abi, method, args);
        string resp = null;
        try
        {
            // send transaction
#if UNITY_WEBGL

        resp = await Web3GL.SendContract(method, abi, contract, args, "0", "", "");
#else
            resp = await Web3Wallet.SendTransaction(chainId, contract, "0", data, "", "");
#endif
            StartCoroutine(RefreshMarketWithDelay());
        }
        catch (Exception e)
        {
            UIManager.Instance.ShowLogPanel("Error to sell Chip : " + e);
        }
    }



}
