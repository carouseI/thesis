using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //player benevolence score
    //public TMP_Text bScore;
    //private int bVal;
    //public GameObject energyUI;

    //other
    public TMP_Text score;
    private int scoreAmt;

    //private int scoreVal;
    //private int amount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        //bVal = 6000;
        //energyUI.SetActive(true); //switch back to false when bScore can update

        scoreAmt = 0;
    }

    public void AddScore(int newScore)
    {
        //bVal += newScore;

        scoreAmt += newScore;
    }

    public void DecreaseScore(int newScore)
    {
        //bVal -= newScore;
        scoreAmt = newScore - 1;
    }

    // Update is called once per frame
    private void Update()
    {
        score.text = "" + scoreAmt;
    }
}
