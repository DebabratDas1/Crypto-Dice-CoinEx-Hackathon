using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetReader : MonoBehaviour
{
    //[Header("Bet Fields")]
    [SerializeField] private TMP_InputField n1, n2, n3, n4, n5, n6, n_odd, n_even, n_red, n_black;

    private int bet1, bet2, bet3, bet4, bet5, bet6, betEven, betOdd, betRed, betBlack;
    public int BetFor1
    {
        get
        {
            return ParseInt(n1.text);
        }
    }
    public int BetFor2
    {
        get
        {
            return ParseInt(n2.text);
        }
    }
    public int BetFor3
    {
        get
        {
            return ParseInt(n3.text);
        }
    }
    public int BetFor4
    {
        get
        {
            return ParseInt(n4.text);
        }
    }
    public int BetFor5
    {
        get
        {
            return ParseInt(n5.text);
        }
    }
    public int BetFor6
    {
        get
        {
            return ParseInt(n6.text);
        }
    }

    public int BetForOdd
    {
        get
        {
            //Debug
            return ParseInt(n_odd.text);
        }
    }
    public int BetForEven
    {
        get
        {
            return ParseInt(n_even.text);
        }
    }
    public int BetForRed
    {
        get
        {
            return ParseInt(n_red.text);
        }
    }
    public int BetForBlack
    {
        get
        {
            return ParseInt(n_black.text);
        }
    }


    private int ParseInt(string _s)
    {
        bool success = int.TryParse(_s, out int amount);
        return amount;
    }


    private void Start()
    {
        
    }
    void Myaction()
    {

    }


    public void ClearBet()
    {
        n1.text = "";
        n2.text = "";
        n3.text = "";
        n4.text = "";
        n5.text = "";
        n6.text = "";
        n_black.text = "";
        n_red.text = "";
        n_odd.text = "";
        n_even.text = "";


    }

}
