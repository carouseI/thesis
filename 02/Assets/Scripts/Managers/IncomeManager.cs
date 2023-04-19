using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncomeManager : MonoBehaviour
{
    public TMP_Text coins;
    private int coinAmt;

    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        coinAmt = 10000;
    }

    public void AddCoins(int newCoin)
    {
        coinAmt += newCoin;
    }

    public void DecreaseCoin(int newCoin)
    {
        newCoin -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "" + coinAmt;

        if(coinAmt <= 0)
        {
            //shop.SetActive(false);
        }

        if(coinAmt >= 1)
        {
            //Debug.Log("10,000");
            //shop.SetActive(true);
        }
        else
        {
            //Debug.Log("not met");
        }
    }
}
