using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private GameObject player;

    float speed = 5f;

    private void Start()
    {
        speed = 5f;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Z)) //switch back to Z / W
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Q)) //switch back to Q / A
        {
            transform.Rotate(0, -1, 0);
            //transform.Translate(-1 * Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
            //transform.Translate(-1 * Vector3.left * Time.deltaTime * speed);
        }
    }
}