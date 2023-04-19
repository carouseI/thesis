using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIDragger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    #region
    //[SerializeField] private Canvas canvas;

    //public void HandleDragging(BaseEventData data)
    //{
    //    PointerEventData pointerData = (PointerEventData)data;

    //    Vector2 position;

    //    RectTransformUtility.ScreenPointToLocalPointInRectangle
    //        ((RectTransform)canvas.transform,
    //        pointerData.position,
    //        canvas.worldCamera,
    //        out position);

    //    transform.position = canvas.transform.TransformPoint(position);
    //}
    #endregion

    [Header("Object Variables")]
    public GameObject parentObject;
    private GameObject lastChildObject;

    public Button saveButton;
    public Button trashButton;
    public bool inDropzone = false;

    [Header("General")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform dragRect;
    [SerializeField] private GameObject selectOutline;

    [Header("Colour")]
    public Color shadow;

    [Header("Specifics")]
    public TMP_Text name;
    public TMP_Text info;
    public TMP_Text thought;

    [Header("Transform")]
    public Grinder grinder;
    public Lantern lantern;
    public Sprite bone;
    public Sprite ash;
    public Sprite star;

    public float shrinkDuration = 5f;
    public Vector3 targetScale = Vector3.one * .5f;
    Vector3 startScale;
    float t = 0; //interpolant for linear interpolation
    public bool canGrind = false;
    public bool canSave = false;

    //public bool isSelected = false;

    private void OnEnable()
    {
        //startScale = transform.localScale;
        //t = 0;
    }

    private void Awake()
    {
        //backgroundColor = backgroundImage.color;
        if(canvas == null)
        {
            Transform canvasTransform = transform.parent;

            while(canvasTransform != null)
            {
                canvas = canvasTransform.GetComponent<Canvas>();

                if(canvas != null)
                {
                    break;
                }

                canvasTransform = canvasTransform.parent;
            }
        }

        selectOutline.SetActive(false);
        //shrink.SetActive(false);
    }

    private void Start()
    {
        saveButton.interactable = false;
        trashButton.interactable = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //backgroundColor.a = .5f;
        //backgroundImage.color = backgroundColor;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("dragging");
        dragRect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        //selectOutline.SetActive(true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //backgroundColor.a = 1f;
        //backgroundImage.color = backgroundColor;
        selectOutline.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragRect.SetAsLastSibling();
        //selectOutline.SetActive(true);

        int lastChildIndex = parentObject.transform.childCount - 1;
        lastChildObject = parentObject.transform.GetChild(lastChildIndex).gameObject;

        if (lastChildObject)
        {
            selectOutline.SetActive(true);
        }
        else if (!lastChildObject)
        {
            selectOutline.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //t += Time.deltaTime / shringDuration;

        //Vector3 newScale = Vector3.Lerp(startScale, targetScale, t);
        //transform.localScale = newScale;

        if (other.gameObject.name == "drop zone")
        {
            Debug.Log("in dropzone");
            inDropzone = true;

            saveButton.interactable = true;
            trashButton.interactable = true;
        }

        #region destroy
        //if (other.gameObject.name == "skull")
        //{
        //    gameObject.transform.localScale += new Vector3(2.0f, 2.5f, 1.5f);

        //    //Debug.Log("entered dropzone");
        //    //GetComponent<Image>().enabled = false;
        //    selectOutline.SetActive(false);
        //    GetComponent<Image>().sprite = bone;
        //    name.enabled = false;
        //    info.enabled = false;
        //    thought.enabled = false;

        //    //selectOutline.SetActive(false);
        //    //shrink.SetActive(true);
        //}

        //if (other.gameObject.name == "mouth")
        //{
        //    //Debug.Log("in mouth");
        //    GetComponent<Image>().sprite = ash;
        //    canGrind = true;
        //}
        #endregion

        #region save
        //if (other.gameObject.name == "lantern")
        //{
        //    selectOutline.SetActive(false);
        //    //GetComponent<Image>().color = defaultcolor;
        //    GetComponent<Image>().sprite = star;
        //    name.enabled = false;
        //    info.enabled = false;
        //    thought.enabled = false;
        //}

        //if(other.gameObject.name == "star container")
        //{
        //    canSave = true;
        //}
        #endregion
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "drop zone")
        {
            Debug.Log("out of range");
            inDropzone = false;

            saveButton.interactable = false;
            trashButton.interactable = false;
        }
    }

    private void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);


        if (canGrind && grinder.isGrinding)
        {
            grinder.grindMatter();
        }

        if (canSave)
        {
            lantern.saveMatter();
        }


        if(gameObject != lastChildObject)
        {
            //GetComponent<Image>().color = shadow;
        }
    }
}