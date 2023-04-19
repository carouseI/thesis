using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FossilFuelManager : MonoBehaviour
{
    Image barFill;
    float maxVal = 100f;
    float currentFill;

    //public Button button;

    //public ScoreManager score;
    //public TMP_Text text;
    private int fuelAmt;

    public bool noFuel = false;

    // Start is called before the first frame update
    private void Start()
    {
        barFill = GetComponent<Image>();
        currentFill = maxVal;

        //button.GetComponent<Button>();
        //button.onClick.AddListener(AddFill);

        fuelAmt = 0;
    }

    public void AddFuel(int newFuel)
    {
        fuelAmt += newFuel;
        currentFill += 2f;
    }

    // Update is called once per frame
    private void Update()
    {
        //text.text = "" + fuelAmt;

        if (currentFill > 0f)
        {
            noFuel = false;
            currentFill -= Time.deltaTime;
            barFill.fillAmount = currentFill / maxVal;
        }
        if (currentFill == 50f)
        {
            Debug.Log("50% fuel");

            noFuel = false;
            currentFill -= Time.deltaTime * 0.5f;
            barFill.fillAmount = currentFill / maxVal * 0.5f;
        }
        if (currentFill <= 0f)
        {
            //Debug.Log("no fuel");
            //Time.timeScale = 0;
            noFuel = true;
        }
    }
}