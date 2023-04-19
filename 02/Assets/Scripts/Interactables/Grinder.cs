using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinder : MonoBehaviour
{
    [Header("General")]
    public GameObject parentObject;
    private GameObject lastChildObject;

    private Camera mainCamera;
    private Vector3 screenPos;
    private float angleOffset;
    //private Collider2D collider;

    public Animator animator;

    public bool isGrinding = false;

    [Header("Death Manager")]
    public ScoreManager processed;
    public ScoreManager destroyed;
    public PlayerProgression progression;
    public FossilFuelManager fuelManager;

    // Start is called before the first frame update
    private void Start()
    {
        mainCamera = Camera.main;
        //collider = GetComponent<Collider2D>();

        animator.enabled = false;
    }

    public void grindMatter()
    {
        int lastChildIndex = parentObject.transform.childCount - 1;
        lastChildObject = parentObject.transform.GetChild(lastChildIndex).gameObject;

        //Debug.Log("fuel conversion in progression");

        if (lastChildObject.tag == "Good")
        {
            Debug.Log("good fuel");
            Destroy(lastChildObject);
        }
        if (lastChildObject.tag == "Bad")
        {
            Debug.Log("bad fuel");
            Destroy(lastChildObject);
        }
        if (lastChildObject.tag == "Neutral")
        {
            Debug.Log("ok fuel");
            Destroy(lastChildObject);
        }
        else
        {
            //Debug.Log("+1 progress");
            processed.AddScore(1);

            //Debug.Log("+1 destroyed");
            destroyed.AddScore(1);

            //Debug.Log("+1 fuel");
            fuelManager.AddFuel(1);

            //Debug.Log("+1 progress");
            progression.AddProgress(1);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Collider>() == Physics2D.OverlapPoint(mousePos))
            {

                if(hit.collider != null)
                {
                    //Debug.Log("turning right");
                    screenPos = mainCamera.WorldToScreenPoint(transform.position);
                    Vector3 vector3 = Input.mousePosition - screenPos;
                    angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x - Mathf.Atan2(vector3.y, vector3.x)) * Mathf.Rad2Deg);

                    animator.enabled = true;
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (GetComponent<Collider>() == Physics2D.OverlapPoint(mousePos))
            {
                if(hit.collider != null)
                {
                    //Debug.Log("in use");
                    isGrinding = true;

                    //Debug.Log("turning left");
                    Vector3 vector3 = Input.mousePosition - screenPos;
                    float angle = Mathf.Atan2(vector3.y, vector3.x) * Mathf.Rad2Deg;
                    transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);

                    //animator.enabled = true;
                }
            }
        }
        else
        {
            //Debug.Log("stopped");
            isGrinding = false;

            animator.enabled = false;
        }
    }
}
