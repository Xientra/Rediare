using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropManager : MonoBehaviour {

	public static DragAndDropManager instance;

	public UIItemSlot itemElementOrigin;


	public GameObject draggerGraphicPrefab;
	private GameObject draggerGraphic;
	[Range(0, 1)]
	public float draggerAlphaValue = 0.75f;
	public float draggerScale = 0.2f;

	public bool dragging { get; private set; } = false;

	private void Awake() {
		if (instance == null) {
			instance = this;
		}
		else {
			Destroy(this.gameObject);
			Debug.LogError("Too many Drag and Drop Manager");
		}
	}

	#region this is the version where a visual copy of the item is created (this one is used)

	public void OnBeginDrag(GameObject toDrag) {

        itemElementOrigin = toDrag.GetComponent<UIItemSlot>();

        if (itemElementOrigin.ItemSlot.IsEmpty() == false) {

			// create dragger graphic
			draggerGraphic = Instantiate(draggerGraphicPrefab, InGameMenu.instance.transform);
			Image draggerImage = draggerGraphic.GetComponent<Image>();
			draggerImage.sprite = itemElementOrigin.ItemSlot.Item.image;
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
			Destroy(draggerGraphic);
			dragging = false;
		}
		itemElementOrigin = null;
    }
#endregion
}