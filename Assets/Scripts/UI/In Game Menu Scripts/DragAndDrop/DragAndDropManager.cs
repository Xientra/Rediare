using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropManager : MonoBehaviour {

	public static DragAndDropManager instance;

    public UIItemElement itemElementOrigin;
    public Item itemDragger;


	public GameObject draggerGraphicPrefab;
	GameObject draggerGraphic;
	[Range(0, 1)]
    public float draggerAlphaValue = 0.75f;
	public float draggerScale = 0.2f;

	bool dragging = false;


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

    public void OnBeginDrag(GameObject toDrag) {

        itemElementOrigin = toDrag.GetComponent<UIItemElement>();
        itemDragger = toDrag.GetComponent<UIItemElement>().item;

        if (itemElementOrigin.item != null) {

			draggerGraphic = Instantiate(draggerGraphicPrefab, InGameMenu.instance.transform);
			Image draggerImage = draggerGraphic.GetComponent<Image>();
			draggerImage.sprite = itemDragger.image;
			draggerImage.color = new Color(draggerImage.color.r, draggerImage.color.g, draggerImage.color.b, draggerAlphaValue);
			draggerGraphic.transform.localScale = new Vector3(draggerScale, draggerScale, draggerScale);

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
				itemElementOrigin.UpdateValues();
			}

			Destroy(draggerGraphic);
			dragging = false;
		}
    }
#endregion
}