using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steer : MonoBehaviour
{
    private float SceneWidth;

    //initial states
    private Vector3 PressPoint;
    private Quaternion StartRotation;

    public GameObject cogH;
    public GameObject cogV;

    //move
    public GameObject translationTarget;

    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;

    private float inputHorizontal;
    private float inputVertical;

    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";

    // Start is called before the first frame update
    private void Start()
    {
        SceneWidth = Screen.width;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //initial pos + rotation
        {
            PressPoint = Input.mousePosition;
            StartRotation = transform.rotation;
        }
        else if (Input.GetMouseButton(0)) //on continued mouse down, start rotation
        {
            //value to calculate ratio between scene width + 360° rotation
            float CurrentDistanceBetweenMousePositions = (Input.mousePosition - PressPoint).x;

            //to rotate, calculate rotation in euler angles, translate value to Quaternion, apply rotation to obj via quaternion arithmetic
            transform.rotation = StartRotation * Quaternion.Euler(Vector3.left * (CurrentDistanceBetweenMousePositions / SceneWidth) * 360);

            cogH.transform.rotation = StartRotation * Quaternion.Euler(Vector3.forward * (CurrentDistanceBetweenMousePositions / SceneWidth) * 360);
            cogV.transform.rotation = StartRotation * Quaternion.Euler(Vector3.right * (CurrentDistanceBetweenMousePositions / SceneWidth) * 360);

            ////boat
            float horizontal = Input.GetAxis("Mouse X");
            transform.Rotate(transform.forward, horizontal * rotationSpeed, Space.World);
            translationTarget.transform.Translate(-translationTarget.transform.right * horizontal * moveSpeed, Space.World);

            ////transform.Translate(0, 0, 1 * Time.deltaTime * 5f);
            //translationTarget.transform.Translate(0, 0, 1 * Time.deltaTime * 5f);

            //inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
            //inputVertical = SimpleInput.GetAxis(verticalAxis);

            //transform.Rotate(0, inputHorizontal * 5f, 0f, Space.Self);
        }
    }
    #region
    //public void PullableLever()
    //{
    //    if (Input.GetMouseButtonDown(0)) //initial pos + rotation
    //    {
    //        PressPoint = Input.mousePosition;
    //        StartRotation = transform.rotation;
    //    }
    //    else if (Input.GetMouseButton(0)) //on continued mouse down, start rotation
    //    {
    //        //value to calculate ratio between scene width + 360° rotation
    //        float CurrentDistanceBetweenMousePositions = (Input.mousePosition - PressPoint).x;

    //        //to rotate, calculate rotation in euler angles, translate value to Quaternion, apply rotation to obj via quaternion arithmetic
    //        transform.rotation = StartRotation * Quaternion.Euler(Vector3.left * (CurrentDistanceBetweenMousePositions / SceneWidth) * 180);

    //        cogH.transform.rotation = StartRotation * Quaternion.Euler(Vector3.forward * (CurrentDistanceBetweenMousePositions / SceneWidth) * 360);
    //        cogV.transform.rotation = StartRotation * Quaternion.Euler(Vector3.right * (CurrentDistanceBetweenMousePositions / SceneWidth) * 360);
    //    }
    //}
    #endregion
}
