using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerProgression : MonoBehaviour
{
    //public TMP_Text playerScore; --
    //public int scoreVal; --

    //public DiagnosticsBar diagnosticsBar;
    //public GameObject energy;

    Image barFill;
    float minVal = 0f;
    float maxVal = 100f;
    float currentFill;

    private int progressAmt;

    // Start is called before the first frame update
    void Start()
    {
        //scoreVal = 6000;

        //energy.SetActive(false);

        barFill = GetComponent<Image>();
        currentFill = minVal;

        progressAmt = 0;
    }

    public void AddProgress(int newProgress)
    {
        progressAmt += newProgress;
        currentFill += 1f;

        barFill.fillAmount += 0.003f;
    }

    //public void HandleDiagnostics()
    //{
    //    if(scoreVal <= 3000 || scoreVal >= 9000)
    //    {
    //        energy.SetActive(true);
    //    }
    //}

    // Update is called once per frame

    private void Update()
    {
        //playerScore.text = "" + scoreVal; --

        //HandleDiagnostics();

        //if(currentFill <= 0f)
        //{
        //    barFill.fillAmount += 1f;
        //}

        if(currentFill == 100f)
        {
            Debug.Log("100% progress");
        }
    }
}