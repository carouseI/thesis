using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public bool timeIsTicking = false;

    public TMP_Text timeText;

    public GameObject labelText;
    public GameObject endText;

    //public GameObject player;
    //private UIDragger uiDragger;
    //private UIInteractable uiInteractable;

    public string endScene;
    public GameObject sceneChanger;
    public float delay = 5f;

    private void Start()
    {
        timeIsTicking = true;
    }

    private void Update()
    {
        if (timeIsTicking)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timeIsTicking = false;

                labelText.SetActive(false);
                endText.SetActive(true);

                //GameObject gameObject = GameObject.FindWithTag("UI");
                //gameObject.GetComponent<UIDragger>().enabled = false;

                StartCoroutine(SwitchScene());
            }
        }

        DisplayTime(timeRemaining);
    }

    //private void SceneChange()
    //{
    //    SceneManager.LoadScene(endScene);
    //}

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(endScene);
    }

    private void DisplayTime(float displayTime)
    {
        if(displayTime < 0)
        {
            displayTime = 0;
        }

        float minutes = Mathf.FloorToInt(displayTime / 60);
        float seconds = Mathf.FloorToInt(displayTime % 60);
        float milliseconds = displayTime % 1 * 1000;

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
