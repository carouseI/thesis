using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;

    [Header("Score Managers")]
    public ScoreManager processed;
    public ScoreManager destroyed;
    public ScoreManager saved;

    [Header("Progress Trackers")]
    public FossilFuelManager fuelManager;
    public PlayerProgression progression;
    public SystemManager systemManager;
    public ShopManager shoppingFunds;

    //[SerializeField] private Image _noteImage;
    //[SerializeField] private TextMeshProUGUI _name;
    //[SerializeField] private TextMeshProUGUI _info;

    [Header("Transition Settings")]
    public Material dissolvedMat;
    public Material blueFireMat;
    public Material defaultFireMat;

    //public Color normalFire;
    //public Color blueFire;

    [Header("Preview Settings")]
    public GameObject previewParent;
    public GameObject bookChild;
    private Animator animator;
    public
    //private Animation animation;
    //public Animator closeAnimation;
    bool previewing = false;


    #region drag + preview
    private void Awake()
    {
        animator = bookChild.GetComponent<Animator>();
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
        //return Camera.main.ScreenToViewportPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("accessing preview mode");
            previewing = !previewing;

            if (previewing)
            {
                Debug.Log("previewing");
                //previewParent.SetActive(false);
                bookChild.SetActive(true);
            }
            if (!previewing)
            {
                Debug.Log("closing preview");
                animator.Play("putDownBook");
            }
        }
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

    private void Start()
    {
        //parent.GetComponent<SalvationManager>().salvationRecord();
        systemManager = FindObjectOfType<SystemManager>();

        bookChild.SetActive(false);
        //animator = bookChild.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        #region save
        if (other.gameObject.tag == "Save" && this.gameObject.tag == "Good")
        {
            GetComponent<Renderer>().material = dissolvedMat;

            //systemManager.salvationRecord.Add(this.gameObject.name);
            Invoke(nameof(SavePaper), 3f);

            //Invoke(nameof(DestroyPaper), 3f);
            Debug.Log("good rightfully saved");

            //Debug.Log("+1 saved");
            saved.AddScore(1);

            //Debug.Log("+1 coin");
            shoppingFunds.goodSaved();
            //incomeManager.AddCoins(1);
            //coins.AddScore(1);
        }
        if (other.gameObject.tag == "Save" && this.gameObject.tag == "Bad")
        {
            GetComponent<Renderer>().material = dissolvedMat;

            //systemManager.salvationRecord.Add(this.gameObject.name);
            Invoke(nameof(SavePaper), 3f);

            //Invoke(nameof(DestroyPaper), 3f);
            Debug.Log("bad wrongfully saved");

            //Debug.Log("+1 saved");
            saved.AddScore(1);

            //Debug.Log("+1 coin");
            shoppingFunds.badSaved();
            //incomeManager.AddCoins(1);
            //coins.AddScore(2);
        }
        if (other.gameObject.tag == "Save" && this.gameObject.tag == "Neutral")
        {
            GetComponent<Renderer>().material = dissolvedMat;

            //systemManager.salvationRecord.Add(this.gameObject.name);
            Invoke(nameof(SavePaper), 3f);

            //Invoke(nameof(DestroyPaper), 3f);
            Debug.Log("neutral saved");

            //Debug.Log("+1 saved");
            saved.AddScore(1);

            //Debug.Log("+1 coin");
            //coins.AddScore(1);
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

            shoppingFunds.goodDestroyed();

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

            shoppingFunds.badDestroyed();

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

            shoppingFunds.neutralDestroyed();

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

    private void SavePaper()
    {
        gameObject.SetActive(false);
    }

    private void DestroyPaper()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    IEnumerator ChangeFire(GameObject fire)
    {
        fire.GetComponent<Renderer>().material = blueFireMat;
        yield return new WaitForSeconds(2f);
        fire.GetComponent<Renderer>().material = defaultFireMat;
    }
}