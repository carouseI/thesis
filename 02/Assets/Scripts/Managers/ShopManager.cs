using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject chat;
    public GameObject papers;
    public GameObject shop;
    //public IncomeManager incomeManager;

    public TMP_Text coinText;
    public TMP_Text wineText;
    public TMP_Text lotusText;

    public int coin;
    public int wine;
    public int lotus;

    bool shopOpen = false;

    private void Start()
    {
        shop.SetActive(false);
        //chat.SetActive(false);

        coin = 10000;
        coinText.text = coin.ToString();
        //shop.SetActive(true);
    }

    public void ocShop()
    {
        //chat.SetActive(false);

        //shop.SetActive(true);
        //shopOpen = true;
        shopOpen = !shopOpen;

        if (shopOpen)
        {
            shop.SetActive(true);
            //chat.SetActive(false);
        }
        else if (!shopOpen)
        {
            shop.SetActive(false);
            //chat.SetActive(true);
        }
    }

    //public void openShop()
    //{
    //    shop.SetActive(true);
    //    //papers.SetActive(false);
    //    //chat.SetActive(false);
    //}

    //public void closeShop()
    //{
    //    shop.SetActive(false);
    //    //papers.SetActive(true);
    //    //chat.SetActive(true);
    //}

    #region document transactions
    public void goodSaved()
    {
        coin += 100;
        coinText.text = coin.ToString();
    }

    public void badSaved()
    {
        coin += 666;
        coinText.text = coin.ToString();
    }

    public void neutralSaved()
    {
        coin += 10;
        coinText.text = coin.ToString();
    }

    public void goodDestroyed()
    {
        coin -= 1300;
        coinText.text = coin.ToString();
    }

    public void badDestroyed()
    {
        coin += 100;
        coinText.text = coin.ToString();
    }

    public void neutralDestroyed()
    {
        coin += 30;
        coinText.text = coin.ToString();
    }
    #endregion

    #region penalties
    public void massSlaughter()
    {
        coin -= 777;
    }

    #endregion

    #region items
    public void Wine()
    {
        if(coin >= 299)
        {
            Debug.Log("buying wine");
            coin -= 300;
            coinText.text = coin.ToString();
            //incomeManager.DecreaseCoin(10000);

            wine += 1;
            wineText.text = wine.ToString();
        }
        else
        {
            Debug.Log("insufficient funds");
        }
    }

    public void LotusSeed()
    {
        if (coin >= 149)
        {
            Debug.Log("buying lotus seed x 1");
            coin -= 150;
            coinText.text = coin.ToString();
            //incomeManager.DecreaseCoin(10000);

            lotus += 1;
            lotusText.text = lotus.ToString();
        }
        else
        {
            Debug.Log("insufficient funds");
        }
    }

    public void LotusSeeds()
    {
        Debug.Log("buying lotus seeds x 10");
    }

    public void SuitSR()
    {
        Debug.Log("buying suit sr");
    }

    public void SuitSSS()
    {
        Debug.Log("buying suit sss");
    }

    #endregion
}
