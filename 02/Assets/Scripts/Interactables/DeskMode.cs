using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeskMode : MonoBehaviour
{
    public GameObject player;
    public Animator animator;

    bool canAccess;
    public bool deskMode = false;
    //bool inDeskMode = false;

    public Canvas deskUI;

    public Camera mainCamera;
    public Camera deskCam;

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

    // Start is called before the first frame update
    void Start()
    {
        //deskCam.enabled = false;
        deskUI.enabled = false;

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

        otus.GetComponent<DragAndDrop>().enabled = false;
        ephialtes.GetComponent<DragAndDrop>().enabled = false;
        pheme.GetComponent<DragAndDrop>().enabled = false;
        angelia.GetComponent<DragAndDrop>().enabled = false;
        damon.GetComponent<DragAndDrop>().enabled = false;
        pheres.GetComponent<DragAndDrop>().enabled = false;
        minos.GetComponent<DragAndDrop>().enabled = false;
        tisander.GetComponent<DragAndDrop>().enabled = false;
        alastor.GetComponent<DragAndDrop>().enabled = false;
        ponos.GetComponent<DragAndDrop>().enabled = false;
        orpheus.GetComponent<DragAndDrop>().enabled = false;
        eurus.GetComponent<DragAndDrop>().enabled = false;
        dolos.GetComponent<DragAndDrop>().enabled = false;
        eurydice.GetComponent<DragAndDrop>().enabled = false;

        //gameObject.Find("g-achlys").GetComponent<DragAndDrop>().enabled = false;
        //gameObject.Find("n-otus");
        //gameObject.Find("b-ephialtes");
        //gameObject.Find("n-pheme");
        //gameObject.Find("n-angelia");
        //gameObject.Find("n-damon");
        //gameObject.Find("g-pheres");
        //gameObject.Find("g-minos");
        //gameObject.Find("g-tisander");
        //gameObject.Find("b-alastor");
        //gameObject.Find("g-ponos");
        //gameObject.Find("n-orpheus");
        //gameObject.Find("b-eurus");
        //gameObject.Find("b-dolos");
        //gameObject.Find("g-eurydice");

        //animator = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("desk mode access: ON");
            //canAccess = true;
            deskUI.enabled = true;

            otus.GetComponent<DragAndDrop>().enabled = true;
            ephialtes.GetComponent<DragAndDrop>().enabled = true;
            pheme.GetComponent<DragAndDrop>().enabled = true;
            angelia.GetComponent<DragAndDrop>().enabled = true;
            damon.GetComponent<DragAndDrop>().enabled = true;
            pheres.GetComponent<DragAndDrop>().enabled = true;
            minos.GetComponent<DragAndDrop>().enabled = true;
            tisander.GetComponent<DragAndDrop>().enabled = true;
            alastor.GetComponent<DragAndDrop>().enabled = true;
            ponos.GetComponent<DragAndDrop>().enabled = true;
            orpheus.GetComponent<DragAndDrop>().enabled = true;
            eurus.GetComponent<DragAndDrop>().enabled = true;
            dolos.GetComponent<DragAndDrop>().enabled = true;
            eurydice.GetComponent<DragAndDrop>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("desk mode access: OFF");
            //canAccess = false;
            deskUI.enabled = false;

            otus.GetComponent<DragAndDrop>().enabled = false;
            ephialtes.GetComponent<DragAndDrop>().enabled = false;
            pheme.GetComponent<DragAndDrop>().enabled = false;
            angelia.GetComponent<DragAndDrop>().enabled = false;
            damon.GetComponent<DragAndDrop>().enabled = false;
            pheres.GetComponent<DragAndDrop>().enabled = false;
            minos.GetComponent<DragAndDrop>().enabled = false;
            tisander.GetComponent<DragAndDrop>().enabled = false;
            alastor.GetComponent<DragAndDrop>().enabled = false;
            ponos.GetComponent<DragAndDrop>().enabled = false;
            orpheus.GetComponent<DragAndDrop>().enabled = false;
            eurus.GetComponent<DragAndDrop>().enabled = false;
            dolos.GetComponent<DragAndDrop>().enabled = false;
            eurydice.GetComponent<DragAndDrop>().enabled = false;
        }
    }

    //// Update is called once per frame
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E) && canAccess)
    //    {
    //        deskMode = !deskMode;

    //        if (deskMode)
    //        {
    //            Debug.Log("accessing desk mode");

    //            //animator.Play("sitting");

    //            //inDeskMode = true;
    //            deskUI.enabled = true;
    //        }
    //        else
    //        {
    //            //animator.Play("stand up");

    //            deskUI.enabled = false;
    //        }
    //    }
    //}
}
