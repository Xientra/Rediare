using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class UIItemSlot : UISlot {

	/*
	[Header("UI References:")]
	public TextMeshProUGUI text;
	public Image image;
	*/

	[Tooltip("Reference to the equipment slot, represented.")]
	[SerializeField]
	private ItemSlot itemSlot;
	public ItemSlot ItemSlot {
		get => itemSlot;
		set {
			itemSlot = value;
			UpdateValues();
		}
	}

	private void Start() {
		UpdateValues();

		InGameMenuEventSystem.OnItemChanged += UpdateValues;
	}

	public override bool IsEmpty() {
		return itemSlot.IsEmpty();
	}

	private void UpdateValues(ItemSlot itemSlot) {
		if (itemSlot == this.itemSlot) {
			UpdateValues();
		}
	}

	public override void UpdateValues() {
		if (itemSlot != null) {
			Item item = itemSlot.Item;
			if (item != null) {
				text.text = item.name;
				image.enabled = true;
				image.sprite = item.image;
			}
			else {
				text.text = EMPTY_TEXT;
				image.enabled = false;
				image.sprite = null;
			}
		}
	}



	#region Drag and Drop 
	/*
	public void OnDragTrigger() {
		DragAndDropManager.instance.OnDrag();
	}

	public void OnBeginDragTrigger() {
		DragAndDropManager.instance.OnBeginDrag(this);
	}

	public void OnEndDragTrigger() {
		DragAndDropManager.instance.OnEndDrag();
	}
	*/

	// is called whenever the mouse button is released over the game object (i think)
	public override void OnDrop() {
		if (DragAndDropManager.instance.dragging == true) {

			// checks if the to drag Slot is a item slot (bc UIItemSlot can only acept other UIItemSlots)
			if (DragAndDropManager.instance.dragOrigin is UIItemSlot) {
				UIItemSlot uiItemSlotOrigin = (UIItemSlot)DragAndDropManager.instance.dragOrigin;

				// check if this itemSlot accepts the item from the other item slot
				if (itemSlot.Accepts(uiItemSlotOrigin.itemSlot.Item)) {

					//swaps items in this UIItemElements slot and the DragAndDrop origin UIItemElement
					ItemSlot.SwapItems(itemSlot, uiItemSlotOrigin.itemSlot);

					// update all changed elements
					uiItemSlotOrigin.UpdateValues();
					UpdateValues();
				}
			}
		}
	}
	#endregion

	#region hover effect for ItemInfoPanel
	public override void OnPointerEnter() {
		if (itemSlot.IsEmpty() == false)
			InGameMenu.instance.itemInfoPanel.Enable(itemSlot.Item, image.GetComponent<RectTransform>().position);
	}

	public override void OnPointerExit() {
		if (itemSlot.IsEmpty() == false)
			InGameMenu.instance.itemInfoPanel.Disable();
	}


	#endregion

	//public void OnValidate() {
	//	UpdateValues();
	//}
}