using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [Header("Boat")]
    public FossilFuelManager fuelManager;
    public float speed = 2;

    [Header("UI Button")]
    public GameObject button;
    public GameObject buttonPressed;
    public bool terminalOn = false;

    [Header("Engine Button")]
    public FossilFuelManager fossilFuelManager;
    public GameObject engineButton;
    public GameObject engineButtonPressed;
    public bool engineOn = false;

    [Header("UI")]
    public GameObject canvas;

    bool triggerHit = false;
    //public Transform destination;

    private void Start()
    {
        canvas.SetActive(false);
        buttonPressed.SetActive(false);
        engineButtonPressed.SetActive(false);

        fossilFuelManager.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("arrived @ destination");
        if(other.tag == "Destination")
        {
            triggerHit = true;
            transform.position += Vector3.zero;
        }
    }

    public void UITerminal()
    {
        terminalOn = !terminalOn;

        if (terminalOn)
        {
            Debug.Log("terminal ON");
            buttonPressed.SetActive(true);
            button.SetActive(false);
            canvas.SetActive(true);
        }
        else if (!terminalOn)
        {
            Debug.Log("terminal OFF");
            button.SetActive(true);
            buttonPressed.SetActive(false);
            canvas.SetActive(false);
        }
    }

    public void Engine()
    {
        engineOn = !engineOn;

        if (engineOn)
        {
            Debug.Log("engine ON");
            engineButtonPressed.SetActive(true);
            engineButton.SetActive(false);
            fossilFuelManager.enabled = true;
        }
        else if (!engineOn)
        {
            Debug.Log("engine OFF");
            engineButton.SetActive(true);
            engineButtonPressed.SetActive(false);
            fossilFuelManager.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "power controller")
                {
                    UITerminal();
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "engine")
                {
                    Engine();
                }
            }
        }

        if (engineOn && fuelManager.noFuel) //successfully implemented sunday, feb12 @ ~13:31:24 *^*!!
        {
            transform.position += Vector3.zero;
        }
        if (engineOn && !fuelManager.noFuel)
        {
            transform.position += this.transform.forward * speed * Time.deltaTime;
        }

        else if (!engineOn)
        {
            transform.position += Vector3.zero;
        }
    }
}
