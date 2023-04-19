using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    [SerializeField] private RectTransform dragRect;
    [SerializeField] private Canvas canvas;
    //[SerializeField] private Image backgroundImage;
    //private Color backgroundColor;

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
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //backgroundColor.a = 1f;
        //backgroundImage.color = backgroundColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragRect.SetAsLastSibling();
    }
}