using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [Header("Object Variables")]
    public GameObject parentObject;
    private GameObject lastChildObject;

    [Header("Buttons")]
    public Button killButton;
    public Button saveButton;

    [Header("Score Management")]
    public ScoreManager processed;
    public ScoreManager destroyed;
    public ScoreManager saved;

    [Header("Progression Gauges")]
    public PlayerProgression progression;
    public FossilFuelManager fuelManager;

    [Header("Miscellaneous")]
    public ShopManager shopManager;
    public GameObject fuelPrefab;
    public Animator animator;

    public bool canInteract = false;
    public bool wasDestroyed = false;
    bool functionCalled = false;

    //[Header("Visual Feedback")]
    //private UIDragger uiDragger;
    //public bool selected = false;

    //private void Start()
    //{
    //    dButton.GetComponent<Button>();
    //    dButton.onClick.AddListener(DestroyProfile);

    //    sButton.GetComponent<Button>();
    //    sButton.onClick.AddListener(SaveProfile);
    //}

    private void Start()
    {
        fuelPrefab.SetActive(false);
        //animator.enabled = false;
    }

    public void DestroyProfile() //can now differentiate *^* -- dimanche, 5 fév 2023 @ ~14:30 ;;;; update: working, but shows debug 3x each time @ 14:46
    {
        //int numChildren = parentObject.transform.childCount;
        //Destroy(parentObject.transform.GetChild(numChildren - 1).gameObject);
        //Debug.Log("destroyed");

        canInteract = true;

        int lastChildIndex = parentObject.transform.childCount - 1;
        lastChildObject = parentObject.transform.GetChild(lastChildIndex).gameObject;

        if(lastChildObject.tag == "Good")
        {
            //play anim
            Trash();

            Destroy(lastChildObject);
            Debug.Log("good wrongfully destroyed");

            processed.AddScore(1);
            destroyed.AddScore(1);
            //karma.AddScore(100);
        }
        if(lastChildObject.tag == "Bad")
        {
            //play anim
            Trash();

            Destroy(lastChildObject);
            Debug.Log("bad rightfully destroyed");

            processed.AddScore(1);
            destroyed.AddScore(1);
        }
        if (lastChildObject.tag == "Neutral")
        {
            //play anim
            Trash();

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
            wasDestroyed = true;
        }
    }

    public void Trash()
    {
        lastChildObject.SetActive(false);
        fuelPrefab.SetActive(true);
        
        animator.Play("trash", 0, 0);
    }

    public void SaveProfile()
    {
        canInteract = true;

        int lastChildIndex = parentObject.transform.childCount - 1;
        lastChildObject = parentObject.transform.GetChild(lastChildIndex).gameObject;

        if (lastChildObject.tag == "Good")
        {
            //play anim
            Destroy(lastChildObject);
            Debug.Log("good rightfully saved");

            processed.AddScore(1);
            saved.AddScore(1);

            shopManager.goodSaved();
            //Debug.Log("+ coins");
        }
        if (lastChildObject.tag == "Bad")
        {
            //play anim
            Destroy(lastChildObject);
            Debug.Log("bad wrongfully saved");

            processed.AddScore(1);
            saved.AddScore(1);

            //karma.AddScore(100);

            shopManager.badSaved();
        }
        if (lastChildObject.tag == "Neutral")
        {
            //play anim
            Destroy(lastChildObject);
            Debug.Log("neutral saved");

            processed.AddScore(1);
            saved.AddScore(1);

            shopManager.neutralSaved();
        }
        else
        {
            Debug.Log("+1 saved");

            Debug.Log("+1 progress");
            progression.AddProgress(1);

            functionCalled = true;
        }
    }

    private void Update()
    {
        //wasDestroyed = !wasDestroyed;

        //if (!wasDestroyed)
        //{
        //    lastChildObject.SetActive(false);
        //    fuelPrefab.SetActive(true);
        //    animator.enabled = true;
        //}

        if (parentObject.transform.childCount == 0)
        {
            Debug.Log("no more children");
            StartCoroutine(DelaySceneLoad());
        }

        ////select outline
        //if (lastChildObject)
        //{
        //    uiDragger.isSelected = true;
        //    uiDragger.onOff();
        //}
        //else if (!lastChildObject)
        //{
        //    uiDragger.isSelected = false;
        //    uiDragger.onOff();
        //}
    }

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("end scene");
    }
}
