using TMPro;
using UnityEngine;

public class RewardCalculator : MonoBehaviour
{
    public BetReader betReader;


    public static RewardCalculator Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }


    public void Reward()
    {
        int reward = CalculateReward1(GameManager.Instance.DiceOutcome);

        if (reward > 0)
        {
            UIManager.Instance.rollTheDiceText.SetActive(false);
            UIManager.Instance.waitForRewardAfterRollText.SetActive(true);
            Web3Manager.Instance.GetReward();
        }
        else
        {
            UIManager.Instance.ShowRewardInfoUI();
        }
    }

    public int CalculateReward(int _diceOutcome)
    {
        int reward = 0;
        if (betReader.BetFor1 > 0 && _diceOutcome==1)
        {
            reward += betReader.BetFor1 * 6;

        }
        if (betReader.BetFor2 > 0 && _diceOutcome == 2)
        {
            reward += betReader.BetFor2 * 6;

        }
        if (betReader.BetFor3 > 0 && _diceOutcome == 3)
        {
            reward += betReader.BetFor3 * 6;

        }
        if (betReader.BetFor4 > 0 && _diceOutcome == 4)
        {
            reward = betReader.BetFor4 * 6;

        }
        if (betReader.BetFor5 > 0 && _diceOutcome == 5)
        {
            reward += betReader.BetFor5 * 6;

        }
        if (betReader.BetFor6 > 0 && _diceOutcome == 6)
        {
            reward += betReader.BetFor6 * 6;

        }

        // If black
        /*if (betReader.BetFor6 > 0 && _diceOutcome == 6)
        {
            reward += betReader.BetFor6 * 6;

        }*/
        Debug.Log("Reward  " + reward);
        return reward;
    }
    public int CalculateReward1(int _diceOutcome)
    {
        //Debug.Log(_diceOutcome);
        int reward = 0;
        if (_diceOutcome == 1)
        {
            reward = RewardForOutcome1;
        }
        else if (_diceOutcome == 2)
        {
            reward = RewardForOutcome2;
        }
        else if (_diceOutcome == 3)
        {
            reward = RewardForOutcome3;
        }
        else if (_diceOutcome == 4)
        {
            reward = RewardForOutcome4;
        }
        else if (_diceOutcome == 5)
        {
            reward = RewardForOutcome5;
        }
        else if (_diceOutcome == 6)
        {
            reward = RewardForOutcome6;
        }
        else
        {
            Debug.Log("Error Reward " + reward);
        }

        // If black
        /*if (betReader.BetFor6 > 0 && _diceOutcome == 6)
        {
            reward += betReader.BetFor6 * 6;

        }*/
        GameManager.Instance.RewardAmount = reward;
        return reward;
    }

    private int AddRewardForOdd
    {
        get
        {
            return betReader.BetForOdd * 2;
        }
    }
    private int AddRewardForEven
    {
        get
        {
            return betReader.BetForEven * 2;
        }
    }
    private int AddRewardForRed
    {
        get
        {
            return betReader.BetForRed * 2;
        }
    }
    private int AddRewardForBlack
    {
        // 2,3,6 Black
        get
        {
            return betReader.BetForBlack * 2;
        }
    }
    /*private int RewardSingleNumber(int _diceOutcome)
    {
        return
    }*/


    private int RewardForOutcome1
    {
        get
        {
            return (betReader.BetFor1 * 6) + AddRewardForOdd + AddRewardForRed;
        }
    }
    private int RewardForOutcome2
    {
        get
        {
            return (betReader.BetFor2 * 6) + AddRewardForEven + AddRewardForBlack;
        }
    }
    private int RewardForOutcome3
    {
        get
        {
            return (betReader.BetFor3 * 6) + AddRewardForOdd + AddRewardForBlack;
        }
    }
    private int RewardForOutcome4
    {
        get
        {
            return (betReader.BetFor4 * 6) + AddRewardForEven + AddRewardForRed;
        }
    }
    private int RewardForOutcome5
    {
        get
        {
            return (betReader.BetFor5 * 6) + AddRewardForOdd + AddRewardForRed;
        }
    }
    private int RewardForOutcome6
    {
        get
        {
            return (betReader.BetFor6 * 6) + AddRewardForEven + AddRewardForBlack;
        }
    }

    private int TotalBetAmount
    {
        get
        {
            GameManager.Instance.BetAmt = (betReader.BetFor1 + betReader.BetFor2 + betReader.BetFor3 +
                betReader.BetFor4 + betReader.BetFor5 + betReader.BetFor6 +
                betReader.BetForBlack + betReader.BetForEven + betReader.BetForOdd + betReader.BetForRed);
            Debug.Log("Bet Amount = " + GameManager.Instance.BetAmt);
            return GameManager.Instance.BetAmt;
        }
    }

    [SerializeField]
    private TextMeshProUGUI rewardFor1, rewardFor2, rewardFor3, rewardFor4,
        rewardFor5, rewardFor6, totalBetAmount;
    public void PredictReward()
    {
        rewardFor1.text = RewardForOutcome1.ToString();
        rewardFor2.text = RewardForOutcome2.ToString();
        rewardFor3.text = RewardForOutcome3.ToString();
        rewardFor4.text = RewardForOutcome4.ToString();
        rewardFor5.text = RewardForOutcome5.ToString();
        rewardFor6.text = RewardForOutcome6.ToString();
        totalBetAmount.text = TotalBetAmount.ToString();

    }

    
}
