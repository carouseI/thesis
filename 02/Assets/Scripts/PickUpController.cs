using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    #region method 1
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRb;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    //pick up
                    PickupObject(hit.transform.gameObject);
                }
            }
            else //if picked up obj, but left clicked
            {
                DropObject();
            }
        }
        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f) //check distance between point a (heldObj) and holdArea
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRb.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRb = pickObj.GetComponent<Rigidbody>();
            heldObjRb.useGravity = false; //don't fall when picked up
            heldObjRb.drag = 10;
            heldObjRb.constraints = RigidbodyConstraints.FreezeRotation; //don't rotate when picked up

            heldObj.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        heldObjRb.useGravity = true;
        heldObjRb.drag = 1;
        heldObjRb.constraints = RigidbodyConstraints.None;

        heldObj.transform.parent = null;
        heldObj = null;
    }
    #endregion

    #region method 2
    //[SerializeField] private LayerMask pickupMask;
    //[SerializeField] private Camera playerCamera;
    //[SerializeField] private Transform pickupTarget;

    //[SerializeField] private float pickupRange;
    //private Rigidbody currentObj;

    //private void Update()
    //{
    //    if (currentObj)
    //    {
    //        currentObj.useGravity = true;
    //        currentObj = null;
    //        return;
    //    }

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray CameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

    //        if(Physics.Raycast(CameraRay, out RaycastHit HitInfo, pickupRange, pickupMask))
    //        {
    //            currentObj = HitInfo.rigidbody;
    //            currentObj.useGravity = false;
    //        }
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    if (currentObj)
    //    {
    //        Vector3 DirectionToPoint = pickupTarget.position - currentObj.position;
    //        float DistanceToPoint = DirectionToPoint.magnitude;

    //        currentObj.velocity = DirectionToPoint * 12f * DistanceToPoint;
    //    }
    //}
    #endregion
}
