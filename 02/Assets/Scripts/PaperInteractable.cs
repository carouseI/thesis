using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInteractable : MonoBehaviour
{
    public GameObject interactionIndicator;

    //public DragAndDrop draganddrop;
    public bool canDrag = false;

    private void Start()
    {
        interactionIndicator.SetActive(false);
        //draganddrop.enabled = false;
        //gameObject.GetComponent("DragAndDrop").enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            interactionIndicator.SetActive(true);

            //canDrag = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed e");
            //interactionIndicator.SetActive(false);
            //draganddrop.enabled = true;

            //canDrag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            interactionIndicator.SetActive(false);
            //draganddrop.enabled = false;

            //canDrag = false;
        }
    }
}
