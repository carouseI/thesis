using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;

    public ScoreManager processed;
    public ScoreManager destroyed;
    public ScoreManager saved;
    public ScoreManager coins;

    public FossilFuelManager fuelManager;
    public PlayerProgression progression;

    public GameObject parentObject;

    public Material dissolvedMat;
    public Material blueFireMat;
    public Material defaultFireMat;

    //public Color normalFire;
    //public Color blueFire;

    #region drag
    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
        //return Camera.main.ScreenToViewportPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        //transform.position = Camera.main.ViewportToScreenPoint(Input.mousePosition - mousePosition);
    }
    #endregion

    //private void OnCollisionStay(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Save")
    //    {
    //        Debug.Log("lock on");
    //        //saveButton.Save();
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Save")
    //    {
    //        //Debug.Log("lock on");
    //        //saveButton.Save();
    //        //saveButton.OnMouseDown();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        #region save
        if (other.gameObject.tag == "Save" && this.gameObject.tag == "Good")
        {
            GetComponent<Renderer>().material = dissolvedMat;

            Invoke(nameof(DestroyPaper), 3f);
            Debug.Log("good rightfully saved");

            //Debug.Log("+1 saved");
            saved.AddScore(1);

            Debug.Log("+1 coin");
            coins.AddScore(1);
        }
        if (other.gameObject.tag == "Save" && this.gameObject.tag == "Bad")
        {
            GetComponent<Renderer>().material = dissolvedMat;

            Invoke(nameof(DestroyPaper), 3f);
            Debug.Log("bad wrongfully saved");

            //Debug.Log("+1 saved");
            saved.AddScore(1);

            Debug.Log("+1 coin");
            coins.AddScore(1);
        }
        if (other.gameObject.tag == "Save" && this.gameObject.tag == "Neutral")
        {
            GetComponent<Renderer>().material = dissolvedMat;

            Invoke(nameof(DestroyPaper), 3f);
            Debug.Log("neutral saved");

            //Debug.Log("+1 saved");
            saved.AddScore(1);

            Debug.Log("+1 coin");
            coins.AddScore(1);
        }
        #endregion

        #region destroy
        if (other.gameObject.tag == "Fire" && this.gameObject.tag == "Good")
        {
            GetComponent<Renderer>().material = dissolvedMat;
            StartCoroutine(ChangeFire(other.gameObject));

            Invoke(nameof(DestroyPaper), 3f);
            Debug.Log("good wrongfully destroyed");

            //Debug.Log("+1 destroyed");
            destroyed.AddScore(1);

            //Debug.Log("+1 fuel");
            fuelManager.AddFuel(1);
        }
        if (other.gameObject.tag == "Fire" && this.gameObject.tag == "Bad")
        {
            //other.GetComponent<Renderer>().material = dissolvedMat;
            GetComponent<Renderer>().material = dissolvedMat;
            StartCoroutine(ChangeFire(other.gameObject));

            Invoke(nameof(DestroyPaper), 2f);
            Debug.Log("bad rightfully destroyed");

            //Debug.Log("+1 destroyed");
            destroyed.AddScore(1);

            //Debug.Log("+1 fuel");
            fuelManager.AddFuel(1);
        }
        if (other.gameObject.tag == "Fire" && this.gameObject.tag == "Neutral")
        {
            //other.GetComponent<Renderer>().material = dissolvedMat;
            GetComponent<Renderer>().material = dissolvedMat;
            StartCoroutine(ChangeFire(other.gameObject));

            Invoke(nameof(DestroyPaper), 2f);
            Debug.Log("neutral destroyed");

            //Debug.Log("+1 destroyed");
            destroyed.AddScore(1);

            //Debug.Log("+1 fuel");
            fuelManager.AddFuel(1);
        }
        #endregion

        else
        {
            Debug.Log("+1 processed");
            processed.AddScore(1);

            //Debug.Log("+1 destroyed");
            //destroyed.AddScore(1);

            //Debug.Log("+1 fuel");
            //fuelManager.AddFuel(1);

            Debug.Log("+1 progress");
            progression.AddProgress(1);
        }
    }

    private void DestroyPaper()
    {
        Destroy(gameObject);
    }

    IEnumerator ChangeFire(GameObject fire)
    {
        fire.GetComponent<Renderer>().material = blueFireMat;
        yield return new WaitForSeconds(2f);
        fire.GetComponent<Renderer>().material = defaultFireMat;
    }
}