using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum side { Left, Mid, Right }

public class LeverPullAnim : MonoBehaviour
{
    public side m_Side = side.Mid;
    float newXPos = 0f;
    //public bool moveLeft;
    //public bool moveRight;
    public float xValue;
    public BoatController boatController;

    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        boatController = GetComponent<BoatController>();
        anim = GetComponent<Animation>();
        //anim.Play("take001");
    }

    // Update is called once per frame
    void Update()
    {
        //left
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.Play("Take 001");

            if(m_Side == side.Mid)
            {
                newXPos = -xValue;
                m_Side = side.Left;
            }
            else if(m_Side == side.Right)
            {
                newXPos = 0;
                m_Side = side.Mid;
            }
        }

        //right
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim["Take 001"].speed = -1;
            anim["Take 001"].time = anim["Take 001"].length;
            anim.Play("Take 001");

            if (m_Side == side.Mid)
            {
                newXPos = xValue;
                m_Side = side.Right;
            }
            else if (m_Side == side.Left)
            {
                newXPos = 0;
                m_Side = side.Mid;
            }
        }

        //boatController.Update(newXPos - transform.position.x)*Vector3.right);
    }
}
