using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractable : MonoBehaviour
{
    //public UIDragger uiDragger;
    public FirstPersonCamera camera;

    //public GameObject camera;
    //public GameObject ePrompt;
    public GameObject ui;

    private void Start()
    {
        ui.SetActive(false);
    }

    private void Update()
    {
        //if (Input.GetKeyDown("e") && camera.isAccessing)
        if (camera.isAccessing)
        {
            ui.SetActive(true);

            Cursor.lockState = CursorLockMode.None; //free cursor
        }
        //else if (Input.GetKeyDown("e") && !camera.isAccessing)
        else if (!camera.isAccessing)
        {
            ui.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked; //free cursor
        }
    }
}
