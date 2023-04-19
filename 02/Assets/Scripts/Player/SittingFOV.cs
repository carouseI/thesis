using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingFOV : MonoBehaviour
{
    [SerializeField] LayerMask layermask;

    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0; //default to forward facing cam @ start
    float cameraHorizontalRotation = 0;

    bool lockedCursor = true;
    public bool isAccessing = false;

    public bool canCollect = false;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false; //hide
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Locked; //lock cursor
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
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        //horizontal
        cameraHorizontalRotation -= inputX;
        cameraHorizontalRotation = Mathf.Clamp(cameraHorizontalRotation, -30f, 30f); //clamp value
        transform.localEulerAngles = Vector3.right * cameraHorizontalRotation;

        //rotate cam around local y axis (green arrow)
        player.Rotate(Vector3.up * inputX);

        //generate raycast
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f, layermask))
        {
            //Debug.Log("hit");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
        }
        else
        {
            //Debug.Log("no hits");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);
        }
    }
}
