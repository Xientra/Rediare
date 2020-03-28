using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class UISlot : MonoBehaviour {

	[Header("UI References:")]

	public TextMeshProUGUI text;
	public Image image;

	public const string EMPTY_TEXT = "[Empty]";


	private void Start() {
		UpdateValues();
	}


	public void UpdateValues() {

	}

	public void OnValidate() {
		UpdateValues();
	}

	#region Drag and Drop 
	public void OnDragTrigger() {
		DragAndDropManager.instance.OnDrag();
	}

	public void OnBeginDragTrigger() {
		DragAndDropManager.instance.OnBeginDrag(this.gameObject);
	}

	public void OnEndDragTrigger() {
		DragAndDropManager.instance.OnEndDrag();
	}

	// is called whenever the mouse button is released over the game object (i think)
	public void OnDrop() {
		if (DragAndDropManager.instance.dragging == true) {
			/*
			UIItemSlot itemElementOrigin = DragAndDropManager.instance.itemElementOrigin;

			//Debug.Log(itemSlot.Accepts(itemElementOrigin.itemSlot.Item));

			if (itemSlot.Accepts(itemElementOrigin.itemSlot.Item)) {

				//swaps items in this UIItemElements slot and the DragAndDrop origin UIItemElement
				ItemSlot.SwapItems(itemSlot, itemElementOrigin.itemSlot);

				// update all changed elements
				itemElementOrigin.UpdateValues();
				UpdateValues();
			}
			*/
		}
	}
	#endregion

	#region hover effect for ItemInfoPanel
	public void OnPointerEnter() {
	}

	public void OnPointerExit() {

	}
	#endregion
}