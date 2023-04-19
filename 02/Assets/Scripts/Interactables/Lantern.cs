using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [Header("General")]
    public GameObject parentObject;
    private GameObject lastChildObject;

    [Header("Salvation Manager")]
    public ScoreManager processed;
    public ScoreManager saved;
    public PlayerProgression progression;
    public ShopManager shopManager;

    public void saveMatter()
    {
        int lastChildIndex = parentObject.transform.childCount - 1;
        lastChildObject = parentObject.transform.GetChild(lastChildIndex).gameObject;

        if(lastChildObject.tag == "Good")
        {
            Debug.Log("good wine");
            Destroy(lastChildObject);

            shopManager.goodSaved();
        }
        if (lastChildObject.tag == "Bad")
        {
            Debug.Log("bad wine");
            Destroy(lastChildObject);

            shopManager.badSaved();
        }
        if (lastChildObject.tag == "Neutral")
        {
            Debug.Log("ok wine");
            Destroy(lastChildObject);

            shopManager.neutralSaved();
        }
        else
        {
            //Debug.Log("+1 processed");
            processed.AddScore(1);

            //Debug.Log("+1 saved");
            saved.AddScore(1);

            //Debug.Log("+1 progress");
            progression.AddProgress(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
