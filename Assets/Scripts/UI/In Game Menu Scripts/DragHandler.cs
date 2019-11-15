using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    CanvasGroup canvasGroup;

    void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) {

        startPosition = transform.position;
        startParent = transform.parent;
        canvasGroup.blocksRaycasts = false;

        itemBeingDragged = gameObject;

    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {


        if (transform.parent == startParent) {
            transform.position = startPosition;
        }

        canvasGroup.blocksRaycasts = true;
        itemBeingDragged = null;
    }
}