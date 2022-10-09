using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    [SerializeField] private GameObject infoHomeUI, payoutsUI, predictionUI;


    public void InfoHomeUI()
    {
        infoHomeUI.SetActive(true);
        payoutsUI.SetActive(false);
        predictionUI.SetActive(false);
    }
    public void PayoutsInfoUI()
    {
        infoHomeUI.SetActive(false);
        payoutsUI.SetActive(true);
        predictionUI.SetActive(false);
    }
    public void PredictionInfoUI()
    {
        infoHomeUI.SetActive(false);
        payoutsUI.SetActive(false);
        predictionUI.SetActive(true);
    }


    [SerializeField] private TextMeshProUGUI betAmt, winAmt, netWinAmt, diceOutcome;
    [SerializeField] private GameObject rewardInfoUI;
    public void ShowRewardInfoUI()
    {

        betAmt.text = GameManager.Instance.BetAmt.ToString();
        Debug.Log("BetAmt = " + GameManager.Instance.BetAmt);
        winAmt.text = GameManager.Instance.RewardAmount.ToString();
        netWinAmt.text = GameManager.Instance.NetWin.ToString();
        diceOutcome.text = GameManager.Instance.DiceOutcome.ToString();
        rewardInfoUI.SetActive(true);
        WillShowDiceRollUI(false);
    }

    public void HideRewardInfoUI()
    {
        //RewardCalculator.Instance.betReader.ClearBet();
        rewardInfoUI.SetActive(false);
        StartCoroutine(Web3Manager.Instance.RefreshMarketWithDelay());
    }


    [SerializeField] private GameObject gamePlayUI,marketplaceUI;

    public void ShowGamePlayUI()
    {
        gamePlayUI.SetActive(true);
        marketplaceUI.SetActive(false);
    }
    public void ShowMarketplaceUI()
    {
        gamePlayUI.SetActive(false);
        marketplaceUI.SetActive(true);
        Web3Manager.Instance.RefreshMarketPlace();
    }


    [SerializeField] private GameObject diceRollUI;
    public GameObject rollButton;

    public void WillShowDiceRollUI(bool willShow)
    {
        if(willShow)
            HideRewardInfoUI();
        diceRollUI.SetActive(willShow);
        rollButton.SetActive(true);
        waitForRewardAfterRollText.SetActive(false);
        rollTheDiceText.SetActive(true);
    }

    [SerializeField] private GameObject logPanel;
    [SerializeField] private TextMeshProUGUI logText;

    public void ShowLogPanel(string _msg)
    {
        logText.text = _msg;
        logPanel.SetActive(true);
        RewardCalculator.Instance.betReader.ClearBet();
    }

    public void ExitLogPanel()
    {
        logPanel.SetActive(false);
    }



    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public TextMeshProUGUI totalChips;
    public GameObject confirmBetBtn;
    public GameObject waitForRewardAfterRollText, rollTheDiceText;


    

}
