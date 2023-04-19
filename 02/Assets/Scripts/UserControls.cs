using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControls : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;

    bool dragging = false;
    Rigidbody rb;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    void OnMouseDrag()
    {
        dragging = true;

        float xAxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float yAxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(Vector3.down, xAxisRotation, Space.World);
        transform.Rotate(Vector3.right, yAxisRotation, Space.World);
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        dragging = false;
    //    }
    //}

    //void FixedUpdate()
    //{
    //    if (dragging)
    //    {
    //        float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
    //        float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;

    //        rb.AddTorque(Vector3.down * x);
    //        rb.AddTorque(Vector3.right * y);
    //    }
    //}
}
