using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisibilityRegulator : MonoBehaviour
{
    private GameObject achlys;
    private GameObject otus;
    private GameObject ephialtes;
    private GameObject pheme;
    private GameObject angelia;
    private GameObject damon;
    private GameObject pheres;
    private GameObject minos;
    private GameObject tisander;
    private GameObject alastor;
    private GameObject ponos;
    private GameObject orpheus;
    private GameObject eurus;
    private GameObject dolos;
    private GameObject eurydice;

    public GameObject sceneChanger;
    public string endScene;
    public float delay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        achlys = GameObject.Find("g-achlys");
        otus = GameObject.Find("n-otus");
        ephialtes = GameObject.Find("b-ephialtes");
        pheme = GameObject.Find("n-pheme");
        angelia = GameObject.Find("n-angelia");
        damon = GameObject.Find("n-damon");
        pheres = GameObject.Find("g-pheres");
        minos = GameObject.Find("g-minos");
        tisander = GameObject.Find("g-tisander");
        alastor = GameObject.Find("b-alastor");
        ponos = GameObject.Find("g-ponos");
        orpheus = GameObject.Find("n-orpheus");
        eurus = GameObject.Find("b-eurus");
        dolos = GameObject.Find("b-dolos");
        eurydice = GameObject.Find("g-eurydice");

        otus.SetActive(false);
        ephialtes.SetActive(false);
        pheme.SetActive(false);
        angelia.SetActive(false);
        damon.SetActive(false);
        pheres.SetActive(false);
        minos.SetActive(false);
        tisander.SetActive(false);
        alastor.SetActive(false);
        ponos.SetActive(false);
        orpheus.SetActive(false);
        eurus.SetActive(false);
        dolos.SetActive(false);
        eurydice.SetActive(false);
    }

    //Update is called once per frame
    private void Update()
    {
        if (achlys == null)
        {
            //Debug.Log("achlys is gone");
            if(otus != null)
            {
                otus.SetActive(true);
            }
        }
        if (otus == null)
        {
            //Debug.Log("achlys is gone");
            if(ephialtes != null)
            ephialtes.SetActive(true);
        }
        if (ephialtes == null)
        {
            //Debug.Log("achlys is gone");
            if (pheme != null)
                pheme.SetActive(true);
        }
        if (pheme == null)
        {
            //Debug.Log("achlys is gone");
            if (angelia != null)
                angelia.SetActive(true);
        }
        if (angelia == null)
        {
            //Debug.Log("achlys is gone");
            if (damon != null)
                damon.SetActive(true);
        }
        if (damon == null)
        {
            //Debug.Log("achlys is gone");
            if (pheres != null)
                pheres.SetActive(true);
        }
        if (pheres == null)
        {
            //Debug.Log("achlys is gone");
            if (minos != null)
                minos.SetActive(true);
        }
        if (minos == null)
        {
            //Debug.Log("achlys is gone");
            if (tisander != null)
                tisander.SetActive(true);
        }
        if (tisander == null)
        {
            //Debug.Log("achlys is gone");
            if (alastor != null)
                alastor.SetActive(true);
        }
        if (alastor == null)
        {
            //Debug.Log("achlys is gone");
            if (ponos != null)
                ponos.SetActive(true);
        }
        if (ponos == null)
        {
            //Debug.Log("achlys is gone");
            if (orpheus != null)
                orpheus.SetActive(true);
        }
        if (orpheus == null)
        {
            //Debug.Log("achlys is gone");
            if (eurus != null)
                eurus.SetActive(true);
        }
        if (eurus == null)
        {
            //Debug.Log("achlys is gone");
            if (dolos != null)
                dolos.SetActive(true);
        }
        if (dolos == null)
        {
            //Debug.Log("achlys is gone");
            if (eurydice != null)
                eurydice.SetActive(true);
        }
        if(eurydice == null)
        {
            StartCoroutine(SwitchScene());
        }
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(endScene);
    }
}
