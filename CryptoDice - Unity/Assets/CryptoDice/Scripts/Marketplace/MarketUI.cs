using TMPro;
using UnityEngine;

public class MarketUI : MonoBehaviour
{
    public static MarketUI Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    public TextMeshProUGUI walletAddressText, nativeBalanceText, chipsBalanceText, chipPriceText;
    public TMP_InputField buyBalanceText, sellBalanceText;

    public TextMeshProUGUI buyLogText, sellLogText;


    //private int buyBalance;
    public int NumberOfChipsToBuy
    {
        get
        {
            var success = int.TryParse(buyBalanceText.text, out int requiredChips);
            if (success)
                return requiredChips;
            else
                return 0;
        }
    }


    public void OnBuyValueChanged()
    {
        int.TryParse(buyBalanceText.text, out int amt);
        if (amt > 0)
        {
            float cost = Web3Manager.Instance.chipPriceInToken * amt;
            buyLogText.text = buyBalanceText.text + " Chips costs " + cost.ToString();
        }
        
    }

    public void OnSellValueChanged()
    {
        int.TryParse(sellBalanceText.text, out int amt);
        if (amt > 0)
        {
            float cost = Web3Manager.Instance.chipPriceInToken * amt;
            sellLogText.text = sellBalanceText.text + " Chips = " + cost.ToString();
        }
        
    }


    public void ClearMarketPlace()
    {
        walletAddressText.text = "";
        nativeBalanceText.text = "";
        chipsBalanceText.text = "";
        buyBalanceText.text = "";
        sellBalanceText.text = "";
        chipPriceText.text = "";
        buyLogText.text = "";
        sellLogText.text = "";
    }
}
