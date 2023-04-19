using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public List<string> salvationRecord = new List<string>();

    public GameObject systemNotif;
    public TMP_Text alert;
    public Animation animation;

    //public IncomeManager incomeManager;
    public ShopManager shoppingFunds;

    bool alastor = false;
    bool achlys = false;

    // Start is called before the first frame update
    void Start()
    {
        //systemNotif.SetActive(false);
    }

    public void SystemUpdate()
    {
        if (alastor)
        {
            systemNotif.SetActive(true);
            //animation.Play("notification");

            alert.text = "Alastor has been granted the chance to reincarnate.";
            //Invoke(nameof(TurnOff), 2f);
            alastor = false;
        }

        if (achlys)
        {
            //Destroy("g-achlys")
            salvationRecord.Remove("g-achlys");
            salvationRecord.Remove("b-alastor");

            systemNotif.SetActive(true);
            alert.text = "Achlys and several other have been slain by Alastor.";
            //incomeManager.DecreaseCoin(3);
            //Invoke(nameof(TurnOff), 2f);
            achlys = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (salvationRecord.Contains("b-alastor"))
        {
            //Debug.Log("one brother found");
            alastor = true;
            SystemUpdate();
        }

        if (salvationRecord.Contains("g-achlys") && salvationRecord.Contains("b-alastor"))
        {
            //removingAchlys = true;
            //ConsequenceTracker();

            //Debug.Log("two brothers found");
            shoppingFunds.massSlaughter();

            achlys = true;
            SystemUpdate();
        }
        else
        {
            //Debug.Log("two brothers not found");
        }
    }

    //public void TurnOff()
    //{
    //    StartCoroutine(RemoveAfterSeconds(2, systemNotif));
    //    //systemNotif.SetActive(false);
    //}

    //IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    obj.SetActive(false);
    //}
}
