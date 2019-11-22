﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropManager : MonoBehaviour {

	public static DragAndDropManager instance;

    //the dragger is the object being dragged
    public static GameObject objectDragger;
    public static UIItemElement itemElementOrigin;
    public static Item itemDragger; 


    [Range(0, 1)]
    public float draggerAlphaValue = 0.75f;
	public float draggerScale = 0.2f;

    public GameObject draggerGraphicPrefab;

	private void Awake() {
		if (instance == null) {
			instance = this;
		}
		else {
			Destroy(this.gameObject);
			Debug.LogError("Too many Drag and Drop Manager");
		}
	}



	#region this is the version where just a visual copy of the item is created 

	bool dragging = false;
    CanvasGroup draggerGraphicCanvasGroup;
    GameObject draggerGraphic;

    public void OnBeginDrag(GameObject toDrag) {

        itemElementOrigin = toDrag.GetComponent<UIItemElement>();
        itemDragger = toDrag.GetComponent<UIItemElement>().item;

        if (itemElementOrigin.item != null) {

			draggerGraphic = Instantiate(draggerGraphicPrefab, InGameMenu.instance.transform);
			Image draggerImage = draggerGraphic.GetComponent<Image>();
			draggerImage.sprite = itemDragger.image;
			draggerImage.color = new Color(draggerImage.color.r, draggerImage.color.g, draggerImage.color.b, draggerAlphaValue);
			draggerGraphic.transform.localScale = new Vector3(draggerScale, draggerScale, draggerScale);
			
            // makes the dragger not hittable by raycast so we can detect whats below it
            // draggerGraphicCanvasGroup = draggerGraphic.GetComponent<CanvasGroup>();
            // draggerGraphicCanvasGroup.blocksRaycasts = false;

			dragging = true;
        }
    }

    // called every frame something is being dragged
    public void OnDrag() {
		if (dragging == true) {
			draggerGraphic.transform.position = Input.mousePosition;
		}
	}

    // this is called, after drop for this dragger has been called (i think)
    public void OnEndDrag() {

		if (dragging == true) {
			if (itemDragger == null) { //if the drag was successfull
				itemElementOrigin.Empty();
			}

			//draggerGraphicCanvasGroup.blocksRaycasts = true;
			//draggerGraphicCanvasGroup.alpha = 1f;

			Destroy(draggerGraphic);
			dragging = false;
		}
    }
#endregion

    #region this is the version that drags an acual object and resets it's psoition if it can't drop anywhere

    /*
    Vector3 startPosition;
    Transform startParent;
    CanvasGroup canvasGroup;

    public void OnBeginDrag(GameObject toDrag) {

        startPosition = toDrag.transform.position;
        startParent = toDrag.transform.parent;
        canvasGroup = toDrag.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = draggerAlphaValue;

        objectDragger = toDrag;
        itemDragger = toDrag.GetComponent<UIItemElement>().item;
    }

    // called every frame something is being dragged
    public void OnDrag(GameObject toDrag) { 
        toDrag.transform.position = Input.mousePosition;
    }

    // called when the drag ends but not if it's dropped
    public void OnEndDrag(GameObject toDrag) {


        if (toDrag.transform.parent == startParent) {
            toDrag.transform.position = startPosition;
        }

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        objectDragger = null;
        itemDragger = null;
    }
    */

    #endregion
}