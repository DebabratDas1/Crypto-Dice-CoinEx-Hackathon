using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance!=this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private BigInteger userChips;
    public BigInteger AvailableChips
    {
        get
        {
            return userChips;
        }
        set
        {
            userChips = value;
            UIManager.Instance.totalChips.text = userChips.ToString();
        }
    }


    private int rewardAmt = 0;
    public int RewardAmount
    {
        get
        {
            return rewardAmt;
        }
        set
        {
            rewardAmt = value;
        }
    }


    private int diceOutcome = 0;
    public int DiceOutcome
    {
        get
        {
            return diceOutcome;
        }
        set
        {
            diceOutcome = value;
        }
    }


    private int betAmt;
    public int BetAmt
    {
        get
        {
            return betAmt;
        }
        set
        {
            betAmt = value;
            if (betAmt > 0)
                UIManager.Instance.confirmBetBtn.SetActive(true);
            else
                UIManager.Instance.confirmBetBtn.SetActive(false);

        }
    }

    private int netWin;
    public int NetWin
    {
        get
        {
            return (rewardAmt - betAmt);
        }
    }



    public void ResetGame()
    {
        //Set diceoutcome to 0
        //remove board values
        //Bet amount 0
        //Win/Reward amount 0
        // Roll Dice Button Interactive
    
    }


    public void OnConfirmBet()
    {
        UIManager.Instance.confirmBetBtn.SetActive(false);
        /*if (!await Web3Manager.Instance.IsConnected())
        {
            UIManager.Instance.ShowLogPanel("You are not signed in");
            return;
        }*/
        if (betAmt < 0)
        {
            UIManager.Instance.ShowLogPanel(" Total Bet amount should be atleast 1");
            return;
        }

        if (betAmt > userChips)
        {
            UIManager.Instance.ShowLogPanel("Bet chips exceeds your available chips number.\n Buy more chips from marketplace");
            return;
        }

        //bool a= 

        

        Web3Manager.Instance.Bet();

    }

    //public int 
 

}