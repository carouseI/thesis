using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TaskManager : MonoBehaviour
{
    //obj variables
    public GameObject parentObject;
    private GameObject lastChildObject;

    //buttons
    public Button dButton;
    public Button sButton;

    //score management
    public ScoreManager processed;
    public ScoreManager destroyed;
    public ScoreManager saved;

    public PlayerProgression progression;
    public FossilFuelManager fuelManager;

    public bool functionCalled = false;

    //private void Start()
    //{
    //    dButton.GetComponent<Button>();
    //    dButton.onClick.AddListener(DestroyProfile);

    //    sButton.GetComponent<Button>();
    //    sButton.onClick.AddListener(SaveProfile);
    //}

    public void DestroyProfile() //can now differentiate *^* -- dimanche, 5 fév 2023 @ ~14:30 ;;;; update: working, but shows debug 3x each time @ 14:46
    {
        //int numChildren = parentObject.transform.childCount;
        //Destroy(parentObject.transform.GetChild(numChildren - 1).gameObject);
        //Debug.Log("destroyed");

        int lastChildIndex = parentObject.transform.childCount - 1;
        lastChildObject = parentObject.transform.GetChild(lastChildIndex).gameObject;

        if(lastChildObject.tag == "Good")
        {
            //play anim
            Destroy(lastChildObject);
            Debug.Log("good wrongfully destroyed");

            processed.AddScore(1);
            destroyed.AddScore(1);

            //karma.AddScore(100);
        }
        if(lastChildObject.tag == "Bad")
        {
            //play anim
            Destroy(lastChildObject);
            Debug.Log("bad rightfully destroyed");

            processed.AddScore(1);
            destroyed.AddScore(1);
        }
        if (lastChildObject.tag == "Neutral")
        {
            //play anim
            Destroy(lastChildObject);
            Debug.Log("neutral destroyed");

            processed.AddScore(1);
            destroyed.AddScore(1);
        }
        else
        {
            Debug.Log("+1 fuel");
            fuelManager.AddFuel(1);

            Debug.Log("+1 progress");
            progression.AddProgress(1);

            functionCalled = true;
        }
    }

    public void SaveProfile()
    {
        int lastChildIndex = parentObject.transform.childCount - 1;
        lastChildObject = parentObject.transform.GetChild(lastChildIndex).gameObject;

        if (lastChildObject.tag == "Good")
        {
            //play anim
            Destroy(lastChildObject);
            Debug.Log("good rightfully saved");

            processed.AddScore(1);
            saved.AddScore(1);
        }
        if (lastChildObject.tag == "Bad")
        {
            //play anim
            Destroy(lastChildObject);
            Debug.Log("bad wrongfully saved");

            processed.AddScore(1);
            saved.AddScore(1);

            //karma.AddScore(100);
        }
        if (lastChildObject.tag == "Neutral")
        {
            //play anim
            Destroy(lastChildObject);
            Debug.Log("neutral saved");

            processed.AddScore(1);
            saved.AddScore(1);
        }
        else
        {
            Debug.Log("+1 saved");

            Debug.Log("+1 progress");
            progression.AddProgress(1);

            functionCalled = true;
        }
    }
}
