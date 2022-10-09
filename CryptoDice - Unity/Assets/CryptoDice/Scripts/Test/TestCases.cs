using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestCases : MonoBehaviour
{
     public int outcome;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOutcome(int _outcome)
    {
        GameManager.Instance.DiceOutcome = _outcome;
    }
}



