using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropManager : MonoBehaviour {

	public static DragAndDropManager instance;

	[Header("Drag And Drop:")]
	[Tooltip("The UIItemSlot where the Drag was initiated from.")]
	public UISlot dragOrigin;

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

	#region Drag And Drop

	public void OnBeginDrag(UISlot origin) {

		if (origin.IsEmpty() == false) {

			dragOrigin = origin;

			// create dragger graphic
			draggerGraphic = Instantiate(draggerGraphicPrefab, InGameMenu.instance.transform);
			Image draggerImage = draggerGraphic.GetComponent<Image>();
			draggerImage.sprite = dragOrigin.image.sprite; // <--------------------------------------------------------------------------- how the image is accesd will prob change
			draggerImage.color = new Color(draggerImage.color.r, draggerImage.color.g, draggerImage.color.b, draggerAlphaValue);
			draggerGraphic.transform.localScale = new Vector3(draggerScale, draggerScale, draggerScale);


			dragging = true;
		}
	}

	// called every frame if something is being dragged
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
		dragOrigin = null;
	}
	#endregion
}