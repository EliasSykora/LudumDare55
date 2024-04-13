using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDraggable : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
    public void OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
    }
}
