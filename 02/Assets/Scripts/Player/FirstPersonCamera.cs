using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] LayerMask layermask;
    //[SerializeField] GameObject ui;

    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0; //default to forward facing cam @ start
    float cameraHorizontalRotation = 0;

    //public Steer steer;
    //public bool canSteer = false;

    bool lockedCursor = true;
    //public bool canAccess = false;
    public bool isAccessing = false;

    public bool canCollect = false;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false; //hide
        Cursor.lockState = CursorLockMode.None; //lock cursor
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        //collect mouse input
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //rotate cam around local x axis (red arrow)
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -30f, 30f); //clamp value

        cameraHorizontalRotation += inputX;
        cameraHorizontalRotation = Mathf.Clamp(cameraHorizontalRotation, -30f, 30f); //clamp value
        transform.localEulerAngles = Vector3.up * cameraHorizontalRotation + Vector3.right * cameraVerticalRotation;

        //rotate cam around local y axis (green arrow)
        //player.Rotate(Vector3.up * inputX);

        //generate raycast
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f, layermask))
        {
            //Debug.Log("hit");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);

            //ePrompt.SetActive(true);

            //ui.SetActive(true);
            //isAccessing = true;

            //canSteer = true;
            //steer.PullableLever();
        }
        else
        {
            //Debug.Log("no hits");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);

            //ePrompt.SetActive(false);
            //ui.SetActive(false);
            //isAccessing = false;

            //ui.SetActive(true);
            //isAccessing = true;

            //canCollect = true;
            //canSteer = false;
        }
    }
}