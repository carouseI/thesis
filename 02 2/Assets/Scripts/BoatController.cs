using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public FossilFuelManager fuelManager;

    public float speed = 2;

    bool triggerHit = false;
    //public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("arrived @ destination");
        if(other.tag == "Destination")
        {
            triggerHit = true;
            transform.position += Vector3.zero;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (fuelManager.noFuel) //successfully implemented sunday, feb12 @ ~13:31:24 *^*!!
        {
            transform.position += Vector3.zero;
        }
        if(!fuelManager.noFuel)
        {
            transform.position += this.transform.forward * speed * Time.deltaTime;
        }
    }
}
