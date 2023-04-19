using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectPreview : MonoBehaviour
{
    public GameObject parentObject;
    private GameObject lastChildObject;

    //public GameObject interactionIndicator;

    [SerializeField] private Image _noteImage;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _info;

    bool inPreview = false;

    //private void OnMouseDown()
    //{
    //    //inPreview = !inPreview;
    //    //_noteImage.enabled = !_noteImage.enabled;
    //    //_noteImage.enabled = true;
    //}

    //private void OnMouseUp()
    //{
    //    _noteImage.enabled = false;
    //}

    //private void Start()
    //{
    //    int lastChildIndex = parentObject.transform.childCount - 1;
    //    lastChildObject = parentObject.transform.GetChild(lastChildIndex).gameObject;

    //    if (lastChildObject.active)
    //    {
    //        Update();
    //    }
    //}

    //private void Start()
    //{
    //    interactionIndicator.SetActive(false);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        //Debug.Log("in preview mode");
    //        inPreview = true;
    //        _noteImage.enabled = true;
    //        _name.enabled = true;
    //        _info.enabled = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //interactionIndicator.SetActive(false);

    //    //Debug.Log("exiting preview mode");
    //    inPreview = false;
    //    _noteImage.enabled = false;
    //    _name.enabled = false;
    //    _info.enabled = false;
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("in preview mode");
            inPreview = true;
            _noteImage.enabled = true;
            _name.enabled = true;
            _info.enabled = true;
        }
        else if (inPreview && Input.GetMouseButton(0))
        {
            //Debug.Log("exiting preview mode");
            inPreview = false;
            _noteImage.enabled = false;
            _name.enabled = false;
            _info.enabled = false;
        }
    }
}
